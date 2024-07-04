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
            Func<string, float> convertToFloatDelegate = ConverterToNumber.convertToNumber;
            GetMaxFile(fileSearcher.FilePathArr, convertToFloatDelegate);
        }

        private static void GetMaxFile(string[] FilePathArr, Func<string, float> convertToFloatDelegate)
        {
            string maxFilePath = CollectionHandler.GetMax<string>(FilePathArr, convertToFloatDelegate);
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
