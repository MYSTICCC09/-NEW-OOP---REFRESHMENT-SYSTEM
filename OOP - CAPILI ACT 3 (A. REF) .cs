// NOTE: PLEASE PROCEED TO THE NEXT .CS FILE PO, THANK YOU! // 

// Submitted by: Andrei N. Capili BSCPE 1-1 (PUP - BC) //
// ACTIVITY #3 - Object Oriented Programming //

using System;
using System.Collections.Generic;

namespace VendingMachine
{
    class Program
    {
        static VendingMachine vendingMachine;

        static void Main()
        {
            vendingMachine = new VendingMachine();
            CreateDummyData();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("==============================================");
            Console.WriteLine("    Welcome to Andrei's Refreshment Drink System    ");
            Console.WriteLine("==============================================");
            Console.ResetColor();

            Console.WriteLine("1. Display Inventory");
            Console.WriteLine("2. Purchase Drink");
            Console.WriteLine("3. Add Funds");
            Console.WriteLine("4. Return Change");
            Console.WriteLine("0. Exit");

            string userInput = GetUserInput();

            while (userInput != "0")
            {
                switch (userInput)
                {
                    case "1":
                        DisplayInventory();
                        break;
                    case "2":
                        PurchaseDrink();
                        break;
                    case "3":
                        AddFunds();
                        break;
                    case "4":
                        ReturnChange();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine("\nEnter your choice:");
                userInput = GetUserInput();
            }
        }

        private static void DisplayInventory()
        {
            List<Drink> drinks = vendingMachine.GetDrinks();

            Console.WriteLine("\n==========================================================");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("                         INVENTORY");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("============================================================");
            Console.WriteLine("   Good day sir!, eto po yung ating mga inumin na available ");
            Console.WriteLine("============================================================");
            Console.ResetColor();

            Console.WriteLine("============================================================");
            Console.WriteLine("      NAME                TYPE            QUANTITY");
            Console.WriteLine("------------------------------------------------------------");

            foreach (Drink drink in drinks)
            {
                string type = drink.GetType().Name;
                Console.WriteLine($"{drink.Name,-25} {type,-15} {drink.Quantity}");
            }

            Console.WriteLine("===============================================");
        }

        private static string GetUserInput()
        {
            Console.Write("\nUser input > ");
            return Console.ReadLine();
        }

        private static void PurchaseDrink()
        {
            Console.Write("\nEnter the name of the drink you want to buy: ");
            string drinkName = GetUserInput();

            Console.Write("Enter the quantity: ");
            int quantity = int.Parse(GetUserInput());

            decimal totalPrice = vendingMachine.PurchaseDrink(drinkName, quantity);

            if (totalPrice > 0)
            {
                Console.WriteLine("\n===============================================");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("  Purchase successful!");
                Console.ResetColor();
                Console.WriteLine($"  Total Price: {totalPrice:C}");
                Console.WriteLine("===============================================");
            }
            else
            {
                Console.WriteLine("\nDrink not available or insufficient quantity.");
            }
        }

        private static void AddFunds()
        {
            Console.Write("\nEnter the amount to add: ");
            decimal amount = decimal.Parse(GetUserInput());

            vendingMachine.AddFunds(amount);

            Console.WriteLine("\n====================================================");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"  Funds added successfully. Current balance: {vendingMachine.GetBalance():C}");
            Console.ResetColor();
            Console.WriteLine("====================================================");
        }

        private static void ReturnChange()
        {
            decimal change = vendingMachine.ReturnChange();

            Console.WriteLine("\n===============================================");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"  Change returned: {change:C}");
            Console.ResetColor();
            Console.WriteLine("===============================================");
        }

        static void CreateDummyData()
        {
            vendingMachine.AddDrink(new Juice("Tropical Tango-Mango",                75, 2.50m));
            vendingMachine.AddDrink(new Juice("Iced Blended Calamansi",              50, 1.75m));
            vendingMachine.AddDrink(new Juice("Lemonade",                            90, 1.25m));
            vendingMachine.AddDrink(new Juice("Green Tea",                           60, 1.50m));
            vendingMachine.AddDrink(new Juice("Grapefruit      ",                    125, 2.00m));
            vendingMachine.AddDrink(new Juice("Blueberry Lemonade",                  130, 2.25m));

            vendingMachine.AddDrink(new Alcohol("Whiskey",                           30, 10.00m));
            vendingMachine.AddDrink(new Alcohol("Vodka",                             40, 8.50m));
            vendingMachine.AddDrink(new Alcohol("Rum",                               25, 9.75m));
            vendingMachine.AddDrink(new Alcohol("Tequila",                           35, 9.00m));

            vendingMachine.AddDrink(new ChilledDrink("Iced Coffee",                  120, 2.00m));
            vendingMachine.AddDrink(new ChilledDrink("Strawberry Shake",             85, 2.25m));
            vendingMachine.AddDrink(new ChilledDrink("Chocolate Milk",               70, 1.75m));
            vendingMachine.AddDrink(new ChilledDrink("Mint Mojito",                  70, 1.50m));
            vendingMachine.AddDrink(new ChilledDrink("Watermelon Slush",             150, 2.50m));
            vendingMachine.AddDrink(new ChilledDrink("Mango Lassi",                  200, 3.00m));
        }
    }

    class VendingMachine
    {
        private List<Drink> drinks;
        private decimal balance;

        public VendingMachine()
        {
            drinks = new List<Drink>();
            balance = 0;
        }

        public void AddDrink(Drink drink)
        {
            drinks.Add(drink);
        }

        public List<Drink> GetDrinks()
        {
            return drinks;
        }

        public decimal PurchaseDrink(string drinkName, int quantity)
        {
            Drink drink = drinks.Find(d => d.Name == drinkName);

            if (drink != null && drink.Quantity >= quantity)
            {
                decimal totalPrice = drink.Price * quantity;
                if (balance >= totalPrice)
                {
                    drink.Quantity -= quantity;
                    balance -= totalPrice;
                    return totalPrice;
                }
            }

            return 0;
        }

        public void AddFunds(decimal amount)
        {
            balance += amount;
        }

        public decimal GetBalance()
        {
            return balance;
        }

        public decimal ReturnChange()
        {
            decimal change = balance;
            balance = 0;
            return change;
        }
    }

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
