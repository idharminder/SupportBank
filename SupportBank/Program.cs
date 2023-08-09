// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string fullFilePath = @"C:\Training\SupportBank\SupportBank\TransactionsShort.csv";
// string fullFilePath = @"C:\Training\SupportBank\SupportBank\Transactions2014.csv";
// string shortFilePath = @".\SupportBank\Transactions2014.csv";

var values = new List<string>();


StreamReader reader = null;
      if (File.Exists(fullFilePath)){
         reader = new StreamReader(File.OpenRead(fullFilePath));
         List<string> listA = new List<string>();
         while (!reader.EndOfStream){
            var line = reader.ReadLine();
            values.Add(line);
         }
      } else {
         Console.WriteLine("File doesn't exist");
      }
      Console.WriteLine(values.Count);