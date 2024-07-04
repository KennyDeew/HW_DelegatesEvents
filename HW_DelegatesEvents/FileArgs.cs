namespace HW_DelegatesEvents
{
    public class FileArgs : EventArgs
    {
        public string FilePath { get; set; }

        public FileArgs(string filePath)
        {
            FilePath = filePath;
        }
    }
}
