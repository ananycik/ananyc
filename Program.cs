using System;
using SystemObliczenFinansowych.Interfaces;

namespace SystemObliczenFinansowych
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            bool uruchomiony = true;

            while (uruchomiony)
            {
                Console.Clear();
                Console.WriteLine("=================================================");
                Console.WriteLine("    SYSTEM OBLICZEŃ FINANSOWO-MATEMATYCZNYCH     ");
                Console.WriteLine("=================================================");
                Console.WriteLine("Wybierz rodzaj obliczeń:");
                Console.WriteLine("1. Procent składany (Prognoza inwestycyjna)");
                Console.WriteLine("2. Raty kredytowe (Kalkulator raty stałej)");
                Console.WriteLine("3. Marża i zysk ze sprzedaży");
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("0. Wyjście z programu");
                Console.WriteLine("=================================================");
                Console.Write("Twój wybór: ");

                string wybor = Console.ReadLine();

                if (wybor == "0")
                {
                    uruchomiony = false;
                    Console.WriteLine("\nDziękujemy za skorzystanie z programu. Do widzenia!");
                    break;
                }

               
                if (int.TryParse(wybor, out int opcja) && Enum.IsDefined(typeof(TypObliczenia), opcja))
                {
                    try
                    {
                        
                        TypObliczenia typ = (TypObliczenia)opcja;
                        IObliczenie kalkulator = ObliczenieFactory.StworzObliczenie(typ);

                        
                        kalkulator.Oblicz();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"\nWystąpił błąd podczas obliczeń: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("\nBłąd! Wybierz poprawną opcję z menu (0-3).");
                }

               
                Console.WriteLine("\nNaciśnij dowolny klawisz, aby wrócić do menu głównego...");
                Console.ReadKey();
            }
        }
    }
}