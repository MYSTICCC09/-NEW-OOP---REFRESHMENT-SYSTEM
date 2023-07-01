public class Wallet
    {
        public decimal Balance { get; private set; }

        public Wallet(decimal initialBalance)
        {
            Balance = initialBalance;
        }

        public void Add(decimal amount)
        {
            Balance += amount;
        }

        public void Deduct(decimal amount)
        {
            Balance -= amount;
        }
    }
