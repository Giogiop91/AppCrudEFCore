using AppCrudEFCore.Controllers;

class Program
{
    static void Main(string[] args)
    {
        var userController = new UserController();
        var productController = new ProductController();
        var orderController = new OrderController();

        while (true)
        {
            Console.WriteLine("\n=== MENU PRINCIPALE ===");
            Console.WriteLine("1. Gestione Utenti");
            Console.WriteLine("2. Gestione Prodotti");
            Console.WriteLine("3. Gestione Ordini");
            Console.WriteLine("0. Esci");
            Console.Write("Scelta: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    MenuUtenti(userController);
                    break;

                case "2":
                    MenuProdotti(productController);
                    break;

                case "3":
                    MenuOrdini(orderController);
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }
    }

    static void MenuUtenti(UserController controller)
    {
        Console.WriteLine("\n--- MENU UTENTI ---");
        Console.WriteLine("1. Crea Utente");
        Console.WriteLine("2. Lista Utenti");
        Console.WriteLine("3. Aggiorna Utente");
        Console.WriteLine("4. Elimina Utente");
        Console.WriteLine("0. Torna al menu principale");
        Console.Write("Scelta: ");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1": controller.CreateUser(); break;
            case "2": controller.ListUsers(); break;
            case "3": controller.UpdateUser(); break;
            case "4": controller.DeleteUser(); break;
            case "0": return;
            default: Console.WriteLine("Scelta non valida."); break;
        }
    }

    static void MenuProdotti(ProductController controller)
    {
        Console.WriteLine("\n--- MENU PRODOTTI ---");
        Console.WriteLine("1. Crea Prodotto");
        Console.WriteLine("2. Lista Prodotti");
        Console.WriteLine("3. Aggiorna Prodotto");
        Console.WriteLine("4. Elimina Prodotto");
        Console.WriteLine("0. Torna al menu principale");
        Console.Write("Scelta: ");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1": controller.CreateProduct(); break;
            case "2": controller.ListProducts(); break;
            case "3": controller.UpdateProduct(); break;
            case "4": controller.DeleteProduct(); break;
            case "0": return;
            default: Console.WriteLine("Scelta non valida."); break;
        }
    }

    static void MenuOrdini(OrderController controller)
    {
        Console.WriteLine("\n--- MENU ORDINI ---");
        Console.WriteLine("1. Crea Ordine");
        Console.WriteLine("2. Lista Ordini");
        Console.WriteLine("3. Elimina Ordine");
        Console.WriteLine("0. Torna al menu principale");
        Console.Write("Scelta: ");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1": controller.CreateOrder(); break;
            case "2": controller.ListOrders(); break;
            case "3": controller.DeleteOrder(); break;
            case "0": return;
            default: Console.WriteLine("Scelta non valida."); break;
        }
    }
}
