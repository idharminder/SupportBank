namespace SupportBank
{
    public class FileReader
    {
        public string Path { get; set; }
        public FileReader(string path)
        {
            Path = path;
        }

        public List<string> ReadFile()
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
                throw new Exception($"\n\nFile {Path} does not exist\n\n");
            }
            return values;
        }
    }
}