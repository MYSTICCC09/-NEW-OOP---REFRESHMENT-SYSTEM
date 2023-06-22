using System;
using System.Collections.Generic;

public class RefreshmentDrinkSystem
{
    public List<Drink> Drinks { get; private set; }
    public List<OrderedItem> OrderedItems { get; private set; }

    public RefreshmentDrinkSystem()
    {
        Drinks = new List<Drink>();
        OrderedItems = new List<OrderedItem>();
    }

    public void Run()
    {
        Console.WriteLine("Welcome to the Refreshment Drink System!");
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("MENU");
            Console.WriteLine("1. Items");
            Console.WriteLine("2. Add");
            Console.WriteLine("3. Clear");
            Console.WriteLine("4. Remove");
            Console.WriteLine("5. Purchase");
            Console.WriteLine("6. Exit");
            Console.WriteLine();

            int choice = GetValidChoice();

            switch (choice)
            {
                case 1:
                    DisplayItems();
                    break;
                case 2:
                    AddItem();
                    break;
                case 3:
                    ClearItems();
                    break;
                case 4:
                    RemoveItem();
                    break;
                case 5:
                    PurchaseItems();
                    break;
                case 6:
                    Console.WriteLine("Thank you for using the Refreshment Drink System!");
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
            if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 6)
            {
                return choice;
            }
            Console.WriteLine("Invalid choice. Please try again.");
            Console.WriteLine();
        }
    }

    private void DisplayItems()
    {
        Console.WriteLine("ITEMS");
        Console.WriteLine("-----");

        if (Drinks.Count == 0)
        {
            Console.WriteLine("No drinks available.");
        }
        else
        {
            foreach (Drink drink in Drinks)
            {
                Console.WriteLine(drink.Name);
                Console.WriteLine("Price: " + drink.Price + " cents");
                Console.WriteLine("Availability: " + (drink.IsAvailable ? "Available" : "Not available"));
                Console.WriteLine("Number of drinks: " + drink.NumberOfDrinks);
                Console.WriteLine("Description: " + drink.Description);
                Console.WriteLine();
            }
        }
    }

    private void AddItem()
    {
        Console.Write("Enter the name of the drink: ");
        string name = Console.ReadLine();

        Console.Write("Enter the price of the drink: ");
        int price = GetValidPositiveNumber();

        Console.Write("Is the drink available? (y/n): ");
        bool isAvailable = Console.ReadLine().ToLower() == "y";

        Console.Write("Enter the number of drinks available: ");
        int numberOfDrinks = GetValidPositiveNumber();

        Console.Write("Enter the description of the drink: ");
        string description = Console.ReadLine();

        Drink newDrink = new Drink(name, price, isAvailable, numberOfDrinks, description);
        Drinks.Add(newDrink);

        Console.WriteLine("Drink added successfully.");
    }

    private void ClearItems()
    {
        Drinks.Clear();
        Console.WriteLine("All drinks have been cleared.");
    }

    private void RemoveItem()
    {
        if (Drinks.Count == 0)
        {
            Console.WriteLine("No drinks available to remove.");
            return;
        }

        Console.WriteLine("Enter the number of the drink to remove:");

        for (int i = 0; i < Drinks.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Drinks[i].Name}");
        }

        int drinkIndex = GetValidDrinkIndex();

        Drinks.RemoveAt(drinkIndex - 1);
        Console.WriteLine("Drink removed successfully.");
    }

    private void PurchaseItems()
    {
        if (Drinks.Count == 0)
        {
            Console.WriteLine("No drinks available to purchase.");
            return;
        }

        Console.WriteLine("Enter the number of the drink to purchase:");

        for (int i = 0; i < Drinks.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Drinks[i].Name}");
        }

        int drinkIndex = GetValidDrinkIndex();

        Drink selectedDrink = Drinks[drinkIndex - 1];

        Console.Write("Enter the quantity to purchase: ");
        int quantity = GetValidPositiveNumber();

        if (selectedDrink.NumberOfDrinks < quantity)
        {
            Console.WriteLine("Insufficient quantity available.");
            return;
        }

        int totalPrice = selectedDrink.Price * quantity;
        OrderedItem orderedItem = new OrderedItem(selectedDrink.Name, quantity, totalPrice);
        OrderedItems.Add(orderedItem);

        selectedDrink.NumberOfDrinks -= quantity;
        Console.WriteLine("Item purchased successfully.");
    }

    private int GetValidPositiveNumber()
    {
        int number;
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out number) && number > 0)
            {
                return number;
            }
            Console.WriteLine("Invalid input. Please enter a positive number.");
            Console.WriteLine();
        }
    }

    private int GetValidDrinkIndex()
    {
        int drinkIndex;
        while (true)
        {
            Console.Write("Enter the drink number: ");
            if (int.TryParse(Console.ReadLine(), out drinkIndex) && drinkIndex >= 1 && drinkIndex <= Drinks.Count)
            {
                return drinkIndex;
            }
            Console.WriteLine("Invalid drink number. Please try again.");
            Console.WriteLine();
        }
    }
}

public class Drink
{
    public string Name { get; private set; }
    public int Price { get; private set; }
    public bool IsAvailable { get; set; }
    public int NumberOfDrinks { get; set; }
    public string Description { get; private set; }

    public Drink(string name, int price, bool isAvailable, int numberOfDrinks, string description)
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
    public string Name { get; private set; }
    public int Quantity { get; private set; }
    public int TotalPrice { get; private set; }

    public OrderedItem(string name, int quantity, int totalPrice)
    {
        Name = name;
        Quantity = quantity;
        TotalPrice = totalPrice;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        RefreshmentDrinkSystem system = new RefreshmentDrinkSystem();
        system.AddRefreshmentList();
        system.Run();
    }
}