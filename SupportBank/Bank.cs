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

        public void ProcessLedger(Ledger ledger)
        {

            foreach (var item in ledger.Transactions)
            {
                //Asset "to"
                if (!Accounts.ContainsKey(item.To.Name))
                {
                    AddAccount(item.To.Name);
                    Accounts[item.To.Name].Assets += item.Amount;
                }
                else
                {
                    Accounts[item.To.Name].Assets += item.Amount;
                }

                //Liabilities "from"

                if (!Accounts.ContainsKey(item.From.Name))
                {
                    AddAccount(item.From.Name);
                    Accounts[item.From.Name].Liablities += item.Amount;
                }
                else
                {
                    Accounts[item.From.Name].Liablities += item.Amount;
                }
            }

        }







    }
}