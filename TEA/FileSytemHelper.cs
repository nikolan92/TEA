using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A51
{
    public class FileSystemHelper
    {

        public byte[] readBytesFromFile(string filePath,bool mod4bytes)
        {
            try
            {
                using (FileStream fsSource = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    byte[] bytes;
                    if (mod4bytes)
                    {
                        long overflowBytes = fsSource.Length % 8;
                        long newByteLength = overflowBytes == 0 ? fsSource.Length : (8 - overflowBytes) + fsSource.Length;
                        bytes = new byte[newByteLength];
                        //write 0 on last 8 bytes
                        for (int i = 1; i <= 8; i++)
                        {
                            bytes[newByteLength - i] = 0;
                        }
                    }
                    else
                    {
                        bytes = new byte[fsSource.Length];
                    }

                    int numBytesToRead = (int)fsSource.Length;
                    int numBytesRead = 0;

                    while (numBytesToRead > 0)
                    {

                        int n = fsSource.Read(bytes, numBytesRead, numBytesToRead);

                        if (n == 0)
                            break;

                        numBytesRead += n;
                        numBytesToRead -= n;
                    }
                    fsSource.Close();
                    return bytes;
                }
            }
            catch (FileNotFoundException)
            {
                return null;
            }
            catch (IOException)
            {
                return null;
            }

        }

        public void writeBtytesToFile(byte[] bytes, int bytesLength, string filePath)
        {
            if (bytes == null)
                return;
            using (FileStream fsNew = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                fsNew.Write(bytes, 0, bytesLength);
                fsNew.Close();
            }
        }
    }
}
