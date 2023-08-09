namespace SupportBank
{
    public class Bank
    {
        public Dictionary<string, Account> Accounts { get; set; }

        public Bank()
        {
            Accounts = new Dictionary<string, Account>();
        }

        public void AddAccount(string accountName)
        {
            Accounts[accountName] = new Account(new Person(accountName));
        }
    }
}