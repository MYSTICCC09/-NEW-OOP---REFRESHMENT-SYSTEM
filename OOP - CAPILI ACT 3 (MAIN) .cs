// NOTE: MAIN PROGRAM FOR MY CLASS (Program.cs) //

// Submitted by: Andrei N. Capili BSCPE 1-1 (PUP - BC) //
// ACTIVITY #3 - Object Oriented Programming //
// CLASS //

using System;
using System.Collections.Generic;

namespace RefeshmentDrinkSystem
{
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

    class Program
    {
        static RefreshmentDrinkSystem drinkSystem = new RefreshmentDrinkSystem();

        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("==============================================");
                Console.WriteLine(" Welcome to Andrei's Refreshment Drink System ");
                Console.WriteLine("==============================================");
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

                string choice = Console.ReadLine() ?? string.Empty;

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

        static void AddDrink()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter the name of the drink: ");
            Console.ResetColor();
            string name = Console.ReadLine() ?? string.Empty;

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
            string description = Console.ReadLine() ?? string.Empty;

            Drink newDrink = new Drink(name, price, isAvailable, numberOfDrinks, description);
            drinkSystem.Drinks.Add(newDrink);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Drink added successfully.");
            Console.ResetColor();
        }

        static void ClearItems()
        {
            drinkSystem.Drinks.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("All drinks have been cleared.");
            Console.ResetColor();
        }

        static void RemoveItem()
        {
            if (drinkSystem.Drinks.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No drinks available to remove.");
                Console.ResetColor();
                return;
            }

            ViewDrinks();
            int drinkIndex = GetValidDrinkIndex();

            drinkSystem.Drinks.RemoveAt(drinkIndex - 1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Drink removed successfully.");
            Console.ResetColor();
        }

        static void ViewDrinks()
        {
            if (drinkSystem.Drinks.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No drinks available.");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("======= Drinks =======");
            Console.ResetColor();

            for (int i = 0; i < drinkSystem.Drinks.Count; i++)
            {
                Console.WriteLine($"Drink {i + 1}:");
                Console.WriteLine($"Name: {drinkSystem.Drinks[i].Name}");
                Console.WriteLine($"Price: {drinkSystem.Drinks[i].Price:C}");
                Console.WriteLine($"Availability: {(drinkSystem.Drinks[i].IsAvailable ? "Available" : "Not Available")}");
                Console.WriteLine($"Number of Drinks: {drinkSystem.Drinks[i].NumberOfDrinks}");
                Console.WriteLine($"Description: {drinkSystem.Drinks[i].Description}");
                Console.WriteLine();
            }
        }

        static void PurchaseItems()
        {
            if (drinkSystem.Drinks.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No drinks available for purchase.");
                Console.ResetColor();
                return;
            }

            ViewDrinks();
            int drinkIndex = GetValidDrinkIndex();
            Drink selectedDrink = drinkSystem.Drinks[drinkIndex - 1];

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

            if (totalCost > drinkSystem.Wallet.Balance)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Insufficient balance in the wallet.");
                Console.ResetColor();
                return;
            }

            selectedDrink.NumberOfDrinks -= quantity;
            drinkSystem.Wallet.Deduct(totalCost);

            OrderedItem orderedItem = new OrderedItem(selectedDrink.Name, quantity, totalCost);
            drinkSystem.OrderedItems.Add(orderedItem);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Purchase successful.");
            Console.ResetColor();
        }

        static void ViewOrderedItems()
        {
            if (drinkSystem.OrderedItems.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No items ordered.");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("======= Ordered Items =======");
            Console.ResetColor();

            for (int i = 0; i < drinkSystem.OrderedItems.Count; i++)
            {
                Console.WriteLine($"Item {i + 1}:");
                Console.WriteLine($"Name: {drinkSystem.OrderedItems[i].Name}");
                Console.WriteLine($"Quantity: {drinkSystem.OrderedItems[i].Quantity}");
                Console.WriteLine($"Total Price: {drinkSystem.OrderedItems[i].TotalPrice:C}");
                Console.WriteLine();
            }
        }

        static void AddMoneyToWallet()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter the amount to add to the wallet: ");
            Console.ResetColor();
            decimal amount = GetValidPositiveNumber();

            drinkSystem.Wallet.Add(amount);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Amount added to the wallet successfully.");
            Console.ResetColor();
        }

        static int GetValidPositiveInteger()
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

        static decimal GetValidPositiveNumber()
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

        static bool GetValidBoolean()
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

        static int GetValidDrinkIndex()
        {
            int index;
            while (!int.TryParse(Console.ReadLine(), out index) || index <= 0 || index > drinkSystem.Drinks.Count)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a valid drink index.");
                Console.ResetColor();
            }
            return index;
        }
    }

}
