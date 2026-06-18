
using System.Runtime.CompilerServices;

namespace Systemzarzadzania
{
    internal class Program
    {
        static List<Product> magazyn = new List<Product>();
        static void Main(string[] args)
        {
            magazyn.Add(new Product("001", "Produkt 1", 10, 19.99m));
            magazyn.Add(new Product("002", "Produkt 2", 5, 9.99m));

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
            Console.WriteLine("Produkty w magazynie:");
            foreach (var product in magazyn)
            {
                Console.WriteLine($"ID: {product.ID}, Nazwa: {product.NAME}, Ilość: {product.ilosc}, Cena: {product.cena}");
            }
        } 
        static void AddProduct()
        {
            string id = VerifyString("Podaj ID produktu:");       
            string name = VerifyString("Podaj nazwę produktu:");
            uint ilosc = Verify<uint>("Podaj ilość produktu:");
            decimal cena = Verify<decimal>("Podaj cenę produktu:");
            magazyn.Add(new Product(id, name, ilosc, cena));
        }
        static void RemoveProduct()
        {
            
            string id = VerifyString("Podaj ID produktu do usunięcia:");
            var product = magazyn.FirstOrDefault(p => p.ID == id);
            if (product != null)
            {
                magazyn.Remove(product);
                Console.WriteLine("Produkt został usunięty.");
            }
            else Console.WriteLine("Nie znaleziono produktu o podanym ID.");
            
        }
        static void ChangeProductQuantity()
        {
            Console.WriteLine("Podaj ID produktu, którego ilość chcesz zmienić:");
            string id = VerifyString("Podaj ID produktu, którego ilość chcesz zmienić:");
            var product = magazyn.FirstOrDefault(p => p.ID == id);
            if (product != null)
            {
                Console.WriteLine("Podaj nową ilość produktu:");
                uint newQuantity = Verify<uint>("Podaj nową ilość produktu:");
                product.ilosc = newQuantity;
                Console.WriteLine("Ilość produktu została zmieniona.");
            }
            else  Console.WriteLine("Nie znaleziono produktu o podanym ID.");
            
        }
       static void ChangeProductPrice()
        {
                   
            string id = VerifyString("Podaj ID produktu, którego cenę chcesz zmienić:");



            var product = magazyn.FirstOrDefault(p => p.ID == id);
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
