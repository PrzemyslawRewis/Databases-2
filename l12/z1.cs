using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Samochod
    {
        public int ID { get; set; }
        public int IDMarka { get; set; }
        public String Kolor { get; set; }
    }

    class Marka
    {
        public int ID { get; set; }
        public String Nazwa { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Samochod> samochody = new List<Samochod> 
            {
                new Samochod() { ID = 1, IDMarka = 1, Kolor = "Fioletowy"},
                new Samochod() { ID = 2, IDMarka = 2, Kolor = "Czarny"},
                new Samochod() { ID = 3, IDMarka = 3, Kolor = "Czerwony"},
                new Samochod() { ID = 4, IDMarka = 3, Kolor = "Biały"},
                new Samochod() { ID = 5, IDMarka = 2, Kolor = "Czarny"},
                new Samochod() { ID = 6, IDMarka = 2, Kolor = "Czarny"},
            };

            List<Marka> marki = new List<Marka> 
            {
                new Marka { ID = 1, Nazwa = "Fiat"},
                new Marka { ID = 2, Nazwa = "BMW"},
                new Marka { ID = 3, Nazwa = "Seat"},
            };

            var query1 = samochody.Any(row => row.IDMarka == 3);
            Console.WriteLine("Czy w zbiorze jest samochód marki Seat: " + query1);

            var query2 = samochody.All(row => row.Kolor == "Biały");
            Console.WriteLine("Czy wszystkie samochody w zbiorze są białe: " + query2);

            var query3 = samochody.Count(row => row.Kolor == "Czarny");
            Console.WriteLine("Ilość czarnych samochodów w zbiorze: " + query3);
        }
    }
}