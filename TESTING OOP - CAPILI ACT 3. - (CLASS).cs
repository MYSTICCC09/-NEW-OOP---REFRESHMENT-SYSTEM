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
            Console.WriteLine("2. Purchase");
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
                        Purchase();
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
            List<Product> inventory = vendingMachine.GetInventory();

            Console.WriteLine("\n===============================================");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("                INVENTORY");
            Console.ResetColor();
            Console.WriteLine("===============================================");
            Console.WriteLine("NAME         QUANTITY");
            Console.WriteLine("-----------------------------------------------");

            foreach (Product product in inventory)
            {
                Console.WriteLine($"{product.Name,-12} {product.Quantity}");
            }

            Console.WriteLine("===============================================");
        }

        private static string GetUserInput()
        {
            Console.Write("\nUser input > ");
            return Console.ReadLine();
        }

        private static void Purchase()
        {
            Console.Write("\nEnter the item you want to buy: ");
            string itemName = GetUserInput();

            Console.Write("Enter the quantity: ");
            int quantity = int.Parse(GetUserInput());

            decimal totalPrice = vendingMachine.Purchase(itemName, quantity);

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
                Console.WriteLine("\nItem not available or insufficient quantity.");
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
            vendingMachine.AddProduct(new Product("Coke", 2, 1.50m));
            vendingMachine.AddProduct(new Product("Chips", 5, 0.75m));
            vendingMachine.AddProduct(new Product("Candy", 10, 0.50m));
        }
    }

    class VendingMachine
    {
        private List<Product> inventory;
        private decimal balance;

        public VendingMachine()
        {
            inventory = new List<Product>();
            balance = 0;
        }

        public void AddProduct(Product product)
        {
            inventory.Add(product);
        }

        public List<Product> GetInventory()
        {
            return inventory;
        }

        public decimal Purchase(string itemName, int quantity)
        {
            Product product = inventory.Find(p => p.Name == itemName);

            if (product != null && product.Quantity >= quantity)
            {
                decimal totalPrice = product.Price * quantity;
                if (balance >= totalPrice)
                {
                    product.Quantity -= quantity;
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

    class Product
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public Product(string name, int quantity, decimal price)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
        }
    }
}
