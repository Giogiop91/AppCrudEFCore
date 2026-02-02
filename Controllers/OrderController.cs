using AppCrudEFCore.Data;
using AppCrudEFCore.Models;

namespace AppCrudEFCore.Controllers
{
    public class OrderController
    {
        private readonly OrderRepository _orderRepo = new();
        private readonly UserRepository _userRepo = new();
        private readonly ProductRepository _productRepo = new();

        public void CreateOrder()
        {
            Console.Write("ID Utente: ");
            int userId = int.Parse(Console.ReadLine());

            Console.Write("ID Prodotto: ");
            int productId = int.Parse(Console.ReadLine());

            Console.Write("Quantità: ");
            int quantita = int.Parse(Console.ReadLine());
            while(quantita <= 0)
            {
                Console.Write("Quantità deve essere maggiore di 0: ");

                quantita = int.Parse(Console.ReadLine());
            }

            var user = _userRepo.GetById(userId);
            var product = _productRepo.GetById(productId);

            if (user == null)
            {
                Console.WriteLine("Utente non trovato.");
                return;
            }
            
            if (product == null)
            {
                Console.WriteLine("Prodotto non trovato.");
                return;
            }

            var order = new Order
            {
                UserId = userId,
                ProductId = productId,
                Quantity = quantita,
                OrderDate = DateTime.Now
            };

            _orderRepo.Insert(order);
            Console.WriteLine("Ordine inserito con successo.");
        }

        public void ListOrders()
        {
            var orders = _orderRepo.GetAll();

            Console.WriteLine("\n--- LISTA ORDINI ---");
            foreach (var o in orders)
            {
                Console.WriteLine(
                    $"{o.OrderId} | Utente: {o.User.FullName} | Prodotto: {o.Product.Name} | Quantity : {o.Quantity} | Data: {o.OrderDate}"
                );
            }
        }

        public void DeleteOrder()
        {
            Console.Write("ID ordine da eliminare: ");
            int id = int.Parse(Console.ReadLine());

            _orderRepo.Delete(id);
            Console.WriteLine("Ordine eliminato con successo.");
        }
    }
}
