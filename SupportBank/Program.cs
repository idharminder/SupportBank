using SupportBank;

string filePath = @".\Transactions2014.csv";

FileReader myFileReader = new(filePath);
Ledger myLedger = new();
Bank myBank = new();

myLedger.LoadTransctions(myFileReader.ReadFile());
myBank.ProcessLedger(myLedger);

Reports.AllReport(myBank);