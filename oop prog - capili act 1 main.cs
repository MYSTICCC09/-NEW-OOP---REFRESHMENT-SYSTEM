using System;

// Submitted by: Andrei N. Capili BSCPE 1-1 (PUP - BC) //
// ACTIVITY #1 - Object Oriented Programming //


// Eto po yung main class ma'am//

class VendingMachine {
    static void Main() {
        int balance = 0;
        int choice = 0;

// Eto po yung sa choices ma'am//        
        
        while (true) {
            Console.WriteLine("Aloha, I am pleased for you trying Andrei's Refreshment System!");
            Console.WriteLine("1. Insert coin");
            Console.WriteLine("2. Purchase item");
            Console.WriteLine("3. Exit");
            
            choice = Convert.ToInt32(Console.ReadLine());

// Eto po yung kagaya ng sa ginawa niyo pong may balance but in my own way po which is Refreshment system// 
            
            switch (choice) {
                case 1:
                    Console.WriteLine("Please insert a coin (5, 10, 25)");
                    int coin = Convert.ToInt32(Console.ReadLine());
                    
                    if (coin == 5 || coin == 10 || coin == 25) {
                        balance += coin;
                        Console.WriteLine("Current balance: " + balance);
                    }
                    else {
                        Console.WriteLine("Invalid coin. Please try again.");
                    }
                    break;

// Eto po yung selection for the Refreshment system// 
                    
                case 2:
                    Console.WriteLine("Please select an item to purchase:");
                  
                    Console.WriteLine("1. Tropical Tango-Mango Juice (75 cents)");
                    Console.WriteLine("2. Iced honey-blended calamansi Juice  (50 cents)");
                    Console.WriteLine("3. Regular Water (25 cents)");
                    
                    int item = Convert.ToInt32(Console.ReadLine());
                    
                    switch (item) {
                        case 1:
                            if (balance >= 75) {
                                Console.WriteLine("Thank you for purchasing a Tropical Tango-Mango Juice!");
                                balance -= 75;
                            }
                            else {
                                Console.WriteLine("Insufficient funds. Please insert more coins.");
                            }
                            break;
                            
                        case 2:
                            if (balance >= 50) {
                                Console.WriteLine("Thank you for purchasing Regular Water!");
                                balance -= 50;
                            }
                            else {
                                Console.WriteLine("Insufficient funds. Please insert more coins.");
                            }
                            break;
                            
                        case 3:
                            if (balance >= 25) {
                                Console.WriteLine("Thank you for purchasing Iced honey-blended calamansi Juice!");
                                balance -= 25;
                            }
                            else {
                                Console.WriteLine("Insufficient funds. Please insert more coins.");
                            }
                            break;
                            
                        default:
                            Console.WriteLine("Invalid item. Please try again.");
                            break;
                    }
                    break;
                    
                case 3:
                    Console.WriteLine("Thank you for using Andrei's Refreshment System!");
                    return;
                    
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
                    
// Yung dito po sa line nato, para po pag nag select ng ibang number for ex. 4,5,6, dipo ma- iaallow// 
            }
        }
    }
}
