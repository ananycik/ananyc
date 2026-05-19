using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemObliczenFinansowych.Interfaces;

namespace SystemObliczenFinansowych.Calculations
{
    public class MarzaIZysk : IObliczenie
    {
        public string Nazwa => "Obliczanie marży i zysku ze sprzedaży";

        public void Oblicz()
        {
            Console.Clear();
            Console.WriteLine($"--- {Nazwa} ---");

            double kosztZakupu = WczytajLiczbe("Podaj koszt zakupu produktu (netto): ");
            double cenaSprzedazy = WczytajLiczbe("Podaj cenę sprzedaży produktu (netto): ");

            if (cenaSprzedazy <= kosztZakupu)
            {
                Console.WriteLine("\nUwaga: Cena sprzedaży jest mniejsza lub równa kosztom zakupu! Generujesz stratę.");
            }

            double zyskKwotowy = cenaSprzedazy - kosztZakupu;

          
            double marza = (cenaSprzedazy > 0) ? (zyskKwotowy / cenaSprzedazy) * 100 : 0;

           
            double narzut = (kosztZakupu > 0) ? (zyskKwotowy / kosztZakupu) * 100 : 0;

            Console.WriteLine("\n--- Wyniki ---");
            Console.WriteLine($"Zysk kwotowy na jednostkę towaru: {zyskKwotowy:F2} PLN");
            Console.WriteLine($"Marża: {marza:F2}%");
            Console.WriteLine($"Narzut (Markup): {narzut:F2}%");
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
                Console.WriteLine("Błąd! Podaj poprawną wartość.");
            }
        }
    }
}

