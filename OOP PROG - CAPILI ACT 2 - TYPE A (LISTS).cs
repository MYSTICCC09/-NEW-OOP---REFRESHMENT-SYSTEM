// Submitted by: Andrei N. Capili BSCPE 1-1 (PUP - BC) //
// ACTIVITY #2 - Object Oriented Programming //

using System;
using System.Collections.Generic; 

class VendingMachine {
    static List<int> coinList = new List<int>();
    static List<string> refreshmentList = new List<string>();
    static List<int> priceList = new List<int>();
    static string welcomeMessage = "Welcome to Andrei's Refreshment Drinks System!";
    static int balance = 0;

    static void Main() {
        InitializeVendingMachine();

        while (true) {
            Console.WriteLine();
            Console.WriteLine(welcomeMessage);
            Console.WriteLine("1. Insert coin");
            Console.WriteLine("2. Purchase item");
            Console.WriteLine("3. Check balance");
            Console.WriteLine("4. Refill refreshments");
            Console.WriteLine("5. Exit");
            Console.WriteLine();

            int choice = GetValidChoice();

            switch (choice) {
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

    static int GetValidChoice() {
        int choice;
        while (true) {
            Console.Write("Enter your choice: ");
            if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 5) {
                return choice;
            }
            Console.WriteLine("Invalid choice. Please try again.");
            Console.WriteLine();
        }
    }

    static void InsertCoin() {
        Console.WriteLine("Please insert a coin (5, 10, 25, 50, 100, 200)");
        int coin = GetValidCoin();

        coinList.Add(coin);
        balance += coin;
        Console.WriteLine("Current balance: " + balance + " cents");
    }

    static int GetValidCoin() {
        int coin;
        while (true) {
            Console.Write("Enter the coin value: ");
            if (int.TryParse(Console.ReadLine(), out coin) && IsValidCoin(coin)) {
                return coin;
            }
            Console.WriteLine("Invalid coin. Please try again.");
            Console.WriteLine();
        }
    }

    static void PurchaseItem() {
        if (refreshmentList.Count == 0) {
            Console.WriteLine("No refreshments available. Please refill the machine.");
            return;
        }

        Console.WriteLine("Please select an item to purchase:");
        Console.WriteLine();

        for (int i = 0; i < refreshmentList.Count; i++) {
            Console.WriteLine($"{i + 1}. {refreshmentList[i]} - {priceList[i]} cents");
        }

        int item = GetValidItem();

        if (IsValidItem(item)) {
            string selectedItem = refreshmentList[item - 1];
            int selectedPrice = priceList[item - 1];

            if (balance >= selectedPrice) {
                balance -= selectedPrice;
                Console.WriteLine("Thank you for purchasing " + selectedItem + "!");
                Console.WriteLine("Updated balance: " + balance + " cents");
            }
            else {
                Console.WriteLine("Insufficient balance. Please insert more coins.");
            }
        }
        else {
            Console.WriteLine("Invalid item. Please try again.");
        }
    }

    static int GetValidItem() {
        int item;
        while (true) {
            Console.Write("Enter the item number: ");
            if (int.TryParse(Console.ReadLine(), out item) && IsValidItem(item)) {
                return item;
            }
            Console.WriteLine("Invalid item. Please try again.");
            Console.WriteLine();
        }
    }

    static void CheckBalance() {
        Console.WriteLine("Current balance: " + balance + " cents");
    }

    static void RefillRefreshments() {
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

    static void AddRefreshment(string name, int price) {
        refreshmentList.Add(name);
        priceList.Add(price);
    }

    static bool IsValidCoin(int coin) {
        return coin == 5 || coin == 10 || coin == 25 || coin == 50 || coin == 100 || coin == 200;
    }

    static bool IsValidItem(int item) {
        return item >= 1 && item <= refreshmentList.Count;
    }

    static void InitializeVendingMachine() {
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
