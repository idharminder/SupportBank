namespace SupportBank
{
    public class Account
    {
        public Person Person { get; set; }
        public decimal Assets { get; set; }
        public decimal Liablities { get; set; }

        public Account(Person person)
        {
            Person = person;
            Assets = 0m;
            Liablities = 0m;
        }
    }
}