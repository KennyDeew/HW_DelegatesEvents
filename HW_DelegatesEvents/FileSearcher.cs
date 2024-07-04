namespace HW_DelegatesEvents
{
    public class FileSearcher
    {
        public string FilesDirectory { get; set; }

        public string[] FilePaths { get; set; }

        public bool StopSearch { get; set; }
        
        public event EventHandler FileFoundEvent;

        public void OnFileFound(FileArgs e)
        {
            FileFoundEvent?.Invoke(this, e);
        }

        public FileSearcher(string filesDirectory)
        {
            StopSearch = false;
            FilesDirectory = filesDirectory;
            if (FilesDirectory != string.Empty)
            {
                FilePaths = GetFiles();
            }
        }

        public void StartSearch()
        {
            int FileNumber = 0;
            if (FilePaths != null)
            {
                foreach (var filePath in FilePaths)
                {
                    if (StopSearch)
                    {
                        return;
                    }
                    if (File.Exists(filePath))
                    {
                        OnFileFound(new FileArgs(filePath));
                        FileNumber++;
                    }
                    
                }
            }
        }

        private string[]? GetFiles()
        {
            return Directory.GetFiles(FilesDirectory);
        }
    }
}
