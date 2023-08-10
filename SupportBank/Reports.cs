using NLog;

namespace SupportBank
{
    public class Reports
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        public static void AllReport(Bank bank)
        {
            Console.WriteLine($"\n===================");
            Console.WriteLine($"Customer\tMoney Owed to Them\tMoney They Owe Others");
            foreach (var item in bank.Accounts)
            {
                Console.WriteLine($"{item.Key,-10}\t\t{item.Value.Assets:C}\t\t\t{item.Value.Liablities:C}");
            }
            Console.WriteLine($"===================\n");
            Logger.Info("All Report Created.");

        }

        public static void CustomerReport(Ledger ledger, Bank bank)
        {
            bool validCustomer = false;
            string accountName;
            do
            {
                Console.WriteLine("Enter Account Name:");
                accountName = Console.ReadLine();
                validCustomer = bank.Accounts.ContainsKey(accountName);
            } while (!validCustomer);

            ledger.Transactions
            .Where(t => t.From.Name == accountName || t.To.Name == accountName)
            .ToList()
            .ForEach(t => Console.WriteLine($"{t.Date:d}\t{t.From.Name,-10}\t{t.To.Name,-10}\t{t.Narrative,-25}\t{t.Amount:C}"));
            Logger.Info("Customer Report Created.");
        }


    }
}