using AppCrudEFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace AppCrudEFCore.Data
{
    public class OrderRepository
    {
        private readonly AppDbContext _context = new AppDbContext();

        public void Insert(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public List<Order> GetAll()
        {
            return _context.Orders
                .AsNoTracking()
                .Include(o => o.User)
                .Include(o => o.Product)
                .ToList();
        }

        public Order GetById(int id)
        {
            return _context.Orders
                .AsNoTracking()
                .Include(o => o.User)
                .Include(o => o.Product)
                .FirstOrDefault(o => o.OrderId == id);
        }



        public void Delete(int id)
        {
            var order = _context.Orders.Find(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }
    }
}
