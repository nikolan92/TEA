using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A51
{
    public partial class TEA : Form
    {

        FileSystemWatcher fsw;
        string lastAddedFile = "";
        bool keyAndIVStatus = false;
        int programLogCounter = 0;
        public ProgramState.ProgramStateHelper programStateHelper;
        public Label processedFile;
        Bitmap before, after;
        bool isAfter = true;
        bool isTeaEncryption = true;
        Cypher cyper;
        public TEA()
        {
            InitializeComponent();
            this.processedFile = fileNameLbl;
        }

        private void inputLocationBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult dr = fbd.ShowDialog();

            if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                inputLbl.Text = fbd.SelectedPath;

                fsw.Path = fbd.SelectedPath;
                programStateHelper.directoryPathChange();
                programStateHelper.setLastUsedInputPath(fbd.SelectedPath);
            }
        }
        private void outputLocationBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult dr = fbd.ShowDialog();

            if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                outputLbl.Text = fbd.SelectedPath;
                programStateHelper.setLastUsedOutputPath(fbd.SelectedPath);
            }
        }
        private void decryptBtn_Click(object sender, EventArgs e)
        {
            if (!keyAndIVStatus)
            {
                MessageBox.Show("Key is empty or not valid!");
                return;
            }
            //fsw.EnableRaisingEvents = false;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            if(isTeaEncryption)
                openFileDialog1.Filter = "TEA (*.tea)|*.tea";
            else
                openFileDialog1.Filter = "XTEA (*.xtea)|*.xtea";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Multiselect = false;

            DialogResult dResult = openFileDialog1.ShowDialog();
            if ( dResult == DialogResult.OK)
            {
                string filePath = System.IO.Path.GetDirectoryName(openFileDialog1.FileName);
                cyper.addFileForEncryption(new FileProperties(openFileDialog1.FileName, filePath, textBoxKey.Text,textBoxIV.Text, false));
            }
        }
        private void encryptBtn_Click(object sender, EventArgs e)
        {
            if (!keyAndIVStatus)
            {
                MessageBox.Show("Key is empty or not valid!");
                return;
            }

            //fsw.EnableRaisingEvents = false;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            openFileDialog1.Filter = "All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Multiselect = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = System.IO.Path.GetDirectoryName(openFileDialog1.FileName);
                cyper.addFileForEncryption(new FileProperties(openFileDialog1.FileName, filePath, textBoxKey.Text, textBoxIV.Text, true));
            }
        }
        private void fileSystemWatcherCB_CheckedChanged(object sender, EventArgs e)
        {
            if (fileSystemWatcherCB.Checked)
            {
                fsw.EnableRaisingEvents = true;
                programStateHelper.setFileSystemWathcer(true);
            }
            else
            {
                fsw.EnableRaisingEvents = false;
                programStateHelper.setFileSystemWathcer(false);
            }
        }
        private void setupFileSystemWatcher(string folderPath)
        {
            fsw = new FileSystemWatcher();
            fsw.Path = folderPath;

            fsw.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
           | NotifyFilters.FileName | NotifyFilters.DirectoryName;

            fsw.Filter = "*.*";

            fsw.Changed += new FileSystemEventHandler(OnChanged);
            fsw.Created += new FileSystemEventHandler(OnChanged);
            fsw.Deleted += new FileSystemEventHandler(OnDelete);
            fsw.Renamed += new RenamedEventHandler(OnRenamed);
        }
        private void OnDelete(object source, FileSystemEventArgs e)
        {
            programStateHelper.fileDeleted(e.Name);
            lastAddedFile = "";
            this.Invoke((MethodInvoker)delegate
            {
                newProgramLog(e.Name, "Deleted");
            });
        }
        private void OnChanged(object source, FileSystemEventArgs e)
        {
            if (!keyAndIVStatus)
            {
                MessageBox.Show("File with name: \"" + e.Name + "\" has changed externaly, but key is not valid so encryption is aborted!");
                return;
            }
            if(lastAddedFile.Equals(e.Name))
            {
                return;
            }
            lastAddedFile = e.Name;
            //only procceed plaintext files
            if (e.Name.Contains("-TEA_encrypted") || e.Name.Contains("-XTEA_encrypted"))
                return;

            bool ignore;

            cyper.addFileForEncryption(new FileProperties(e.FullPath,programStateHelper.getLastUsedOutputPath(out ignore),textBoxKey.Text, textBoxIV.Text, true));
            
        }
        private void OnRenamed(object source, RenamedEventArgs e)
        {
            programStateHelper.fileNameChanged(e.OldName, e.Name);
            this.Invoke((MethodInvoker)delegate
            {
                newProgramLog(e.Name + " (" + e.OldName + ")", "Renamed");
            });
        }
        private void A51_FormClosing(object sender, FormClosingEventArgs e)
        {
            cyper.stopWatching();
            programStateHelper.saveProgramState();
        }
        private void A51_Load(object sender, EventArgs e)
        {
            cyper = new Cypher(this,programConfig());
            cyper.startWatching();
            textBoxKey.Text = "11110000111010000010001101101001000101001010000101100100100010000111000010001000111000110110100101010100101100010011010010001001";
            textBoxIV.Text =  "1001001010001001101011110110100111110100101000010000010010101001";
            this.FormClosing += new FormClosingEventHandler(A51_FormClosing);
            this.Shown += new EventHandler(A51_Shown);
        }
        //called just after the A51 is shown
        private void A51_Shown(object sender, EventArgs e)
        {
            
            programStateHelper = new ProgramState.ProgramStateHelper();

            bool inputPathIsChanged, outputPathIsChanged;

            string inputPath = programStateHelper.getLastUsedInputPath(out inputPathIsChanged);
            string outputPath = programStateHelper.getLastUsedOutputPath(out outputPathIsChanged);

            inputLbl.Text = inputPath;
            outputLbl.Text = outputPath;
            setupFileSystemWatcher(inputPath);
            fileSystemWatcherCB.Checked = programStateHelper.getFileSystemWatcher();

            if (programStateHelper.getFileSystemWatcher() && !inputPathIsChanged)//if is fileSystemWatcher checked then check all files and encrypt new files
            {
                encryptMultypleFiles();
            }
        }
        private bool programConfig()
        {
            FileSystemHelper fsh = new FileSystemHelper();
            byte[] bytes = fsh.readBytesFromFile("config.txt",false);
            if (bytes != null)
            {
                char[] config = System.Text.Encoding.UTF8.GetString(bytes).ToCharArray();
                if (config[0] == 'T' && config[1] == 'E' && config[2] == 'A')
                {
                    this.Text = "TEA";
                    return true;
                }else if(config[0] == 'X' && config[1] == 'T' && config[2] == 'E' && config[3] == 'A')
                {
                    this.Text = "XTEA";
                    isTeaEncryption = false;
                    return false;
                }
            }
            bytes = new System.Text.UTF8Encoding().GetBytes("TEA");
            fsh.writeBtytesToFile(bytes, 3, "config.txt");
            MessageBox.Show("Configutation file does't exist. Default algorithm for encryption/decryption is TEA.");
            return true;
        }
        private void encryptMultypleFiles()
        {
            bool inputPathIsChanged, outputPathIsChanged;

            string inputPath = programStateHelper.getLastUsedInputPath(out inputPathIsChanged);
            string outputPath = programStateHelper.getLastUsedOutputPath(out outputPathIsChanged);

            if (inputPathIsChanged)
            {
                MessageBox.Show("Input path is not valid anymore!\nInput path is changed to default value (aplication base directory).");
                inputLbl.Text = inputPath;
                return;
            }
            if (outputPathIsChanged)
            {
                MessageBox.Show("Output path is not valid anymore!\nOutput path is changed to Input path (if is valid) or default value (aplication base directory).");
                outputLbl.Text = outputPath;
            }
            DirectoryInfo dinfo = new DirectoryInfo(inputPath);

            FileInfo[] files = dinfo.GetFiles("*.*");

            foreach (FileInfo file in files)
            {
                //if file is't early encrypted or if does't contains string -encrypted or -decrypted then this file is new file
                if (!(programStateHelper.checkFileName(file.Name) || file.Name.Contains("-TEA_encrypted") || file.Name.Contains("-XTEA_encrypted")))
                {
                    KeyForm keyForm = new KeyForm(file.Name);

                    DialogResult dialogResult = keyForm.ShowDialog();
                    if (dialogResult == DialogResult.Ignore)
                    {
                        continue;
                    }
                    else if (dialogResult == DialogResult.OK)
                    {
                        cyper.addFileForEncryption(new FileProperties(file.FullName, outputPath, keyForm.Key, textBoxIV.Text, true));
                    }
                    else
                    {
                        break;
                    }

                }
            }
            
        }
        private void newProgramLog(string fileName, string action)
        {
            programLogCounter++;
            ListViewItem item = new ListViewItem(programLogCounter.ToString());
            item.SubItems.Add(fileName);
            item.SubItems.Add(action);

            programLogLv.Items.Add(item);
        }
        public void newProgramLog(string fileName, string action, long time)
        {
            programLogCounter++;
            ListViewItem item = new ListViewItem(programLogCounter.ToString());
            item.SubItems.Add(fileName);
            item.SubItems.Add(action);
            string timeString;
            if (time < 1000)
                timeString = time.ToString() + "ms";
            else
            {
                time /= 1000;
                timeString = time.ToString() + "s";
            }    
            item.SubItems.Add(timeString);
            programLogLv.Items.Add(item);
        }        
        private void textBoxKey_TextChanged(object sender, EventArgs e)
        {
            if (textBoxKey.Text.All(chr => chr.Equals('0')|| chr.Equals('1')) && !string.IsNullOrEmpty(textBoxKey.Text) && textBoxKey.Text.Length==128)
            {
                keyStatusLbl.ForeColor = Color.Green;
                keyStatusLbl.Text = "Valid.";
                keyAndIVStatus = true;
            }
            else
            {
                keyStatusLbl.ForeColor = Color.Red;
                keyStatusLbl.Text = "Invalid!";
                keyAndIVStatus = false;
            }
        }
        private void textBoxIV_TextChanged(object sender, EventArgs e)
        {
            if (textBoxIV.Text.All(chr => chr.Equals('0') || chr.Equals('1')) && !string.IsNullOrEmpty(textBoxIV.Text) && textBoxIV.Text.Length == 64)
            {
                IVStatusLbl.ForeColor = Color.Green;
                IVStatusLbl.Text = "Valid.";
                keyAndIVStatus = true;
            }
            else
            {
                IVStatusLbl.ForeColor = Color.Red;
                IVStatusLbl.Text = "Invalid!";
                keyAndIVStatus = false;
            }
        }
        private void encryptAllBtn_Click(object sender, EventArgs e)
        {
            if (keyAndIVStatus)
                encryptMultypleFiles();
            else
                MessageBox.Show("Key or IV is not valid!");
        }

        private void encryptImageBtn_Click(object sender, EventArgs e)
        {
            if (!keyAndIVStatus)
            {
                MessageBox.Show("Key is empty or not valid!");
                return;
            }

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            openFileDialog1.Filter = "BMP (*.bmp)|*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Multiselect = false;

            DialogResult dResult = openFileDialog1.ShowDialog();
            if (dResult == DialogResult.OK)
            {
                before = LoadBitmap(openFileDialog1.FileName);

                string filePath = System.IO.Path.GetDirectoryName(openFileDialog1.FileName);
                string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(openFileDialog1.FileName);

                FileSystemHelper fsh = new FileSystemHelper();
                byte[] imgInBytes = fsh.readBytesFromFile(openFileDialog1.FileName, false);
                TeaAndXteaAlgorithm encrypt = new TeaAndXteaAlgorithm(textBoxKey.Text, textBoxIV.Text);
                long time;
                if (isTeaEncryption)
                {
                    string newFilleNameAndPath = filePath + "\\" + fileNameWithoutExtension + "-TEA_encrypted.bmp";
                    imgInBytes = encrypt.teaEncrypt(imgInBytes, true, out time);
                    fsh.writeBtytesToFile(imgInBytes, imgInBytes.Length, newFilleNameAndPath);
                    after = LoadBitmap(newFilleNameAndPath);
                }
                else
                {
                    string newFilleNameAndPath = filePath + "\\" + fileNameWithoutExtension + "-XTEA_encrypted.bmp";
                    imgInBytes = encrypt.xteaEncrypt(imgInBytes, true, out time);
                    fsh.writeBtytesToFile(imgInBytes, imgInBytes.Length, newFilleNameAndPath);
                    after = LoadBitmap(newFilleNameAndPath);
                }
                newProgramLog(fileNameWithoutExtension + ".bmp", "Encrypt", time);
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Image = after;
                beforeAfterLbl.Text = "After";
                isAfter = true;
            }
        }
        private void decryptImageBtn_Click(object sender, EventArgs e)
        {
            if (!keyAndIVStatus)
            {
                MessageBox.Show("Key is empty or not valid!");
                return;
            }
           
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            openFileDialog1.Filter = "BMP (*.bmp)|*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Multiselect = false;

            DialogResult dResult = openFileDialog1.ShowDialog();
            if (dResult == DialogResult.OK)
            {
                before = LoadBitmap(openFileDialog1.FileName);

                string filePath = System.IO.Path.GetDirectoryName(openFileDialog1.FileName);
                string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(openFileDialog1.FileName);

                FileSystemHelper fsh = new FileSystemHelper();
                byte[] imgInBytes = fsh.readBytesFromFile(openFileDialog1.FileName, false);
                TeaAndXteaAlgorithm decrypt = new TeaAndXteaAlgorithm(textBoxKey.Text, textBoxIV.Text);
                long time;
                if (isTeaEncryption)
                {
                    string newFilleNameAndPath = filePath + "\\" + fileNameWithoutExtension + "-TEA_decrypted.bmp";
                    imgInBytes = decrypt.teaDecrypt(imgInBytes, true, out time);
                    fsh.writeBtytesToFile(imgInBytes, imgInBytes.Length,newFilleNameAndPath);
                    after = LoadBitmap(newFilleNameAndPath);
                }
                else
                {
                    string newFilleNameAndPath = filePath + "\\" + fileNameWithoutExtension + "-XTEA_decrypted.bmp";
                    imgInBytes = decrypt.xteaDecrypt(imgInBytes, true, out time);
                    fsh.writeBtytesToFile(imgInBytes, imgInBytes.Length, newFilleNameAndPath);
                    after = LoadBitmap(newFilleNameAndPath);
                }
                newProgramLog(fileNameWithoutExtension+".bmp", "Decrypt", time);
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Image = after;
                beforeAfterLbl.Text = "After";
                isAfter = true;
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            if (after != null && before != null)
                if (isAfter)
                {
                    beforeAfterLbl.Text = "Before";
                    pictureBox.Image = before;
                    isAfter = false;
                }
                else
                {
                    beforeAfterLbl.Text = "After";
                    pictureBox.Image = after;
                    isAfter = true;
                }
        }
        public static Bitmap LoadBitmap(string path)
        {
            using (Bitmap original = new Bitmap(path))
            {
                return new Bitmap(original);
            }
        }
    }
}
