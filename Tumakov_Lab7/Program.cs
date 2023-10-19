using System;

namespace Tumakov_Lab7
{
    public class Building
    {
        private int uniqueNumber;
        private int Height;
        private int Floors;
        private int Apartments;
        private int Entrances;

        public Building(int height, int floors, int apartments, int entrances)
        {
            Height = height;
            Floors = floors;
            Apartments = apartments;
            Entrances = entrances;
            uniqueNumber = getNextUniqueNumber();
        }
        private static int nextUniqueNumber = 1;

        public int GetUniqueNumber()
        {
            return uniqueNumber;
        }

        public int GetHeight()
        {
            return Height;
        }

        public int GetFloors()
        {
            return Floors;
        }

        public int GetApartments()
        {
            return Apartments;
        }

        public int GetEntrances()
        {
            return Entrances;
        }

        public int GetApartmentsOnFloor()
        {
            return Apartments / Floors;
        }

        public int GetApartmentsInEntrance()
        {
            return Apartments / Entrances;
        }

        public int GetFloorHeight()
        {
            return Height / Floors;
        }
        private static int getNextUniqueNumber()
        {
            int uniqueNumber = nextUniqueNumber;
            nextUniqueNumber++;
            return uniqueNumber;
        }

        public override string ToString()
        {
            return $"Номер здания: {uniqueNumber}, высота: {Height}, этажность: {Floors}, количество квартир: {Apartments}, количество подъездов: {Entrances}";
        }
    }

    public class BankAccount
    {
        protected int AccountNumber;
        protected decimal Balance;
        protected AccountType AccountType;

        public BankAccount(int accountNumber, decimal balance, AccountType accountType)
        {
            AccountNumber = accountNumber;
            Balance = balance;
            AccountType = accountType;
        }

        public int GetAccountNumber()
        {
            return AccountNumber;
        }

        public void SetAccountNumber(int accountNumber)
        {
            AccountNumber = accountNumber;
        }

        public decimal GetBalance()
        {
            return Balance;
        }

        public void SetBalance(decimal balance)
        {
            Balance = balance;
        }

        public AccountType GetAccountType()
        {
            return AccountType;
        }

        public void SetAccountType(AccountType accountType)
        {
            AccountType = accountType;
        }

        public override string ToString()
        {
            return $"Номер счета: {AccountNumber}, баланс: {Balance}, тип счета: {AccountType}";
        }
        /// <summary>
        /// снятие со счёта с средств, если это возможно
        /// </summary>
        public void Withdraw(decimal amount)
        {
            if (amount > Balance)
            {
                throw new ArgumentException("Недостаточно средств");
            }

            Balance -= amount;
        }
        /// <summary>
        /// Пополнение счёта
        /// </summary>
        public void Deposit(decimal amount)
        {
            Balance += amount;
        }
    }

    public enum AccountType
    {
        Current,
        Saving
    }
    /// <summary>
    /// генерация различных номеров для аккаунтов
    /// </summary>
    public class UniqueBankAccount : BankAccount
    {
        private static int nextAccountNumber = 1;

        public UniqueBankAccount(decimal balance, AccountType accountType)
            : base(GenerateAccountNumber(), balance, accountType)
        {
        }

        private static int GenerateAccountNumber()
        {
            int accountNumber = nextAccountNumber;
            nextAccountNumber++;
            return accountNumber;
        }
    }
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Упражнение 7.1: Создать класс счет в банке с закрытыми полями: номер счета, баланс, тип\r\nбанковского счета");
            BankAccount account = new BankAccount(1234567890, 10000, AccountType.Current);
            Console.WriteLine(account);
            Console.WriteLine("Нажмите Enter");
            Console.ReadKey();

            Console.WriteLine("Упражнение 7.2: Изменить класс счет в банке из упражнения 7.1 таким образом, чтобы\r\nномер счета генерировался сам и был уникальным.");
            UniqueBankAccount account1 = new UniqueBankAccount(10000, AccountType.Current);
            UniqueBankAccount account2 = new UniqueBankAccount(5000, AccountType.Saving);
            Console.WriteLine(account1);
            Console.WriteLine(account2);
            Console.WriteLine("Нажмите Enter");
            Console.ReadKey();

            Console.WriteLine("Упражнение 7.3: Реализовать снятие и пополнение счёта");
            Console.WriteLine("Снимаем 5000 со счёта пользователя Account1");
            account1.Withdraw(5000);
            Console.WriteLine(account1);
            Console.WriteLine("Поподняем на 1000 счёт пользователя Account2");
            account2.Deposit(1000);
            Console.WriteLine(account2);
            Console.WriteLine("Нажмите Enter");
            Console.ReadKey();

            Console.WriteLine("Домашнее задание 7.1: Реализовать класс для описания здания (уникальный номер здания,\r\nвысота, этажность, количество квартир, подъездов).");
            Building building = new Building(10, 10, 100, 5);
            Console.WriteLine(building);
            Console.WriteLine("Количество квартир на этаже: " + building.GetApartmentsOnFloor());
            Console.WriteLine("Количество квартир в подъезде: " + building.GetApartmentsInEntrance());
            Console.WriteLine("Высота этажа: " + building.GetFloorHeight());
            Building building2 = new Building(15, 5, 120, 10);
            Console.WriteLine(building2);
            Console.WriteLine("Количество квартир на этаже: " + building2.GetApartmentsOnFloor());
            Console.WriteLine("Количество квартир в подъезде: " + building2.GetApartmentsInEntrance());
            Console.WriteLine("Высота этажа: " + building2.GetFloorHeight());
            Console.WriteLine("Нажмите Enter");
            Console.ReadKey();
        }
    }

}
