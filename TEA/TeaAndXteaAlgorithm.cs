using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A51
{
    public class TeaAndXteaAlgorithm
    {
        private uint[] key,iv;
        private const uint delta = 0x9e3779b9;//32bit number
        public TeaAndXteaAlgorithm(string key,string iv)
        {
            this.key = new uint[4]; 
            this.iv = new uint[2];
            int counter = 0;
            //key and iv initialization
            for (int i = 0; i < 4; i++)
            {
                for (int j = counter; j < counter+32; j++)
                {
                    if (key[j].Equals('0'))
                    {
                        this.key[i] = this.key[i] << 1;
                    }
                    else
                    {
                        this.key[i] = this.key[i] << 1;
                        this.key[i] = this.key[i] | 1;
                    }
                }
                if (i < 2)
                {
                    for (int j = counter; j < counter+32; j++)
                    {
                        if (iv[j].Equals('0'))
                        {
                            this.iv[i] = this.iv[i] << 1;
                        }
                        else
                        {
                            this.iv[i] = this.iv[i] << 1;
                            this.iv[i] = this.iv[i] | 1;
                        }
                    }
                }
                counter += 32;
            }//end of for
        }
        public byte[] teaEncrypt(byte[] bytesForEncrypt,bool bmpEncryption, out long time)
        {
            if (bytesForEncrypt == null || bytesForEncrypt.Length == 0)
            {
                time = 0;
                return null;
            }
            Stopwatch sw = new Stopwatch();
            sw.Start();

            byte[] encryptedBytes = new byte[bytesForEncrypt.Length];

            int counter = 0;
            if (bmpEncryption)
            {
                //copy header file from BMP direct to decrypted bytes
                while (counter < 54)
                {
                    encryptedBytes[counter] = bytesForEncrypt[counter];
                    counter++;
                }
            }
            uint v0=0, v1=0, sum;
            uint xor0=0, xor1=0,tmp0,tmp1;
            //encryption
            for (int i = counter; i <= bytesForEncrypt.Length-8; i = i + 8)
            {
                v0 = BitConverter.ToUInt32(bytesForEncrypt, i);
                v1 = BitConverter.ToUInt32(bytesForEncrypt, i+4);

                //PCBC
                tmp0 = v0;
                tmp1 = v1;
                if (i == 0)
                {
                    v0 = v0 ^ iv[0];
                    v1 = v1 ^ iv[1];
                }else
                {
                    v0 = v0 ^ xor0;
                    v1 = v1 ^ xor1;
                }
                //32 rounds
                sum = 0;
                for (int j = 0; j < 32; j++)
                {
                    sum += delta;
                    v0 += ((v1 << 4) + key[0]) ^ (v1 + sum) ^ ((v1 >> 5) + key[1]);
                    v1 += ((v0 << 4) + key[2]) ^ (v0 + sum) ^ ((v0 >> 5) + key[3]);
                }

                //PCBC
                xor0 = v0 ^ tmp0;
                xor1 = v1 ^ tmp1;

                //writing data back in final byte array
                byte[] v0b = BitConverter.GetBytes(v0);
                byte[] v1b = BitConverter.GetBytes(v1);

                for (int j = 0; j < 4; j++)
                {
                    encryptedBytes[i + j] = v0b[j];
                    encryptedBytes[i + j + 4] = v1b[j];
                }
            }//end of for
            sw.Stop();
            time = sw.ElapsedMilliseconds;
            return encryptedBytes;
        }

        public byte[] teaDecrypt(byte[] bytesForDecrypt, bool bmpDecryption, out long time)
        {
            if (bytesForDecrypt == null || bytesForDecrypt.Length == 0)
            {
                time = 0;
                return null;
            }
            Stopwatch sw = new Stopwatch();
            sw.Start();

            byte[] decryptedBytes = new byte[bytesForDecrypt.Length];

            int counter = 0;
            if (bmpDecryption)
            {
                //copy header file from BMP direct to decrypted bytes
                while (counter < 54)
                {
                    decryptedBytes[counter] = bytesForDecrypt[counter];
                    counter++;
                }
            }

            uint v0 = 0, v1 = 0, sum;
            uint xor0 = 0, xor1 = 0, tmp0, tmp1;
            //decryption
            for (int i = counter; i <= bytesForDecrypt.Length - 8; i = i + 8)
            {

                v0 = BitConverter.ToUInt32(bytesForDecrypt, i);
                v1 = BitConverter.ToUInt32(bytesForDecrypt, i + 4);

                //PCBC
                tmp0 = v0;
                tmp1 = v1;

                //32 round
                sum = 0xc6ef3720;
                for (int j = 0; j < 32; j++)
                {
                    v1 -= ((v0 << 4) + key[2]) ^ (v0 + sum) ^ ((v0 >> 5) + key[3]);
                    v0 -= ((v1 << 4) + key[0]) ^ (v1 + sum) ^ ((v1 >> 5) + key[1]);
                    sum -= delta;
                }
                //PCBC
                if (i == 0)
                {
                    v0 = v0 ^ iv[0];
                    v1 = v1 ^ iv[1];
                }
                else
                {
                    v0 = v0 ^ xor0;
                    v1 = v1 ^ xor1;
                }
                xor0 = v0 ^ tmp0;
                xor1 = v1 ^ tmp1;

                //writing data back in final byte array
                byte[] v0b = BitConverter.GetBytes(v0);
                byte[] v1b = BitConverter.GetBytes(v1);
                for (int j = 0; j < 4; j++)
                {
                    decryptedBytes[i + j] = v0b[j];
                    decryptedBytes[i + j + 4] = v1b[j];
                }
            }//end of for
            sw.Stop();
            time = sw.ElapsedMilliseconds;
            return decryptedBytes;
        }
        public byte[] xteaEncrypt(byte[] bytesForEncrypt, bool bmpEncryption, out long time)
        {
            if (bytesForEncrypt == null || bytesForEncrypt.Length == 0)
            {
                time = 0;
                return null;
            }
            Stopwatch sw = new Stopwatch();
            sw.Start();

            byte[] encryptedBytes = new byte[bytesForEncrypt.Length];

            int counter = 0;
            if (bmpEncryption)
            {
                //copy header file from BMP direct to decrypted bytes
                while (counter < 54)
                {
                    encryptedBytes[counter] = bytesForEncrypt[counter];
                    counter++;
                }
            }
            uint v0 = 0, v1 = 0, sum;
            uint xor0 = 0, xor1 = 0, tmp0, tmp1;
            //encryption
            for (int i = counter; i <= bytesForEncrypt.Length - 8; i = i + 8)
            {
                v0 = BitConverter.ToUInt32(bytesForEncrypt, i);
                v1 = BitConverter.ToUInt32(bytesForEncrypt, i + 4);

                //PCBC
                tmp0 = v0;
                tmp1 = v1;
                if (i == 0)
                {
                    v0 = v0 ^ iv[0];
                    v1 = v1 ^ iv[1];
                }
                else
                {
                    v0 = v0 ^ xor0;
                    v1 = v1 ^ xor1;
                }
                //32 rounds
                sum = 0;
                for (int j = 0; j < 32; j++)
                {
                    v0 += (((v1 << 4) ^ (v1 >> 5)) + v1) ^ (sum + key[sum & 3]);
                    sum += delta;
                    v1 += (((v0 << 4) ^ (v0 >> 5)) + v0) ^ (sum + key[(sum >> 11) & 3]);
                }

                //PCBC
                xor0 = v0 ^ tmp0;
                xor1 = v1 ^ tmp1;

                //writing data back in final byte array
                byte[] v0b = BitConverter.GetBytes(v0);
                byte[] v1b = BitConverter.GetBytes(v1);

                for (int j = 0; j < 4; j++)
                {
                    encryptedBytes[i + j] = v0b[j];
                    encryptedBytes[i + j + 4] = v1b[j];
                }
            }//end of for
            sw.Stop();
            time = sw.ElapsedMilliseconds;
            return encryptedBytes;
        }

        public byte[] xteaDecrypt(byte[] bytesForDecrypt, bool bmpDecryption, out long time)
        {
            if (bytesForDecrypt == null || bytesForDecrypt.Length == 0)
            {
                time = 0;
                return null;
            }
            Stopwatch sw = new Stopwatch();
            sw.Start();

            byte[] decryptedBytes = new byte[bytesForDecrypt.Length];

            int counter = 0;
            if (bmpDecryption)
            {
                //copy header file from BMP direct to decrypted bytes
                while (counter < 54)
                {
                    decryptedBytes[counter] = bytesForDecrypt[counter];
                    counter++;
                }
            }
            uint v0 = 0, v1 = 0, sum;
            uint xor0 = 0, xor1 = 0, tmp0, tmp1;
            //decryption
            for (int i = counter; i <= bytesForDecrypt.Length - 8; i = i + 8)
            {

                v0 = BitConverter.ToUInt32(bytesForDecrypt, i);
                v1 = BitConverter.ToUInt32(bytesForDecrypt, i + 4);

                //PCBC
                tmp0 = v0;
                tmp1 = v1;

                //32 round
                sum = 0xC6EF3720;//delta *32; or delta << 5;
                for (int j = 0; j < 32; j++)
                {
                    v1 -= (((v0 << 4) ^ (v0 >> 5)) + v0) ^ (sum + key[(sum >> 11) & 3]);
                    sum -= delta;
                    v0 -= (((v1 << 4) ^ (v1 >> 5)) + v1) ^ (sum + key[sum & 3]);
                }
                //PCBC
                if (i == 0)
                {
                    v0 = v0 ^ iv[0];
                    v1 = v1 ^ iv[1];
                }
                else
                {
                    v0 = v0 ^ xor0;
                    v1 = v1 ^ xor1;
                }
                xor0 = v0 ^ tmp0;
                xor1 = v1 ^ tmp1;

                //writing data back in final byte array
                byte[] v0b = BitConverter.GetBytes(v0);
                byte[] v1b = BitConverter.GetBytes(v1);
                for (int j = 0; j < 4; j++)
                {
                    decryptedBytes[i + j] = v0b[j];
                    decryptedBytes[i + j + 4] = v1b[j];
                }
            }//end of for
            sw.Stop();
            time = sw.ElapsedMilliseconds;
            return decryptedBytes;
        }
        public byte[] teaBmpEncrypt(byte[] bytesForEncrypt,bool bmpEncryption, out long time)
        {
            if (bytesForEncrypt == null || bytesForEncrypt.Length == 0)
            {
                time = 0;
                return null;
            }
            Stopwatch sw = new Stopwatch();
            sw.Start();

            byte[] encryptedBytes = new byte[bytesForEncrypt.Length];

            //copy header file from BMP direct to encrypted bytes
            //long pos = bytesForEncrypt[10] 256 * (bytesForEncrypt[11] 256 * (bytesForEncrypt[12] 256 * bytesForEncrypt[13]));
            int counter = 0;
            if (bmpEncryption)
            {
                while (counter < 54)
                {
                    encryptedBytes[counter] = bytesForEncrypt[counter];
                    counter++;
                }
            }
            uint v0 = 0, v1 = 0, sum;
            uint xor0 = 0, xor1 = 0, tmp0, tmp1;
            //encryption
            for (int i = counter; i <= bytesForEncrypt.Length - 8; i = i + 8)
            {
                
                v0 = BitConverter.ToUInt32(bytesForEncrypt, i);
                v1 = BitConverter.ToUInt32(bytesForEncrypt, i + 4);

                //PCBC
                tmp0 = v0;
                tmp1 = v1;
                if (i == 0)
                {
                    v0 = v0 ^ iv[0];
                    v1 = v1 ^ iv[1];
                }
                else
                {
                    v0 = v0 ^ xor0;
                    v1 = v1 ^ xor1;
                }
                //32 rounds
                sum = 0;
                for (int j = 0; j < 32; j++)
                {
                    sum += delta;
                    v0 += ((v1 << 4) + key[0]) ^ (v1 + sum) ^ ((v1 >> 5) + key[1]);
                    v1 += ((v0 << 4) + key[2]) ^ (v0 + sum) ^ ((v0 >> 5) + key[3]);
                }

                //PCBC
                xor0 = v0 ^ tmp0;
                xor1 = v1 ^ tmp1;

                //writing data back in final byte array
                byte[] v0b = BitConverter.GetBytes(v0);
                byte[] v1b = BitConverter.GetBytes(v1);

                for (int j = 0; j < 4; j++)
                {
                    encryptedBytes[i + j] = v0b[j];
                    encryptedBytes[i + j + 4] = v1b[j];
                }
            }//end of for
            sw.Stop();
            time = sw.ElapsedMilliseconds;
            return encryptedBytes;
        }
    }
}
