using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using SystemObliczenFinansowych.Interfaces;

namespace SystemObliczenFinansowych.Calculations
{
    public class ProcentSkladany : IObliczenie
    {
        public string Nazwa => "Procent składany (Prognoza inwestycyjna)";

        public void Oblicz()
        {
            Console.Clear();
            Console.WriteLine($"--- {Nazwa} ---");

            double kapital = WczytajLiczbe("Podaj kapitał początkowy (np. 10000): ");
            double oprocentowanie = WczytajLiczbe("Podaj roczne oprocentowanie в % (np. 5): ") / 100;
            double lata = WczytajLiczbe("Podaj okres inwestycji w latach: ");

            
            double wynik = kapital * Math.Pow(1 + oprocentowanie, lata);
            double zysk = wynik - kapital;

            Console.WriteLine("\n--- Wyniki ---");
            Console.WriteLine($"Końcowa wartość inwestycji: {wynik:F2} PLN");
            Console.WriteLine($"Wypracowany zysk: {zysk:F2} PLN");
        }

        private double WczytajLiczbe(string komunikat)
        {
            double liczba;
            while (true)
            {
                Console.Write(komunikat);
                if (double.TryParse(Console.ReadLine()?.Replace('.', ','), out liczba) && liczba >= 0)
                {
                    return liczba;
                }
                Console.WriteLine("Błąd! Podaj poprawną liczbę dodatnią.");
            }
        }
    }
}
