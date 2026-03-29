namespace NullPointersEtc.Three_Controllers.Services
{
    using DatabaseContext = NullPointersEtc.Three_Controllers.Data.DatabaseContext;
    using Order_t = NullPointersEtc.Three_Controllers.Models.Order;

    public interface IOrderService
    {
        IEnumerable<Order_t> GetAll();
        Order_t? GetById(int id);
        void PlaceOrder(Order_t order);
        void CancelOrder(int id);
    }

    public class OrderService : IOrderService
    {
        public OrderService(DatabaseContext context)
        {
            m_context = context;
        }

        private readonly DatabaseContext m_context;

        public IEnumerable<Order_t> GetAll() => m_context.Orders.ToList();

        public Order_t? GetById(int id) => m_context.Orders.FirstOrDefault(o => o.Id == id);

        public void PlaceOrder(Order_t order)
        {
            m_context.Orders.Add(order);
            m_context.SaveChanges();
        }

        public void CancelOrder(int id)
        {
            Order_t? order = m_context.Orders.FirstOrDefault(ord => ord.Id == id);
            if (order is not null)
            {
                m_context.Orders.Remove(order);
                m_context.SaveChanges();
            }
        }
    }
}
