// Submitted by: Andrei N. Capili BSCPE 1-1 (PUP - BC) //
// ACTIVITY #3 - Object Oriented Programming           //
// FINAL PROJECT - CLASS drink OOP REQUIREMENT         //

namespace RefreshmentDrinkSystem
{
    abstract class Drink
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public Drink(string name, int quantity, decimal price)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
        }
    }

    class Juice : Drink
    {
        public Juice(string name, int quantity, decimal price) : base(name, quantity, price)
        {
        }
    }

    class Alcohol : Drink
    {
        public Alcohol(string name, int quantity, decimal price) : base(name, quantity, price)
        {
        }
    }

    class ChilledDrink : Drink
    {
        public ChilledDrink(string name, int quantity, decimal price) : base(name, quantity, price)
        {
        }
    }
}
