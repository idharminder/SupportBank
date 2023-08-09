namespace SupportBank
{
    public class Ledger {
        public List<Transaction> Transactions { get; set; }

        public Ledger(){
            Transactions = new List<Transaction>();
        }

        public void AddTransaction(Transaction transaction){
            Transactions.Add(transaction);
        }
    } 
}