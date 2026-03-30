#region
using ListOfProducts = System.Collections.Generic.List<NullPointersEtc.ThreeControllers.Models.Product>;

using ListOfProductsDTO = System.Collections.Generic.List<NullPointersEtc.ThreeControllers.Models.ProductDTO>;

namespace NullPointersEtc.ThreeControllers.Models;

public class Order
{
    public Order()
    {
        myOrderID = null;
        myReceiver = null;
        myProducts = null;
    }

    public Order(OrderCreateDTO from)
    {
        myOrderID = null;
        myReceiver = new User(from: from.Receiver);
        myProducts = from.Products.ConvertAll(p => new Product(from: p));
    }

    public Order(OrderDTO from)
    {
        myOrderID = from.OrderID;
        myReceiver = new User(from: from.Receiver);
        myProducts = from.Products.ConvertAll(p => new Product(from: p));
    }

    public int OrderID
    {
        get => myOrderID ?? throw new InvalidOperationException(nameof(OrderID) + " has not been set");
        set => myOrderID = value > 0 ? value : throw new ArgumentOutOfRangeException(paramName: nameof(OrderID), "positive integer required");
    }

    public User Receiver
    {
        get => myReceiver ?? throw new InvalidOperationException(nameof(Receiver) + " has not been set");
        set => myReceiver = value ?? throw new ArgumentOutOfRangeException(paramName: nameof(Receiver), message: "must be positive");
    }

    public ListOfProducts Products
    {
        get => myProducts ?? throw new InvalidOperationException(nameof(Products) + " has not been set");
        set => myProducts = value ??  throw new ArgumentOutOfRangeException(paramName: nameof(Products), message: "must not be null");
    }

    private int? myOrderID;
    private User? myReceiver;
    private ListOfProducts? myProducts;
}

public class OrderCreateDTO
{
    public OrderCreateDTO()
    {
        myReceiver = null;
        myProducts = null;
    }

    public UserDTO Receiver
    {
        get => myReceiver ?? throw new InvalidOperationException(nameof(Receiver) + " has not been set");
        set => myReceiver = value ?? throw new ArgumentOutOfRangeException(paramName: nameof(Receiver), message: "must not be null");
    }

    public ListOfProductsDTO Products
    {
        get => myProducts ?? throw new InvalidOperationException(nameof(Products) + " has not been set");
        set => myProducts = value ?? throw new ArgumentOutOfRangeException(paramName: nameof(Products), message: "must not be null");
    }

    private UserDTO? myReceiver;
    private ListOfProductsDTO? myProducts;
}

public class OrderDTO
{
    public OrderDTO()
    {
        myOrderID = null;
        myReceiver = null;
        myProducts = null;
    }

    public OrderDTO(Order from)
    {
        myOrderID = from.OrderID;
        myReceiver = new UserDTO( from.Receiver);
        myProducts = from.Products.ConvertAll(p => new ProductDTO(from: p));
    }

    public int OrderID
    {
        get => myOrderID ?? throw new InvalidOperationException(nameof(OrderID) + " has not been set");
        set => myOrderID = value > 0 ? value : throw new ArgumentOutOfRangeException(paramName: nameof(OrderID), "positive integer required");
    }

    public UserDTO Receiver
    {
        get => myReceiver ?? throw new InvalidOperationException(nameof(Receiver) + " has not been set");
        set => myReceiver = value ?? throw new ArgumentNullException(paramName: nameof(Receiver), message: "must not be null");
    }

    public ListOfProductsDTO Products
    {
        get => myProducts ?? throw new InvalidOperationException(nameof(Products) + " has not been set");
        set => myProducts = value ??  throw new ArgumentOutOfRangeException(paramName: nameof(Products), message: "must not be null");
    }

    private int? myOrderID;
    private UserDTO? myReceiver;
    private ListOfProductsDTO? myProducts;
}

#endregion

