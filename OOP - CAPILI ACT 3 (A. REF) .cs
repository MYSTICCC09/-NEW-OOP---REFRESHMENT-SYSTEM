// Submitted by: Andrei N. Capili BSCPE 1-1 (PUP - BC) //
// ACTIVITY #3 - Object Oriented Programming //

public void Run()
{
    Console.WriteLine("Welcome to the Refreshment Drink System!");

    // Add the list of drinks
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

    while (true)
    {
        // Rest of the code remains the same
    }
}

private void AddRefreshment(string name, int price)
{
    Drink drink = new Drink(name, price, true, 0, "");
    Drinks.Add(drink);
}

public void AddRefreshment(string name, int price)
{
    Drink drink = new Drink(name, price, true, 0, "");
    Drinks.Add(drink);
}
