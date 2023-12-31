using NLog;

namespace SupportBank
{
    public class FileReader
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        public string Path { get; set; }
        public FileReader(string path)
        {
            Path = path;
        }

        public List<string> CSVReadFile()
        {
            var values = new List<string>();

            StreamReader reader;
            if (File.Exists(Path))
            {
                reader = new StreamReader(File.OpenRead(Path));
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    values.Add(line);
                }
            }
            else
            {
                Logger.Error($"File {Path} does not exist!");
                Console.WriteLine($"Error trying to access transaction file.");
                throw new Exception($"\n\nFile {Path} does not exist\n\n");
            }
            return values;
        }

        public string JSONReadFile()
        {
            string readText = "";

            if (File.Exists(Path))
            {
                readText = File.ReadAllText(Path);
            }
            else
            {
                Logger.Error($"File {Path} does not exist!");
                Console.WriteLine($"Error trying to access transaction file.");
                throw new Exception($"\n\nFile {Path} does not exist\n\n");

            }
            return readText;
        }


    }
}