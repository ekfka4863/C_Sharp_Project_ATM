using System;

public class cardHolder
{
    string cardNum;
    int pin;
    string firstName;
    string lastName;
    double balance;

    // constructor 
    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    // getters 
    public string getNum()
    {
        return cardNum;
    }
    public int getPin()
    {
        return pin;
    }

    public string getFirstName()
    {
        return firstName;
    }
    public string getLaseName()
    {
        return lastName;
    }

    public double getBalance()
    {
        return balance;
    }

    // setters 
    public void setNum(string newCardNum)
    {
        cardNum = newCardNum;
    }
    public void setPin(int newPin)
    {
        pin = newPin;
    }
    public void setFirstName(string newFirstName)
    {
        firstName = newFirstName;
    }
    public void setLastName(string newLastName)
    {
        lastName = newLastName;
    }
    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    // the Main method to actually run the methods
    public static void Main(string[] args)
    { 
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to deposit: ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Thank you for your $$. Your new balance is: {0}", currentUser.getBalance());
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to withdraw: ");
            double withdrawal = Double.Parse(Console.ReadLine());

            // check if the user has enough money
            if (currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("Insufficient balance:(");
            }
            else
            { 
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("You're good to go! Thank you :)");
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current balance: {0}", currentUser.getBalance());
        }

        // list of cardHolders - which can be replaced as datas in DB 
        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("13218664546546", 1234, "John", "Griffith", 150.31));
        cardHolders.Add(new cardHolder("46546132186645", 8521, "Ashley", "Jones", 321.13));
        cardHolders.Add(new cardHolder("64688888432166", 1943, "Jane", "Dickers", 851.05));
        cardHolders.Add(new cardHolder("88331326545455", 5557, "Munes", "Harding", 120.11));
        cardHolders.Add(new cardHolder("88881219976365", 4321, "Dawn", "Mermaid", 340.60));

        // prompt user 
        Console.WriteLine("Welcome to SimpleATM");
        Console.WriteLine("Please insert your debit card: ");

        string debitCardNum = "";
        cardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                // check if the user data is in the "DB"/list created above
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);

                // assuming if there is a equal to match 
                if (currentUser != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Card not recognized. Please try again");
                }
            }
            catch
            {
                Console.WriteLine("Car not recognized. Please try again");
            }
        }
        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                currentUser = cardHolders.FirstOrDefault(a => a.pin == userPin);

                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Incorrect pin. Please try again."); }
            }
            catch 
            {
                Console.WriteLine("Incorrect pin. Please try again.");
            }
        }

        Console.WriteLine("Welcome {0} {1} :)", currentUser.getFirstName(), currentUser.getLaseName());
        
        // choosing the option 
        int option = 0;
        do
        {
            printOptions();
            try 
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }

            if (option == 1) { deposit(currentUser); }
            else if (option == 2) { withdraw(currentUser); }
            else if (option == 3) { balance(currentUser); }
            else if (option == 4) { break; }
            else { option = 0; }
        }
        while (option != 4);

        Console.WriteLine("Thank you! Have a nice day :)");
    }
}