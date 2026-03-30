using DatabaseContext = NullPointersEtc.ThreeControllers.Data.Context;
using Order_t = NullPointersEtc.ThreeControllers.Models.Order;
using Guid_t = System.Guid;

namespace NullPointersEtc.ThreeControllers.Services;

public interface IOrderService
{
    IEnumerable<Order_t> GetAll();
    Order_t? GetById(Guid_t id);
    void PlaceOrder(Order_t order);
    void CancelOrder(Guid_t id);
}

public class OrderService : IOrderService
{
    public OrderService(DatabaseContext context) =>
        myContext = context;

    private readonly DatabaseContext myContext;

    public IEnumerable<Order_t> GetAll() => myContext.Orders.ToList();

    public Order_t? GetById(Guid_t id) =>
        myContext.Orders.FirstOrDefault(o => o.OrderID == id);

    public void PlaceOrder(Order_t order)
    {
        myContext.Orders.Add(order);
        myContext.SaveChanges();
    }

    public void CancelOrder(Guid_t id)
    {
        Order_t? order = myContext.Orders.FirstOrDefault(ord => ord.OrderID == id);
        if (order is not null)
        {
            myContext.Orders.Remove(order);
            myContext.SaveChanges();
        }
    }
}
