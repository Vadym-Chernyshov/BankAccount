using System.Text;

namespace BankAccount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.GetEncoding(1251);

            //перевіряємо клас
            Account account_1 = new("Aragorn", 100.00m);
            account_1.Withdrawal(55.55m); // зняття коштів
            account_1.Withdrawal(100000000000000m); //зняття завеликої суми

            Account account_2 = new("Frodo", 1.00m);
            account_2.Deposit(100.00m); //додавання грошей

            Account account_3 = new("Sam", 25.25m);
            account_3.PrintCurrentAccount(); //звичайний вивід

        }
    }

    public class Account(string name, decimal moneyInTheAccount) //VisualStudio зпропонувало ще такий варіант
    {
        public string Name { get; private set; } = name;
        public decimal MoneyInTheAccount { get; private set; } = moneyInTheAccount;

        public static readonly string currency = "UAH";

        //Минулий варіант
        //public Account(string name, decimal moneyInTheAccount)
        //{
        //    Name = name;
        //    MoneyInTheAccount = moneyInTheAccount;
        //}

        public void Withdrawal(decimal withdrawals)
        {
            if (withdrawals > MoneyInTheAccount)
            {
                Console.WriteLine("Недостатньо коштів на рахунку.\n" +
                                  "Спробуйте іншу суму або відкрийте кредитний рахунок");
                Console.WriteLine();
            }
            else
            {
                MoneyInTheAccount -= withdrawals;
                Console.WriteLine($"Було знято {withdrawals} {currency}");
                PrintCurrentAccount();
                Console.WriteLine();
            }
        }

        public void Deposit(decimal deposit)
        {
            MoneyInTheAccount += deposit;
            Console.WriteLine($"Було додано {deposit} {currency}");
            PrintCurrentAccount(); 
            Console.WriteLine();
        }

        public void PrintCurrentAccount() => Console.WriteLine($"{Name}, Ваш поточний рахунок {MoneyInTheAccount} {currency}");
        
    }
}
