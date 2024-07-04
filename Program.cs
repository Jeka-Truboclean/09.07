using System.ComponentModel;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main()
        {
            Bank bank = new Bank();
            ATM atm1 = new ATM(bank);
            ATM atm2 = new ATM(bank);

            new Thread(() => atm1.WithdrawMoney(5000)).Start();
            new Thread(() => atm2.WithdrawMoney(3000)).Start();
        }
    }
    class Bank
    {
        private int accountBalance = 10000;
        public void WithdrawMoney(int amount)
        {
            if (amount > accountBalance)
            {
                Console.WriteLine("No money");
            }
            else
            {
                Thread.Sleep(1000);
                accountBalance -= amount;
                Console.WriteLine($"Taken - {amount}, balance - {accountBalance}");
            }
        }
    }
    class ATM
    {
        private Bank bank;

        public ATM(Bank bank)
        {
            this.bank = bank;
        }
        public void WithdrawMoney(int amount) 
        { 
            bank.WithdrawMoney(amount);
        }
    }
}
