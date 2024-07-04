    namespace HW_DelegatesEvents
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileSelection = "C:\\Users\\Машина\\Documents\\FileColection\\";
            //Имя файла при нахождении которого Подписчик события отменяет дальнейший поиск файлов
            string stopFileName = fileSelection + "3.txt";
            var fileSearcher = new FileSearcher(fileSelection);
            Subscriber subscriber = new Subscriber(stopFileName);
            fileSearcher.FileFoundEvent += subscriber.Onrecieved;
            fileSearcher.StartSearch();
            //В конце отписываемся от собития
            fileSearcher.FileFoundEvent -= subscriber.Onrecieved;

            //Ищем максимальный файл
            Func<string, float> convertDelegate = ConverterToNumber.convertToNumber;
            GetMaxFile(fileSearcher.FilePaths, convertDelegate);
        }

        private static void GetMaxFile(string[] filePaths, Func<string, float> convertDelegate)
        {
            string maxFilePath = CollectionHandler.GetMax<string>(filePaths, convertDelegate);
            Console.WriteLine($"Max file: {maxFilePath}");
        }
    }


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
