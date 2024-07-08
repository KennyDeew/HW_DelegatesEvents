namespace HW_DelegatesEvents
{
    public class Subscriber
    {
        private string StopFileName { get; set; }

        public Subscriber(string stopFileName)
        {
            StopFileName = stopFileName;
        }

        public void Onrecieved(object? sender, FileArgs e)
        {
            Console.WriteLine($"Recieved founded file: {e.FilePath}");
            if (StopFileName != null && sender is FileSearcher fileSearcher && StopFileName == e.FilePath)
            {
                fileSearcher.StopSearch = true;
            }

        }
    }
}
