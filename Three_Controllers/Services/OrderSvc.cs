namespace NullPointersEtc.Three_Controllers.Services
{
    using Order_t = NullPointersEtc.Three_Controllers.Models.OrderDTO;

    public interface IOrderService
    {
        IEnumerable<Order_t> GetAll();
        Order_t? GetById(int id);
        void PlaceOrder(Order_t order);
        void CancelOrder(int id);
    }

    public class OrderService : IOrderService
    {
        private readonly List<Order_t> _orders = new();

        public IEnumerable<Order_t> GetAll() => _orders;

        public Order_t? GetById(int id) => _orders.FirstOrDefault(o => o.Id == id);

        public void PlaceOrder(Order_t order) => _orders.Add(order);

        public void CancelOrder(int id) => _orders.RemoveAll(o => o.Id == id);
    }
}
