
using SupportBank;
using NLog;
using NLog.Config;
using NLog.Targets;

var config = new LoggingConfiguration();
var target = new FileTarget { FileName = @"C:\Users\ArdKur\Training\SupportBank\SupportBank\SupportBank.log", Layout = @"${longdate} ${level} - ${logger}: ${message}" };
config.AddTarget("File Logger", target);
config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, target));
LogManager.Configuration = config;

// string filePath = @".\Transactions2014.csv";
string filePath = @".\DodgyTransactions2015.csv";

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
      Console.WriteLine("Welcome to Support Bank! Choose From Following Options \n0) Exit\n1) All Reports\n2) Customer Report\n");
   } while (!Enum.TryParse(Console.ReadLine(), out option));

   switch (option)
   {
      case Option.AllReport:
         Reports.AllReport(myBank);
         break;
      case Option.CustomerReport:

         Reports.CustomerReport(myLedger, myBank);
         break;
      case Option.Exit:
         loop = false;
         break;
   }
}














