using SupportBank;

string filePath = @".\Transactions2014.csv";

FileReader myFileReader = new(filePath);
Ledger myLedger = new();
Bank myBank = new();

myLedger.LoadTransctions(myFileReader.ReadFile());
myBank.ProcessLedger(myLedger);

bool loop = true;
Option option;
while (loop)
{
   do
   {
      Console.WriteLine("Enter something");
   } while (!Enum.TryParse(Console.ReadLine(), out option));

   switch (option)
   {
      case Option.AllReport:
         Reports.AllReport(myBank);
         break;
      case Option.CustomerReport:
         Console.WriteLine("add customer report logic");
         break;
      case Option.Exit:
         loop = false;
         break;
   }
}



