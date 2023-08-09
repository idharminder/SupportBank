namespace SupportBank
{
    public class Transaction
    {
        public DateTime Date { get; set; }
        public Person From { get; set; }
        public Person To { get; set; }
        public string Narrative { get; set; }
        public decimal Amount { get; set; }

        public Transaction(DateTime date, Person from, Person to, string narrative, decimal amount)
        {
            Date = date;
            From = from;
            To = to;
            Narrative = narrative;
            Amount = amount;
        }
    }



}