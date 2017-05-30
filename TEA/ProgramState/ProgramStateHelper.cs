using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace A51.ProgramState
{
    public class ProgramStateHelper
    {
        private ProgramState programState;

        public ProgramStateHelper()
        {
            loadProgramState();
        }

        private void loadProgramState()
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("ProgramState.bin",
                              FileMode.Open,
                              FileAccess.Read,
                              FileShare.Read);
                programState = (ProgramState)formatter.Deserialize(stream);
                stream.Close();
            }
            catch (FileNotFoundException)
            {
                programState = new ProgramState();
            }
        }
        public void saveProgramState()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("ProgramState.bin",
                                     FileMode.Create,
                                     FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, programState);
            stream.Close();
        }

        public void fileNameChanged(string oldName, string newName)
        {
            programState.encryptedFiles.Remove(oldName);
            programState.encryptedFiles.Add(newName);
        }
        public void addEncryptedFile(string fileName)
        {
            programState.encryptedFiles.Add(fileName);
        }
        public void fileDeleted(string fileName)
        {
            programState.encryptedFiles.Remove(fileName);
        }
        public bool checkFileName(string fileName)
        {
            return programState.encryptedFiles.Contains(fileName);
        }
        public void setLastUsedInputPath(string path)
        {
            programState.LastUsedInputPath = path;
        }
        public void setLastUsedOutputPath(string path)
        {
            programState.LastUsedOutputPath = path;
        }
        public string getLastUsedInputPath(out bool inputPathIsChanged)
        {
            if (Directory.Exists(programState.LastUsedInputPath))
            {
                inputPathIsChanged = false;
                return programState.LastUsedInputPath;
            }
            else
            {
                programState.LastUsedInputPath = AppDomain.CurrentDomain.BaseDirectory;
                inputPathIsChanged = true;
                return programState.LastUsedInputPath;
            }
        }
        public string getLastUsedOutputPath(out bool outputPathIsChanged)
        {
            if (Directory.Exists(programState.LastUsedOutputPath))
            {
                outputPathIsChanged = false;
                return programState.LastUsedOutputPath;
            }
            else if (Directory.Exists(programState.LastUsedInputPath))
            {
                outputPathIsChanged = true;
                programState.LastUsedOutputPath = programState.LastUsedInputPath;
                return programState.LastUsedOutputPath;
            }
            else
            {
                programState.LastUsedOutputPath = AppDomain.CurrentDomain.BaseDirectory;
                outputPathIsChanged = true;
                return programState.LastUsedOutputPath;
            }
        }
        public void setFileSystemWathcer(bool isOn)
        {
            programState.FileSystemWatcher = isOn;
        }
        public bool getFileSystemWatcher()
        {
            return programState.FileSystemWatcher;
        }
        public void directoryPathChange()
        {
            programState.encryptedFiles.Clear();
        }
    }
}
