// Submitted by: Andrei N. Capili BSCPE 1-1 (PUP - BC) //
// ACTIVITY #3 - Object Oriented Programming          //
// FINAL PROJECT - class vendingm.OOP REQUIREMENT    //

using System.Collections.Generic;

namespace RefreshmentDrinkSystem
{
    class VendingMachine //vending machine inventory, available drinks & balance
                         //allows to add more drinks po from the drinks available at main prog
    {
        public List<Drink> drinks;
        public decimal balance;

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
}
