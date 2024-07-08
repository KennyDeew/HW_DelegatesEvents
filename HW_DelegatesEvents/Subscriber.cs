namespace HW_DelegatesEvents
{
    public class Subscriber
    {
        private string StopFileName { get; set; }

        public Subscriber(string stopFileName)
        {
            StopFileName = stopFileName;
        }

        public void Onrecieved(object? sender, EventArgs e)
        {
            if (e is FileArgs fileArgs)
            {
                Console.WriteLine($"Recieved founded file: {fileArgs.FilePath}");
                if (StopFileName != null && sender is FileSearcher fileSearcher && StopFileName == fileArgs.FilePath)
                {
                    fileSearcher.StopSearch = true;
                }
            }
            else
            {
                Console.WriteLine($"Recieved founded file.");
            }

        }
    }
}
