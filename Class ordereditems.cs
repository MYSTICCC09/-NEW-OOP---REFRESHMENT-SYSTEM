 public class OrderedItem
    {
        public string Name { get; }
        public int Quantity { get; }
        public decimal TotalPrice { get; }

        public OrderedItem(string name, int quantity, decimal totalPrice)
        {
            Name = name;
            Quantity = quantity;
            TotalPrice = totalPrice;
        }
    }
