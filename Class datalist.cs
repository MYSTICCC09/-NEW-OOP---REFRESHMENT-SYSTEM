public class RefreshmentDrinkSystem
    {
        public List<Drink> Drinks { get; }
        public List<OrderedItem> OrderedItems { get; }
        public Wallet Wallet { get; }

        public RefreshmentDrinkSystem()
        {
            Drinks = new List<Drink>();
            OrderedItems = new List<OrderedItem>();
            Wallet = new Wallet(0);
        }
    }
