using Newtonsoft.Json;
using NLog;


namespace SupportBank
{

    public class Ledger
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        public List<Transaction> Transactions { get; set; }

        public Ledger()
        {
            Transactions = new List<Transaction>();
        }

        public void AddTransaction(Transaction transaction)
        {
            Transactions.Add(transaction);
        }

        public void CSVLoadTransactions(List<string> transactions)
        {

            foreach (var item in transactions)
            {
                string[] record = item.Split(',');
                if (record[0] != "Date")
                {
                    try
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
                    catch (Exception e)
                    {
                        Logger.Error($"[Ledger Error] \n [{item}] \n {e.Message} ");
                    }
                }
            }
        }


        public void JSONLoadTransactions(string jtransactions)
        {
            var convertedJTransactions = JsonConvert.DeserializeObject<List<JTransaction>>(jtransactions);

            foreach (var jtransaction in convertedJTransactions)
            {
                var transaction = new Transaction(
                         jtransaction.Date,
                          new Person(jtransaction.FromAccount),
                           new Person(jtransaction.ToAccount),
                           jtransaction.Narrative,
                           jtransaction.Amount
                          );
                AddTransaction(transaction);
            }
        }
    }
}
