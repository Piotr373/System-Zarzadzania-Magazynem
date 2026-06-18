
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.VisualBasic;
using System.Runtime.CompilerServices;

namespace Systemzarzadzania
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            using (var db = new AppDbContext())
            {
                db.Database.EnsureCreated();
            }

            

            while (true)
            {
                Console.WriteLine("Wybierz opcję:");
                Console.WriteLine("1. Wyświetl produkty");
                Console.WriteLine("2. Dodaj produkt");
                Console.WriteLine("3. Usuń produkt");
                Console.WriteLine("4. Zmień ilość produktu");
                Console.WriteLine("5. Zmień cenę produktu");
                Console.WriteLine("6. Wyjście");
                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        DisplayProducts();
                        break;
                    case "2":
                        AddProduct();
                        break;
                    case "3":
                        RemoveProduct();
                        break;
                    case "4":
                        ChangeProductQuantity();
                        break;
                    case "5":
                        ChangeProductPrice();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Nieprawidłowa opcja.");
                        break;
                }
            } 
        }
        static void DisplayProducts()
        {
          using var db  = new AppDbContext();
            Console.WriteLine("Produkty w magazynie:");
            var produkty = db.Products.ToList();
            if(produkty.Count() == 0)
            {
                Console.WriteLine("Magazyn jest pusty");
            }
            foreach (var produkt in produkty)
            {
                Console.WriteLine($"ID: {produkt.Id}, Nazwa: {produkt.Name}, Ilość: {produkt.ilosc}, Cena: {produkt.cena}");
            }
        } 
        static void AddProduct()
        {
                  
            string name = VerifyString("Podaj nazwę produktu:");
            uint ilosc = Verify<uint>("Podaj ilość produktu:");
            decimal cena = Verify<decimal>("Podaj cenę produktu:");
            using var db = new AppDbContext();
            
            var nowyProdukt = new Product(name,ilosc, cena);


            db.Products.Add(nowyProdukt);
            db.SaveChanges();
            Console.WriteLine("Produkt zostal dodany");
        }
        static void RemoveProduct()
        {

            int id = Verify<int>("Podaj Id produktu do usuniecia:");
            using var db = new AppDbContext();
            var product = db.Products.FirstOrDefault(p => p.Id == id);

            if (product != null)
            {
                db.Products.Remove(product);
                db.SaveChanges();
                Console.WriteLine("Produkt zostal pomyslnie usuniety");
            }
            else Console.WriteLine("Nie znaleziono produktu o podanym ID.");
            
        }
        static void ChangeProductQuantity()
        {
            Console.WriteLine("Podaj ID produktu, którego ilość chcesz zmienić:");
            int id = Verify<int>("Podaj ID produktu, którego ilość chcesz zmienić:");


            using var db = new AppDbContext();
            var product = db.Products.FirstOrDefault(p => p.Id == id);


            if (product != null)
            {
                //Console.WriteLine("Podaj nową ilość produktu:");
                //uint newQuantity = Verify<uint>("Podaj nową ilość produktu:");
                //product.ilosc = newQuantity;
                //Console.WriteLine("Ilość produktu została zmieniona.");

                uint newQuantity = Verify<uint>("Podaj nową ilość produktu:");
                product.ilosc = newQuantity;
                db.SaveChanges();
                Console.WriteLine("Ilosc produktu zostala zmieniona.");

            }
            else  Console.WriteLine("Nie znaleziono produktu o podanym ID.");
            
        }
       static void ChangeProductPrice()
        {
                   
            int id = Verify<int>("Podaj ID produktu, którego cenę chcesz zmienić:");

            using var db  = new AppDbContext();

            var product = db.Products.FirstOrDefault(p => p.Id == id);

            if (product != null)
            {
               
                decimal newPrice = Verify<decimal>("Podaj nową cenę produktu:");
                if (newPrice == product.cena)
                {
                    Console.WriteLine("Nowa cena jest taka sama jak obecna cena. Nie dokonano zmiany.");
                    return;
                }
                else
                {
                    product.cena = newPrice;
                    db.SaveChanges();
                    Console.WriteLine("Cena produktu została zmieniona.");
                }
            }
            else Console.WriteLine("Nie znaleziono produktu o podanym ID.");
            
            
        }

        
        public static T Verify<T>(string a ) where T: ISpanParsable<T>
        {
            Console.Clear();
            Console.WriteLine(a);
            string? input = Console.ReadLine(); 
            while(true)
            {
                if(!T.TryParse(input, null, out T? result))
                {
                    Console.WriteLine("Nieprawidłowa wartość. Spróbuj ponownie:");
                    input = Console.ReadLine();
                }
                else
                {
                    return result;
                }
            }

        }
        public static string VerifyString(string a)
        {
            Console.Clear();
            Console.WriteLine(a);
            string? input = Console.ReadLine();
            while (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Nieprawidłowa wartość. Spróbuj ponownie:");
                input = Console.ReadLine();
            }
            return input;
        }
}
}
