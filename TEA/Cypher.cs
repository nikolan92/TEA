using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A51
{
    public class Cypher
    {
        private Queue<FileProperties> filesForEncryption;
        private Thread thread;
        private bool doWork = true;
        private TEA form;
        private bool teaOrXtea;
        public Cypher(TEA form,bool teaOrXtea)
        {
            this.form = form;
            this.teaOrXtea = teaOrXtea;
        }
        public void addFileForEncryption(FileProperties fileName)
        {
            lock (filesForEncryption)
            {
                filesForEncryption.Enqueue(fileName);
                Monitor.Pulse(filesForEncryption);
            }
        }
        public void startWatching()
        {
            filesForEncryption = new Queue<FileProperties>(50);
            thread = new Thread(new ThreadStart(proceedFiles));
            //try
            //{
            thread.Start();
            //}
            //catch (ThreadInterruptedException) { }
        }
        public void stopWatching()
        {
            doWork = false;
            if (thread.ThreadState == ThreadState.Running)
                thread.Join();
            else
            {
                thread.Interrupt();
                thread.Join();
            }
        }
        private void proceedFiles()
        {
            FileProperties fileForProceed;
            while (doWork)
            {
                lock (filesForEncryption)
                {
                    if (filesForEncryption.Count == 0)
                    {
                        try
                        {
                            Monitor.Wait(filesForEncryption);
                        }
                        catch (ThreadInterruptedException) { }

                        if (!doWork)
                            break;
                    }
                    fileForProceed = filesForEncryption.Dequeue();
                }//lock end
                //Encrypting file
                TeaAndXteaAlgorithm a51 = new TeaAndXteaAlgorithm(fileForProceed.Key,fileForProceed.IV);
                FileSystemHelper fsh = new FileSystemHelper();

                byte[] proceesedBytes;
                long time;
                //Change UI
                form.BeginInvoke((MethodInvoker)delegate
                {
                    form.processedFile.Text = fileForProceed.FileInputPath;
                });
                if (teaOrXtea)
                {
                    if (fileForProceed.Encrypt)
                        proceesedBytes = a51.teaEncrypt(fsh.readBytesFromFile(fileForProceed.FileInputPath,true),false, out time);
                    else
                        proceesedBytes = a51.teaDecrypt(fsh.readBytesFromFile(fileForProceed.FileInputPath,true), false, out time);
                }else
                {
                    if (fileForProceed.Encrypt)
                        proceesedBytes = a51.xteaEncrypt(fsh.readBytesFromFile(fileForProceed.FileInputPath,true), false, out time);
                    else
                        proceesedBytes = a51.xteaDecrypt(fsh.readBytesFromFile(fileForProceed.FileInputPath,true), false, out time);
                }
                if (proceesedBytes != null)
                {
                    string newFileName;
                    if (teaOrXtea)
                    {
                        if (fileForProceed.Encrypt)
                        {
                            newFileName = fileForProceed.FileOutputPath +
                                "\\" + Path.GetFileName(fileForProceed.FileInputPath) + "-TEA_encrypted.tea";
                        }
                        else
                        {
                            newFileName = fileForProceed.FileOutputPath +
                                "\\" + Path.GetFileName(fileForProceed.FileInputPath).Replace("-TEA_encrypted.tea", "");
                        }
                    }else
                    {
                        if (fileForProceed.Encrypt)
                        {
                            newFileName = fileForProceed.FileOutputPath +
                                "\\" + Path.GetFileName(fileForProceed.FileInputPath) + "-XTEA_encrypted.xtea";
                        }
                        else
                        {
                            newFileName = fileForProceed.FileOutputPath +
                                "\\" + Path.GetFileName(fileForProceed.FileInputPath).Replace("-XTEA_encrypted.xtea", "");
                        }
                    }

                    //remove null bytes from end if exist
                    int lengthWithoutNullBytes = proceesedBytes.Length;
                    for (int i = 1; i < 8; i++)
                    {
                        if (proceesedBytes[proceesedBytes.Length - i] == 0)
                            lengthWithoutNullBytes--;
                        else
                            break;
                    }
                    fsh.writeBtytesToFile(proceesedBytes, lengthWithoutNullBytes, newFileName);

                    string oldFileName = Path.GetFileName(fileForProceed.FileInputPath);
                    //Change UI
                    form.Invoke((MethodInvoker)delegate
                    {
                        if (fileForProceed.Encrypt)
                        {
                            form.programStateHelper.addEncryptedFile(oldFileName);
                            form.newProgramLog(oldFileName, "Encrypted", time);
                        }
                        else
                        {
                            form.newProgramLog(oldFileName, "Decrypted", time);
                        }
                        form.processedFile.Text = "-";
                    });
                }
                else
                {
                    string oldFileName = Path.GetFileName(fileForProceed.FileInputPath);
                    form.Invoke((MethodInvoker)delegate
                    {
                        form.newProgramLog(oldFileName, "File is empty!", 0);
                        form.processedFile.Text = "-";
                    });
                }
            }
        }
    }

    public class FileProperties
    {
        private string key;
        private string iv;
        private string fileInputPath;
        private string fileOutputPath;
        private bool encrypt;
        public FileProperties(string fileInputPath,string fileOutputPath,string key,string iv,bool encrypt)
        {
            Key = key;
            IV = iv;
            FileInputPath = fileInputPath;
            FileOutputPath = fileOutputPath;
            Encrypt = encrypt;
        }
        public string FileInputPath
        {
            get { return fileInputPath; }
            set { fileInputPath = value; }
        }
        public string Key
        {
            get { return key; }
            set { key = value; }
        }
        public string IV
        {
            get { return iv; }
            set { iv = value; }
        }
        public string FileOutputPath
        {
            get { return fileOutputPath; }
            set { fileOutputPath = value; }
        }
        public bool Encrypt
        {
            get { return encrypt; }
            set { encrypt = value; }
        }

    }
}
