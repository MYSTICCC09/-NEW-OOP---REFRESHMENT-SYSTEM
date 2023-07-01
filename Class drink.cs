public class Drink
    {
        public string Name { get; }
        public decimal Price { get; }
        public bool IsAvailable { get; }
        public int NumberOfDrinks { get; }
        public string Description { get; }

        public Drink(string name, decimal price, bool isAvailable, int numberOfDrinks, string description)
        {
            Name = name;
            Price = price;
            IsAvailable = isAvailable;
            NumberOfDrinks = numberOfDrinks;
            Description = description;
        }
    }
