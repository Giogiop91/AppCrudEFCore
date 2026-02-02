using AppCrudEFCore.Data;
using AppCrudEFCore.Models;

namespace AppCrudEFCore.Controllers
{
    public class UserController
    {
        private readonly UserRepository _repo = new();

        public void CreateUser()
        {
            Console.Write("Nome completo: ");
            string name = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            var user = new User
            {
                FullName = name,
                Email = email,
                CreatedAt = DateTime.Now
            };

            _repo.Insert(user);
            Console.WriteLine("Utente inserito con successo.");
        }

        public void ListUsers()
        {
            var users = _repo.GetAll();

            Console.WriteLine("\n--- LISTA UTENTI ---");
            foreach (var u in users)
            {
                Console.WriteLine($"{u.UserId} | {u.FullName} | {u.Email} | {u.CreatedAt}");
            }
        }

        public void UpdateUser()
        {
            Console.Write("ID utente da aggiornare: ");
            int id = int.Parse(Console.ReadLine());

            var existing = _repo.GetById(id);
            if (existing == null)
            {
                Console.WriteLine("Utente non trovato.");
                return;
            }

            Console.Write("Nuovo nome: ");
            existing.FullName = Console.ReadLine();

            Console.Write("Nuova email: ");
            existing.Email = Console.ReadLine();

            _repo.Update(existing);
            Console.WriteLine("Utente aggiornato con successo.");
        }

        public void DeleteUser()
        {
            Console.Write("ID utente da eliminare: ");
            int id = int.Parse(Console.ReadLine());

            _repo.Delete(id);
            Console.WriteLine("Utente eliminato con successo.");
        }
    }
}
