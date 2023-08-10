namespace SupportBank
{
    public class Reports
    {
        public static void AllReport(Bank bank)
        {
            Console.WriteLine($"\n===================");
            Console.WriteLine($"Customer\tMoney Owed to Them\tMoney They Owe Others");
            foreach (var item in bank.Accounts)
            {
                Console.WriteLine($"{item.Key,-10}\t\t{item.Value.Assets:C}\t\t\t{item.Value.Liablities:C}");
            }
            Console.WriteLine($"===================\n");
        }

        public static void CustomerReport(Ledger ledger, string accountName)
        {
            ledger.Transactions
            .Where(t => t.From.Name == accountName || t.To.Name == accountName)
            .ToList()
            .ForEach(t => Console.WriteLine($"{t.Date:d}\t{t.From.Name,-10}\t{t.To.Name,-10}\t{t.Narrative,-25}\t{t.Amount:C}"));
        }
    }
}