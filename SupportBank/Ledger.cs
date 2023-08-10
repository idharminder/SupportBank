namespace SupportBank
{
    public class Ledger
    {
        public List<Transaction> Transactions { get; set; }

        public Ledger()
        {
            Transactions = new List<Transaction>();
        }

        public void AddTransaction(Transaction transaction)
        {
            Transactions.Add(transaction);
        }

        public void LoadTransctions(List<string> transactions)
        {
            foreach (var item in transactions)
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
                    AddTransaction(transaction);
                }
            }
        }
    }
}