namespace SupportBank
{
    public class Transaction
    {
        public DateTime Date { get; set; }
        public Person FromAccount { get; set; }
        public Person ToAccount { get; set; }
        public string Narrative { get; set; }
        public decimal Amount { get; set; }

        public Transaction(DateTime date, Person from, Person to, string narrative, decimal amount)
        {
            Date = date;
            FromAccount = from;
            ToAccount = to;
            Narrative = narrative;
            Amount = amount;
        }
    }
}