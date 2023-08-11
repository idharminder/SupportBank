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
                if (!Accounts.ContainsKey(item.ToAccount.Name))
                {
                    AddAccount(item.ToAccount.Name);
                    Accounts[item.ToAccount.Name].Assets += item.Amount;
                }
                else
                {
                    Accounts[item.ToAccount.Name].Assets += item.Amount;
                }

                //Liabilities "from"

                if (!Accounts.ContainsKey(item.FromAccount.Name))
                {
                    AddAccount(item.FromAccount.Name);
                    Accounts[item.FromAccount.Name].Liablities += item.Amount;
                }
                else
                {
                    Accounts[item.FromAccount.Name].Liablities += item.Amount;
                }
            }

        }







    }
}