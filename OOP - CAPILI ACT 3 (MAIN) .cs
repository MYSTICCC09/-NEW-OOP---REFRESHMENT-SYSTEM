// Submitted by: Andrei N. Capili BSCPE 1-1 (PUP - BC) //
// ACTIVITY #3 - Object Oriented Programming //

using System;
using System.Collections.Generic;

namespace RefreshmentDrinkSystem
{
    public class RefreshmentDrinkSystem
    {
        private List<Drink> Drinks { get; }
        private List<OrderedItem> OrderedItems { get; }
        private Wallet Wallet { get; }

        public RefreshmentDrinkSystem()
        {
            Drinks = new List<Drink>();
            OrderedItems = new List<OrderedItem>();
            Wallet = new Wallet(0);
        }

        public void Run()
        {
            bool exit = false;
            while (!exit)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("==============================");
                Console.WriteLine(" Welcome to Andrei's Refreshment Drink System ");
                Console.WriteLine("==============================");
                Console.ResetColor();

                Console.WriteLine("1. Add Drink");
                Console.WriteLine("2. Remove Drink");
                Console.WriteLine("3. Purchase Drink");
                Console.WriteLine("4. Add Money to Wallet");
                Console.WriteLine("5. View Drinks");
                Console.WriteLine("6. View Ordered Items");
                Console.WriteLine("7. Clear All Drinks");
                Console.WriteLine("8. Exit");
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Enter your choice: ");
                Console.ResetColor();

                string choice = Console.ReadLine();

                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        AddDrink();
                        break;
                    case "2":
                        RemoveItem();
                        break;
                    case "3":
                        PurchaseItems();
                        break;
                    case "4":
                        AddMoneyToWallet();
                        break;
                    case "5":
                        ViewDrinks();
                        break;
                    case "6":
                        ViewOrderedItems();
                        break;
                    case "7":
                        ClearItems();
                        break;
                    case "8":
                        exit = true;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice. Please try again.");
                        Console.ResetColor();
                        break;
                }

                Console.WriteLine();
            }
        }

        private void AddDrink()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter the name of the drink: ");
            Console.ResetColor();
            string name = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter the price of the drink: ");
            Console.ResetColor();
            decimal price = GetValidPositiveNumber();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Is the drink available? (true/false): ");
            Console.ResetColor();
            bool isAvailable = GetValidBoolean();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter the number of drinks available: ");
            Console.ResetColor();
            int numberOfDrinks = GetValidPositiveInteger();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter the description of the drink: ");
            Console.ResetColor();
            string description = Console.ReadLine();

            Drink newDrink = new Drink(name, price, isAvailable, numberOfDrinks, description);
            Drinks.Add(newDrink);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Drink added successfully.");
            Console.ResetColor();
        }

        private void ClearItems()
        {
            Drinks.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("All drinks have been cleared.");
            Console.ResetColor();
        }

        private void RemoveItem()
        {
            if (Drinks.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No drinks available to remove.");
                Console.ResetColor();
                return;
            }

            ViewDrinks();
            int drinkIndex = GetValidDrinkIndex();

            Drinks.RemoveAt(drinkIndex - 1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Drink removed successfully.");
            Console.ResetColor();
        }

        private void ViewDrinks()
        {
            if (Drinks.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No drinks available.");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("======= Drinks =======");
            Console.ResetColor();

            for (int i = 0; i < Drinks.Count; i++)
            {
                Console.WriteLine($"Drink {i + 1}:");
                Console.WriteLine($"Name: {Drinks[i].Name}");
                Console.WriteLine($"Price: {Drinks[i].Price:C}");
                Console.WriteLine($"Availability: {(Drinks[i].IsAvailable ? "Available" : "Not Available")}");
                Console.WriteLine($"Number of Drinks: {Drinks[i].NumberOfDrinks}");
                Console.WriteLine($"Description: {Drinks[i].Description}");
                Console.WriteLine();
            }
        }

        private void PurchaseItems()
        {
            if (Drinks.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No drinks available for purchase.");
                Console.ResetColor();
                return;
            }

            ViewDrinks();
            int drinkIndex = GetValidDrinkIndex();
            Drink selectedDrink = Drinks[drinkIndex - 1];

            if (!selectedDrink.IsAvailable || selectedDrink.NumberOfDrinks == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The selected drink is not available.");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter the quantity to purchase: ");
            Console.ResetColor();
            int quantity = GetValidPositiveInteger();

            if (quantity > selectedDrink.NumberOfDrinks)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Insufficient quantity available.");
                Console.ResetColor();
                return;
            }

            decimal totalCost = selectedDrink.Price * quantity;

            if (totalCost > Wallet.Balance)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Insufficient balance in the wallet.");
                Console.ResetColor();
                return;
            }

            selectedDrink.NumberOfDrinks -= quantity;
            Wallet.Deduct(totalCost);

            OrderedItem orderedItem = new OrderedItem(selectedDrink.Name, quantity, totalCost);
            OrderedItems.Add(orderedItem);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Purchase successful.");
            Console.ResetColor();
        }

        private void ViewOrderedItems()
        {
            if (OrderedItems.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No items ordered.");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("======= Ordered Items =======");
            Console.ResetColor();

            for (int i = 0; i < OrderedItems.Count; i++)
            {
                Console.WriteLine($"Item {i + 1}:");
                Console.WriteLine($"Name: {OrderedItems[i].Name}");
                Console.WriteLine($"Quantity: {OrderedItems[i].Quantity}");
                Console.WriteLine($"Total Price: {OrderedItems[i].TotalPrice:C}");
                Console.WriteLine();
            }
        }

        private void AddMoneyToWallet()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter the amount to add to the wallet: ");
            Console.ResetColor();
            decimal amount = GetValidPositiveNumber();

            Wallet.Add(amount);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Amount added to the wallet successfully.");
            Console.ResetColor();
        }

        private int GetValidPositiveInteger()
        {
            int number;
            while (!int.TryParse(Console.ReadLine(), out number) || number <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a positive integer.");
                Console.ResetColor();
            }
            return number;
        }

        private decimal GetValidPositiveNumber()
        {
            decimal number;
            while (!decimal.TryParse(Console.ReadLine(), out number) || number <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a positive number.");
                Console.ResetColor();
            }
            return number;
        }

        private bool GetValidBoolean()
        {
            bool value;
            while (!bool.TryParse(Console.ReadLine(), out value))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter 'true' or 'false'.");
                Console.ResetColor();
            }
            return value;
        }

        private int GetValidDrinkIndex()
        {
            int index;
            while (!int.TryParse(Console.ReadLine(), out index) || index <= 0 || index > Drinks.Count)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a valid drink index.");
                Console.ResetColor();
            }
            return index;
        }
    }

    public class Drink
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public int NumberOfDrinks { get; set; }
        public string Description { get; set; }

        public Drink(string name, decimal price, bool isAvailable, int numberOfDrinks, string description)
        {
            Name = name;
            Price = price;
            IsAvailable = isAvailable;
            NumberOfDrinks = numberOfDrinks;
            Description = description;
        }
    }

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

    class Program
    {
        static void Main(string[] args)
        {
            RefreshmentDrinkSystem drinkSystem = new RefreshmentDrinkSystem();
            drinkSystem.Run();
        }
    }
}

