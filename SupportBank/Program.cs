using SupportBank;

string filePath = @".\Transactions2014.csv";

FileReader myFileReader = new(filePath);
Ledger myLedger = new();
Bank myBank = new();

// reading file into Ledger
foreach (var item in myFileReader.ReadFile())
{
   string[] record = item.Split(',');
   if (record[0] != "Date")
   {
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

// read Ledger and create bank accounts and amounts owed / owe
foreach (var item in myLedger.Transactions)
{
   //Asset "to"
   if (!myBank.Accounts.ContainsKey(item.To.Name))
   {
      myBank.AddAccount(item.To.Name);
      myBank.Accounts[item.To.Name].Assets += item.Amount;
   }
   else
   {
      myBank.Accounts[item.To.Name].Assets += item.Amount;
   }

   //Liabilities "from"

   if (!myBank.Accounts.ContainsKey(item.From.Name))
   {
      myBank.AddAccount(item.From.Name);
      myBank.Accounts[item.From.Name].Liablities += item.Amount;
   }
   else
   {
      myBank.Accounts[item.From.Name].Liablities += item.Amount;
   }
}

// Print out 
Console.WriteLine($"\n===================");
Console.WriteLine($"Customer\tMoney Owed to Them\tMoney They Owe Others");
foreach (var item in myBank.Accounts)
{
   Console.WriteLine($"{item.Key,-10}\t\t{item.Value.Assets:C}\t\t\t{item.Value.Liablities:C}");
}
Console.WriteLine($"===================\n");