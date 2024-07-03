using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_DelegatesEvents
{
    public class FileSearcher
    {
        public string FilesDirectory { get; set; }

        public string[] FilePaths { get; set; }

        public event EventHandler FileFound;

        public void OnFileFound(FileArgs e)
        {
            FileFound?.Invoke(this, e);
        }

        public FileSearcher(string filesDirectory)
        {
            FilesDirectory = filesDirectory;
            FilePaths = GetFiles();
        }

        public void StartSearch()
        {
            foreach (var filePath in FilePaths)
            {
                if (File.Exists(filePath))
                {
                    OnFileFound(new FileArgs(filePath));
                }
            }
        }

        private string[]? GetFiles()
        {
            return Directory.GetFiles(FilesDirectory);
        }
    }
}
