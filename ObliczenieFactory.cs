using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using SystemObliczenFinansowych.Interfaces;
using SystemObliczenFinansowych.Calculations;

namespace SystemObliczenFinansowych
{
    public static class ObliczenieFactory
    {
        public static IObliczenie StworzObliczenie(TypObliczenia typ)
        {
            switch (typ)
            {
                case TypObliczenia.ProcentSkladany:
                    return new ProcentSkladany();

                case TypObliczenia.RatyKredytowe:
                    return new RatyKredytowe();

                case TypObliczenia.MarzaIZysk:
                    return new MarzaIZysk();

                default:
                    throw new ArgumentException("Nieznany typ obliczeń.");
            }
        }
    }
}
