// Submitted by: Andrei N. Capili BSCPE 1-1 (PUP - BC) //
// ACTIVITY #3 - Object Oriented Programming          //
// FINAL PROJECT - MAIN CS. OOP REQUIREMENT          //

using System;
using System.Collections.Generic;

namespace RefreshmentDrinkSystem
{
    class Program
    {
        static VendingMachine vendingMachine = new VendingMachine();

        static void Main(string[] args)
        {
            vendingMachine = new VendingMachine();
            CreateDummyData(); // kaya po nasa unahan na to kasi para maihanda na agad yung drinks na available sa system/

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("============================================================");
            Console.WriteLine("       Welcome to Andrei's Refreshment Drink System    ");
            Console.WriteLine("============================================================");
            Console.ResetColor();

            Console.WriteLine("1. Display Inventory");
            Console.WriteLine("2. Purchase Drink");
            Console.WriteLine("3. Add Funds");
            Console.WriteLine("4. Return Change");
            Console.WriteLine("0. Exit");

            string userInput = GetUserInput(); //  kung ano ta-type ng user sa console ay maiistore sa userInput

            while (userInput != "0") // loop as long as tama input
                                     // checks whether the value of userInput is not equal to the string "0".
                                     // loop will keep running until the user enters "0" as their input.
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

        public static string GetUserInput()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("User input > ");
            Console.ResetColor();
          #nullable disable  
          return Console.ReadLine();
          
        }
        public static void DisplayInventory()
        {
            List<Drink> drinks = vendingMachine.GetDrinks();

            Console.WriteLine("\n============================================================");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("                         INVENTORY");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("============================================================");
            Console.WriteLine("   Good day sir!, eto po yung ating mga inumin na available ");
            Console.WriteLine("============================================================");
            Console.ResetColor();

            Console.WriteLine("============================================================");
            Console.WriteLine("      NAME                TYPE           QUANTITY");
            Console.WriteLine("------------------------------------------------------------");

            foreach (Drink drink in drinks)
            {
                string type = drink.GetType().Name; // to obtain its type as a System.Type object.
                                                    // object to get the name of the type (i.e., the class name of the drink object).
                Console.WriteLine($"{drink.Name,-25} {type,-15} {drink.Quantity}"); // alignment lang po pag ni run.
            }

            Console.WriteLine("===============================================");
        }

        public static void PurchaseDrink()
        {
            Console.Write("\nEnter the name of the drink you want to buy: ");
            string drinkName = GetUserInput();

            Console.Write("Enter the quantity: ");
            int quantity;
            bool isValidQuantity = int.TryParse(GetUserInput(), out quantity); // If the conversion fails (e.g., the user entered non-numeric characters).

            if (!isValidQuantity || quantity <= 0) // (||) is the logical OR operator sa gitna ng two conditions .
                                                   // returns true if either of the conditions is true.
            {
                Console.WriteLine("Invalid quantity. Please enter a positive integer.");
                return;
            }

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

        public static void AddFunds()
        {
            Console.Write("\nEnter the amount to add: ");
            decimal amount;
            bool isValidAmount = decimal.TryParse(GetUserInput(), out amount);

            if (!isValidAmount || amount <= 0)
            {
                Console.WriteLine("Invalid amount. Please enter a positive number.");
                return;
            }

            vendingMachine.AddFunds(amount);

            Console.WriteLine("\n====================================================");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"  Funds added successfully. Current balance: {vendingMachine.GetBalance():C}");
            Console.ResetColor();
            Console.WriteLine("====================================================");
        }

        public static void ReturnChange()
        {
            decimal change = vendingMachine.ReturnChange();

            Console.WriteLine("\n===============================================");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"  Change returned: {change:C}");
            Console.ResetColor();
            Console.WriteLine("===============================================");
        }

        public static void CreateDummyData()
        {
            vendingMachine.AddDrink(new Juice("Tropical Tango-Mango", 75, 2.50m));
            vendingMachine.AddDrink(new Juice("Iced Blended Calamansi", 50, 1.75m));
            vendingMachine.AddDrink(new Juice("Lemonade", 90, 1.25m));
            vendingMachine.AddDrink(new Juice("Green Tea", 60, 1.50m));
            vendingMachine.AddDrink(new Juice("Grapefruit      ", 125, 2.00m));
            vendingMachine.AddDrink(new Juice("Blueberry Lemonade", 130, 2.25m));

            vendingMachine.AddDrink(new Alcohol("Whiskey", 30, 10.00m));
            vendingMachine.AddDrink(new Alcohol("Vodka", 40, 8.50m));
            vendingMachine.AddDrink(new Alcohol("Rum", 25, 9.75m));
            vendingMachine.AddDrink(new Alcohol("Tequila", 35, 9.00m));

            vendingMachine.AddDrink(new ChilledDrink("Iced Coffee", 120, 2.00m));
            vendingMachine.AddDrink(new ChilledDrink("Strawberry Shake", 85, 2.25m));
            vendingMachine.AddDrink(new ChilledDrink("Chocolate Milk", 70, 1.75m));
            vendingMachine.AddDrink(new ChilledDrink("Mint Mojito", 70, 1.50m));
            vendingMachine.AddDrink(new ChilledDrink("Watermelon Slush", 150, 2.50m));
            vendingMachine.AddDrink(new ChilledDrink("Mango Lassi", 200, 3.00m));
        }
    }
}
