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
         bool validCustomer = false;
         string accountName;
         do
         {
            Console.WriteLine("Enter Account Name:");
            accountName = Console.ReadLine();
            validCustomer = myBank.Accounts.ContainsKey(accountName);
         } while (!validCustomer);
         Reports.CustomerReport(myLedger, accountName);
         break;
      case Option.Exit:
         loop = false;
         break;
   }
}





