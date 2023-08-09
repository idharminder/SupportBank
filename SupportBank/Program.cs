using SupportBank;

Console.WriteLine("Hello, World!");

string fullFilePath = @"C:\Training\SupportBank\SupportBank\TransactionsShort.csv";
// string shortFilePath = @".\TransactionsShort.csv";
// string fullFilePath = @"C:\Training\SupportBank\SupportBank\Transactions2014.csv";
// string shortFilePath = @".\Transactions2014.csv";

  FileReader myFileReader = new (fullFilePath);
  Ledger myLedger = new();
  
  foreach (var item in myFileReader.ReadFile())
  {
    string[] record = item.Split(',');
    if (record[0] != "Date"){
      var transaction = new Transaction(
        DateTime.Parse(record[0]),
         new Person(record[1]),
          new Person(record[2]),
          record[3],
          Decimal.Parse(record[4])
         );
         myLedger.AddTransaction(transaction);
    }
  }

  foreach (var item in myLedger.Transactions)
  {
   Console.WriteLine($"{item.Amount:C}");
  }