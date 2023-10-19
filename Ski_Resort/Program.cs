using System;

namespace Ski_Resort
{
    abstract class SkiResort
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public int NumberofTrails { get; set; }

        public abstract void CalculateLiftTicketPrice();
        public abstract void CalculateAccommodationPrice();

        public SkiResort(string name, string location, int numberofTrails)
        {
            Name = name;
            Location = location;
            NumberofTrails = numberofTrails;
        }

        public override string ToString()
        {
            return $"Название: {Name}, расположение: {Location}, количество трасс: {NumberofTrails}";
        }
    }
    /// <summary>
    /// класс с описание отеля FamilySkiResort
    /// </summary>
    class FamilySkiResort : SkiResort
    {
        public int NumberofChildcareCenters { get; set; }

        public FamilySkiResort(string name, string location, int numberofTrails, int numberofChildcareCenters)
            : base(name, location, numberofTrails)
        {
            NumberofChildcareCenters = numberofChildcareCenters;
        }
        /// <summary>
        /// Расчёт стоимости абонемента
        /// </summary>
        public override void CalculateLiftTicketPrice()
        {
            double familyLiftTicketPrice = 5000 * NumberofTrails;
            double childLiftTicketPrice = 2500 * NumberofTrails;
            double adultLiftTicketPrice = 3500 * NumberofTrails;
            if (NumberofChildcareCenters > 0)
            {
                familyLiftTicketPrice = familyLiftTicketPrice * 0.9;
            }
            double totalLiftTicketPrice = familyLiftTicketPrice + childLiftTicketPrice + adultLiftTicketPrice;

            Console.WriteLine($"Стоимость абонемента на сезон для семьи: {totalLiftTicketPrice} рублей");
        }
        /// <summary>
        /// Расчёт стоимости проживания
        /// </summary>
        public override void CalculateAccommodationPrice()
        {
            int doubleRoomPrice = 10000 * NumberofTrails;
            int familyRoomPrice = 20000 * NumberofTrails;
            int totalAccommodationPrice = doubleRoomPrice + familyRoomPrice;

            Console.WriteLine($"Стоимость проживания на сезон: {totalAccommodationPrice} рублей");
        }

    }
    /// <summary>
    /// класс с описание отеля LuxurySkiResort
    /// </summary>
    class LuxurySkiResort : SkiResort
    {
        public int NumberofChalets { get; set; }

        public LuxurySkiResort(string name, string location, int numberofTrails, int numberofChalets)
            : base(name, location, numberofTrails)
        {
            NumberofChalets = numberofChalets;
        }
        /// <summary>
        /// расчёт стоимости абонемента
        /// </summary>
        public override void CalculateLiftTicketPrice()
        {
            int adultLiftTicketPrice = 4500 * NumberofTrails;
            int childLiftTicketPrice = 3000 * NumberofTrails;
            int totalLiftTicketPrice = adultLiftTicketPrice + childLiftTicketPrice;

            Console.WriteLine($"Стоимость абонемента на сезон: {totalLiftTicketPrice} рублей");
        }
        /// <summary>
        /// расчёт стоимости проживания
        /// </summary>
        public override void CalculateAccommodationPrice()
        {
            int hotelPrice = 15000 * NumberofTrails;
            int chaletPrice = 25000 * NumberofTrails;
            int totalAccommodationPrice = hotelPrice + chaletPrice;

            Console.WriteLine($"Стоимость проживания на сезон: {totalAccommodationPrice} рублей");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Тема: Лыжный курорт, реализовать несколько классов, методов, свойств.");
            FamilySkiResort familySkiResort = new FamilySkiResort("Красная Поляна", "Россия", 100, 2);
            Console.WriteLine(familySkiResort);
            familySkiResort.CalculateLiftTicketPrice();
            familySkiResort.CalculateAccommodationPrice();
            LuxurySkiResort luxurySkiResort = new LuxurySkiResort("Альпы", "Австрия", 200, 10);
            Console.WriteLine(luxurySkiResort);
            luxurySkiResort.CalculateLiftTicketPrice();
            luxurySkiResort.CalculateAccommodationPrice();
            Console.WriteLine("Нажмите Enter");
            Console.ReadKey();
        }
    }
}
