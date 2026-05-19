using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SystemObliczenFinansowych.Interfaces
{
    public interface IObliczenie
    {
        
        string Nazwa { get; }

        void Oblicz();
    }
}