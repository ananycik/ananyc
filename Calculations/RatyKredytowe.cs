using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using SystemObliczenFinansowych.Interfaces;

namespace SystemObliczenFinansowych.Calculations
{
    public class RatyKredytowe : IObliczenie
    {
        public string Nazwa => "Raty kredytowe (Rata stała)";

        public void Oblicz()
        {
            Console.Clear();
            Console.WriteLine($"--- {Nazwa} ---");

            double kwotaKredytu = WczytajLiczbe("Podaj kwotę kredytu: ");
            double roczneOprocentowanie = WczytajLiczbe("Podaj roczne oprocentowanie в % (np. 7.5): ") / 100;
            int liczbaMiesiecy = (int)WczytajLiczbe("Podaj okres kredytowania w miesiącach: ");

            if (roczneOprocentowanie == 0)
            {
                double rataBezOprocentowania = kwotaKredytu / liczbaMiesiecy;
                Console.WriteLine($"\nMiesięczna rata (0%): {rataBezOprocentowania:F2} PLN");
                return;
            }

            
            double r = roczneOprocentowanie / 12;

            
            double rata = kwotaKredytu * (r * Math.Pow(1 + r, liczbaMiesiecy)) / (Math.Pow(1 + r, liczbaMiesiecy) - 1);
            double calkowityKoszt = rata * liczbaMiesiecy;
            double odsetki = calkowityKoszt - kwotaKredytu;

            Console.WriteLine("\n--- Wyniki ---");
            Console.WriteLine($"Twoja miesięczna rata wynosi: {rata:F2} PLN");
            Console.WriteLine($"Całkowity koszt kredytu: {calkowityKoszt:F2} PLN");
            Console.WriteLine($"Suma samych odsetek: {odsetki:F2} PLN");
        }

        private double WczytajLiczbe(string komunikat)
        {
            double liczba;
            while (true)
            {
                Console.Write(komunikat);
                if (double.TryParse(Console.ReadLine()?.Replace('.', ','), out liczba) && liczba > 0)
                {
                    return liczba;
                }
                Console.WriteLine("Błąd! Podaj liczbę większą od zera.");
            }
        }
    }
}
