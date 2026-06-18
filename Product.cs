using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Systemzarzadzania
{
    internal class Product
    {
        public int Id { get; set;   }
        public string Name { get; set; } = null!;

        public  uint ilosc { get; set; } 
        public decimal cena { get; set; }

        public Product( string name, uint ilosc, decimal cena)
        {
            
            this.Name = name;
            this.ilosc = ilosc;
            this.cena = cena;
        } 
        public Product()
        {

        }

      
   





    }
}

