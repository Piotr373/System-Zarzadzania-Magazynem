using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Systemzarzadzania
{
    internal class Product
    {
        private string id = null!;
        private string name = null!;

        public  uint ilosc { get; set; } 
        public decimal cena { get; set; }

        public Product(string id, string name, uint ilosc, decimal cena)
        {
            this.ID = id;
            this.NAME = name;
            this.ilosc = ilosc;
            this.cena = cena;
        } 

        public string ID
        {
            get { return this.id; } 
            set
            {  if(string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("ID nie moze byc puste.");
            this.id = value;
            } 

        }
        public string NAME
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Nazwa nie moze byc pusta.");
                this.name = value;
            }






    }
}
}
