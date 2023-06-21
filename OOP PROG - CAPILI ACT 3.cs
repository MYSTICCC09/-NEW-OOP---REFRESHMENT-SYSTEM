

using System;

namespace RefreshmentDrinkSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the RefreshmentDrinkSystem class
            RefreshmentDrinkSystem refreshmentDrinkSystem = new RefreshmentDrinkSystem();

            // Add items to the menu
            refreshmentDrinkSystem.Add("Cola", 1.99, 10);
            refreshmentDrinkSystem.Add("Lemonade", 1.49, 5);
            refreshmentDrinkSystem.Add("Iced Tea", 2.29, 8);

            // Display the menu
            refreshmentDrinkSystem.DisplayMenu();

            // Order drinks
            refreshmentDrinkSystem.OrderDrink("Cola", 2);
            refreshmentDrinkSystem.OrderDrink("Iced Tea", 1);

            // Display the ordered items
            refreshmentDrinkSystem.DisplayOrderedItems();

            // Calculate and display the total price
            double totalPrice = refreshmentDrinkSystem.CalculateTotalPrice();
            Console.WriteLine($"Total Price: {totalPrice}");

            // Remove an item from the menu
            refreshmentDrinkSystem.Remove("Lemonade");

            // Display the updated menu
            refreshmentDrinkSystem.DisplayMenu();
        }
    }

    class RefreshmentDrinkSystem
    {
        class Drink
        {
            public string Name { get; set; }
            public double Price { get; set; }
            public int Availability { get; set; }

            public Drink(string name, double price, int availability)
            {
                Name = name;
                Price = price;
                Availability = availability;
            }
        }

        private List<Drink> menu;
        private List<Drink> orderedItems;

        public RefreshmentDrinkSystem()
        {
            menu = new List<Drink>();
            orderedItems = new List<Drink>();
        }

        public void Add(string name, double price, int availability)
        {
            Drink newDrink = new Drink(name, price, availability);
            menu.Add(newDrink);
        }

        public void Clear()
        {
            menu.Clear();
        }

        public void Remove(string name)
        {
            Drink drinkToRemove = menu.Find(drink => drink.Name == name);
            if (drinkToRemove != null)
            {
                menu.Remove(drinkToRemove);
            }
        }

        public void DisplayMenu()
        {
            Console.WriteLine("MENU:");
            foreach (Drink drink in menu)
            {
                Console.WriteLine($"{drink.Name} - Price: {drink.Price:C} - Availability: {drink.Availability}");
            }
        }

        public void OrderDrink(string name, int quantity)
        {
            Drink drink = menu.Find(d => d.Name == name);
            if (drink != null)
            {
                if (drink.Availability >= quantity)
                {
                    drink.Availability -= quantity;
                    orderedItems.Add(new Drink(drink.Name, drink.Price, quantity));
                }
                else
                {
                    Console.WriteLine("Insufficient availability for the selected drink.");
                }
            }
            else
            {
                Console.WriteLine("Drink not found in the menu.");
            }
        }

        public void DisplayOrderedItems()
        {
            Console.WriteLine("ORDERED ITEMS:");
            foreach (Drink drink in orderedItems)
            {
                Console.WriteLine($"{drink.Name} - Quantity: {drink.Availability} - Price: {drink.Price * drink.Availability:C}");
            }
        }

        public double CalculateTotalPrice()
        {
            double total = 0;
            foreach (Drink drink in orderedItems)
            {
                total += drink.Price * drink.Availability;
            }
            return total;
        }
    }
}
