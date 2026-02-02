using AppCrudEFCore.Data;
using AppCrudEFCore.Models;

namespace AppCrudEFCore.Controllers
{
    public class ProductController
    {
        private readonly ProductRepository _repo = new();

        public void CreateProduct()
        {
            Console.Write("Nome prodotto: ");
            string name = Console.ReadLine();

            Console.Write("Prezzo: ");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.Write("Stock: ");
            int stock = int.Parse(Console.ReadLine());

            var product = new Product
            {
                Name = name,
                Price = price,
                Stock = stock
            };

            _repo.Insert(product);
            Console.WriteLine("Prodotto inserito con successo.");
        }

        public void ListProducts()
        {
            var products = _repo.GetAll();

            Console.WriteLine("\n--- LISTA PRODOTTI ---");
            foreach (var p in products)
            {
                Console.WriteLine($"{p.ProductId} | {p.Name} | {p.Price} | Stock: {p.Stock}");
            }
        }

        public void UpdateProduct()
        {
            Console.Write("ID prodotto da aggiornare: ");
            int id = int.Parse(Console.ReadLine());

            var existing = _repo.GetById(id);
            if (existing == null)
            {
                Console.WriteLine("Prodotto non trovato.");
                return;
            }

            Console.Write("Nuovo nome: ");
            existing.Name = Console.ReadLine();

            Console.Write("Nuovo prezzo: ");
            existing.Price = decimal.Parse(Console.ReadLine());

            Console.Write("Nuovo stock: ");
            existing.Stock = int.Parse(Console.ReadLine());

            _repo.Update(existing);
            Console.WriteLine("Prodotto aggiornato con successo.");
        }

        public void DeleteProduct()
        {
            Console.Write("ID prodotto da eliminare: ");
            int id = int.Parse(Console.ReadLine());

            _repo.Delete(id);
            Console.WriteLine("Prodotto eliminato con successo.");
        }
    }
}
