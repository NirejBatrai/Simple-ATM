using System;

using System.Linq.Expressions;
public class cardHolder
{
	string cardNum;
	int pin;
	string firstName;
	string lastName;
	double balance;


	public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
	{
		this.cardNum = cardNum;
		this.pin = pin;
		this.firstName = firstName;
		this.lastName = lastName;
		this.balance = balance;
	}

	public String getNum()
	{
		return cardNum;
	}
	public int getPin()
	{
		return pin;
	}
	public String getFirstName()
	{
		return firstName;
	}
	public String getLastName()
	{
		return lastName;
	}
	public double getBalance()
	{
		return balance;
	}


	public void setNum(String newCardNum)
	{
		cardNum = newCardNum;
	}
	public void setPin(int newPin)
	{
		pin = newPin;
	}
	public void setFirstName(String newFirstName)
	{
		firstName = newFirstName;
	}
	public void setLastName(String newLastName)
	{
		lastName = newLastName;
	}
	public void setBalance(double newBalance)
	{
		balance = newBalance;
	}


	public static void Main(String[] args)
	{
		void printOptions()
		{
			Console.WriteLine("Please choose one options from following...");
			Console.WriteLine("1. Deposit");
			Console.WriteLine("2. Withdraw");
			Console.WriteLine("3. Show Balance");
			Console.WriteLine("4. Exit");
		}

		void deposit(cardHolder currentUser)
		{
			Console.WriteLine("How much  $$ would you like to deposit: ");
			double deposit = Double.Parse(Console.ReadLine());
			currentUser.setBalance(currentUser.getBalance() + deposit);
			Console.WriteLine("Thank you for your $$. Your new balance is: " + currentUser.getBalance());

		}
		void withdraw(cardHolder currentUser)
		{
			Console.WriteLine("How much $$ would like to withdraw: ");
			double withdrawal = Double.Parse(Console.ReadLine());
			//check if user has enough money to withdraw?
			if (currentUser.getBalance() < withdrawal)
			{
				Console.WriteLine("Insufficient Balance:( ");
			}
			else
			{
				currentUser.setBalance(currentUser.getBalance() - withdrawal);
				Console.WriteLine("You're good to go! Thank you:) ");
			}
		}

		void balance(cardHolder currentUser)
		{
			Console.WriteLine("Current Balance: " + currentUser.getBalance());
		}

		List<cardHolder> cardHolders = new List<cardHolder>();
		cardHolders.Add(new cardHolder("2222", 12, "khem", "khanal", 1200.1));
		cardHolders.Add(new cardHolder("666", 12, "Nirmal", "khanal", 100.1));
		cardHolders.Add(new cardHolder("43", 12, "Puram", "khanal", 1500.2));
		cardHolders.Add(new cardHolder("12", 12, "Yasu", "khanal", 120.2));

		//Prompt user
		Console.WriteLine("Welcome to SimpleATM");
		Console.WriteLine("Please insert your debit card: ");
		String debitCardNum = "";
		cardHolder currentUser;


		while (true)
		{
			try
			{
				debitCardNum = Console.ReadLine();
				//check from list
				currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
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
				Console.WriteLine("card not recognized");
			}
		}

		Console.WriteLine("Please enter your pin: ");
		int userPin = 0;
		while (true)
		{
			try
			{
				userPin = int.Parse(Console.ReadLine());
				if (currentUser.getPin() == userPin)
				{
					break;
				}
				else
				{
					Console.WriteLine("Incorrect pin. Try again");
				}
			}
			catch
			{
				Console.WriteLine("Incorrect pin. Try again");
			}
		}

		Console.WriteLine("Welcome " + currentUser.getFirstName() + ":)");
		int option = 0;
		do
		{
			printOptions();
			try
			{
				option = int.Parse(Console.ReadLine());
			}
			catch
			{ }
			if (option == 1) { deposit(currentUser); }
			else if (option == 2) { withdraw(currentUser); }
			else if (option == 3) { balance(currentUser); }
			else if (option == 4) { break; }
			else { option = 0; }

		}
		while (option != 4);
		Console.WriteLine("Thank you");




	}


}
