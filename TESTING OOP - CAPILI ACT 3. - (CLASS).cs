// Submitted by: Andrei N. Capili BSCPE 1-1 (PUP - BC) //
// ACTIVITY #3 - Object Oriented Programming //

using System;
using System.Collections.Generic;

namespace RefreshmentSystem
{
    class RefreshmentMachine
    {
        private List<int> coinList = new List<int>();
        private List<string> refreshmentList = new List<string>();
        private List<int> priceList = new List<int>();
        private int balance = 0;

        public void Run()
        {
            InitializeVendingMachine();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Welcome to Andrei's Refreshment Drinks System!");
                Console.WriteLine("1. Insert coin");
                Console.WriteLine("2. Purchase item");
                Console.WriteLine("3. Check balance");
                Console.WriteLine("4. Refill refreshments");
                Console.WriteLine("5. Exit");
                Console.WriteLine();

                int choice = GetValidChoice();

                switch (choice)
                {
                    case 1:
                        InsertCoin();
                        break;

                    case 2:
                        PurchaseItem();
                        break;

                    case 3:
                        CheckBalance();
                        break;

                    case 4:
                        RefillRefreshments();
                        break;

                    case 5:
                        Console.WriteLine("Thank you for using Andrei's Refreshment Drinks System!");
                        return;
                }
            }
        }

        private int GetValidChoice()
        {
            int choice;
            while (true)
            {
                Console.Write("Enter your choice: ");
                if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 5)
                {
                    return choice;
                }
                Console.WriteLine("Invalid choice. Please try again.");
                Console.WriteLine();
            }
        }

        private void InsertCoin()
        {
            Console.WriteLine("Please insert a coin (5, 10, 25, 50, 100, 200, 400, 600, 800, 1000)");
            int coin = GetValidCoin();

            coinList.Add(coin);
            balance += coin;
            Console.WriteLine("Current balance: " + balance + " cents");
        }

        private int GetValidCoin()
        {
            int coin;
            while (true)
            {
                Console.Write("Enter the coin value: ");
                if (int.TryParse(Console.ReadLine(), out coin) && IsValidCoin(coin))
                {
                    return coin;
                }
                Console.WriteLine("Invalid coin. Please try again.");
                Console.WriteLine();
            }
        }

        private void PurchaseItem()
        {
            if (refreshmentList.Count == 0)
            {
                Console.WriteLine("No refreshments available. Please refill the machine.");
                return;
            }

            Console.WriteLine("Please select an item to purchase:");
            Console.WriteLine();

            for (int i = 0; i < refreshmentList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {refreshmentList[i]} - {priceList[i]} cents");
            }

            int item = GetValidItem();

            if (IsValidItem(item))
            {
                string selectedItem = refreshmentList[item - 1];
                int selectedPrice = priceList[item - 1];

                Console.Write("Enter the quantity: ");
                int quantity = GetValidQuantity();

                int totalPrice = selectedPrice * quantity;

                if (balance >= totalPrice)
                {
                    balance -= totalPrice;
                    Console.WriteLine("Thank you for purchasing " + quantity + " " + selectedItem + "!");
                    Console.WriteLine("Updated balance: " + balance + " cents");
                }
                else
                {
                    Console.WriteLine("Insufficient balance. Please insert more coins.");
                }
            }
            else
            {
                Console.WriteLine("Invalid item. Please try again.");
            }
        }

        private int GetValidItem()
        {
            int item;
            while (true)
            {
                Console.Write("Enter the item number: ");
                if (int.TryParse(Console.ReadLine(), out item) && IsValidItem(item))
                {
                    return item;
                }
                Console.WriteLine("Invalid item. Please try again.");
                Console.WriteLine();
            }
        }

        private int GetValidQuantity()
        {
            int quantity;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out quantity) && quantity >= 1)
                {
                    return quantity;
                }
                Console.WriteLine("Invalid quantity. Please try again.");
                Console.WriteLine();
            }
        }

        private void CheckBalance()
        {
            Console.WriteLine("Current balance: " + balance + " cents");
        }

        private void RefillRefreshments()
        {
            refreshmentList.Clear();
            priceList.Clear();

            Console.WriteLine("Refreshing the vending machine...");
            Console.WriteLine();

            // Add new refreshments and prices
            AddRefreshment("Tropical Tango-Mango Juice", 75);
            AddRefreshment("Iced honey-blended calamansi Juice", 50);
            AddRefreshment("Regular Water", 25);
            AddRefreshment("Lemonade", 90);
            AddRefreshment("Green Tea", 60);
            AddRefreshment("Iced Coffee", 120);
            AddRefreshment("Strawberry Shake", 85);
            AddRefreshment("Chocolate Milk", 70);
            AddRefreshment("Mint Mojito", 70);
            AddRefreshment("Orange Soda", 80);
            AddRefreshment("Apple Cider", 120);
            AddRefreshment("Pineapple Smoothie", 170);
            AddRefreshment("Grapefruit Juice", 125);
            AddRefreshment("Peach Iced Tea", 120);
            AddRefreshment("Blueberry Lemonade", 130);
            AddRefreshment("Watermelon Slush", 150);
            AddRefreshment("Coconut Water", 30);
            AddRefreshment("Mango Lassi", 200);
            AddRefreshment("Raspberry Soda", 110);

            Console.WriteLine("Refreshments refilled successfully.");
            Console.WriteLine();
        }

        private void AddRefreshment(string name, int price)
        {
            refreshmentList.Add(name);
            priceList.Add(price);
        }

        private bool IsValidCoin(int coin)
        {
            return coin == 5 || coin == 10 || coin == 25 || coin == 50 || coin == 100 || coin == 200 || coin == 400 || coin == 600 || coin == 800 || coin == 1000;
        }

        private bool IsValidItem(int item)
        {
            return item >= 1 && item <= refreshmentList.Count;
        }

        private void InitializeVendingMachine()
        {
            AddRefreshment("Tropical Tango-Mango Juice", 75);
            AddRefreshment("Iced honey-blended calamansi Juice", 50);
            AddRefreshment("Regular Water", 25);
            AddRefreshment("Lemonade", 90);
            AddRefreshment("Green Tea", 60);
            AddRefreshment("Iced Coffee", 120);
            AddRefreshment("Strawberry Shake", 85);
            AddRefreshment("Chocolate Milk", 70);
            AddRefreshment("Mint Mojito", 70);
            AddRefreshment("Orange Soda", 80);
            AddRefreshment("Apple Cider", 120);
            AddRefreshment("Pineapple Smoothie", 170);
            AddRefreshment("Grapefruit Juice", 125);
            AddRefreshment("Peach Iced Tea", 120);
            AddRefreshment("Blueberry Lemonade", 130);
            AddRefreshment("Watermelon Slush", 150);
            AddRefreshment("Coconut Water", 30);
            AddRefreshment("Mango Lassi", 200);
            AddRefreshment("Raspberry Soda", 110);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            RefreshmentMachine machine = new RefreshmentMachine();
            machine.Run();
        }
    }
}
