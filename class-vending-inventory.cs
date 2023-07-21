// Submitted by: Andrei N. Capili BSCPE 1-1 (PUP - BC) //
// ACTIVITY #3 - Object Oriented Programming          //
// FINAL PROJECT - class vendingm.OOP REQUIREMENT    //

using System.Collections.Generic;

namespace RefreshmentDrinkSystem
{
    class VendingMachine //vending machine inventory, available drinks & balance.
                         //allows to add more drinks po from the drinks available at main prog.
    {
        public List<Drink> drinks; // A list that holds the available drinks in the vending machine.
        public decimal balance; // The current balance in the vending machine (total funds available for purchase.

        public VendingMachine() // Constructor para po  mag initialize yung system ko ng with an empty list of drinks and a zero balance.
                                // ang catch po dun sa main code kaya meron na siyang available list of drinks ay gawa po nung create dummmy data.
        {
            drinks = new List<Drink>();  
            balance = 0;
        }

                                // methods po para ma define yung drink 
        public void AddDrink(Drink drink) 
        {
            drinks.Add(drink);
        }

        public List<Drink> GetDrinks()
        {
            return drinks;
        }

        public decimal PurchaseDrink(string drinkName, int quantity) //  para po pag may bumili ma set ang name and quantity.
        {
            Drink drink = drinks.Find(d => d.Name == drinkName); // lambda expression - checks property of drinks in the list if equal to the parameter po.

            if (drink != null && drink.Quantity >= quantity) // para po ma check  yung (drink) variable if it contains a valid reference to a Drink object. 
                                                             // if the drink is not null, it means a drink with the specified name was found in the drinks list.
            {
                decimal totalPrice = drink.Price * quantity; // calculates the total cost of the purchase
                if (balance >= totalPrice)                   // para po ma sure if enough funds to make the purchase.
                {
                    drink.Quantity -= quantity;              // babawasan yung number of drinks available pag bumili
                    balance -= totalPrice;                   // cost 
                    return totalPrice;                       // return - pag successful ang purchase
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
