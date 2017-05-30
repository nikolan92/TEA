using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A51.ProgramState
{
    [Serializable()]
    public class ProgramState
    {
        private string lastUsedInputPath = null;
        private string lastUsedOutputPath = null;
        private bool fileSytemWather = false;

        public HashSet<string> encryptedFiles;

        public ProgramState()
        {
            encryptedFiles = new HashSet<string>();
            lastUsedInputPath = lastUsedOutputPath = AppDomain.CurrentDomain.BaseDirectory;
        }
        public string LastUsedInputPath
        {
            get
            {
                return lastUsedInputPath;
            }
            set
            {
                lastUsedInputPath = value;
            }
        }
        public string LastUsedOutputPath
        {
            get
            {
                return lastUsedOutputPath;
            }
            set
            {
                lastUsedOutputPath = value;
            }
        }
        public bool FileSystemWatcher
        {
            get
            {
                return fileSytemWather;
            }
            set
            {
                fileSytemWather = value;
            }
        }
    }
}
