#region
namespace NullPointersEtc.ThreeControllers.Models;

public class Product
{
    public Product() {
        myID = null;
        myName = null;
        myPrice = null;
    }
    public Product(ProductCreateDTO from)
    {
        myID = null;
        myName = from.Name;
        myPrice = from.Price;
    }
    public Product(ProductDTO from)
    {
        myID = from.ID;
        myName = from.Name;
        myPrice = from.Price;
    }
    public int ID
    {
        get => myID ?? throw new InvalidOperationException(nameof(ID) + " has not been set");
        set => myID = value > 0 ? value : throw new ArgumentOutOfRangeException(paramName:nameof(ID), "positive integer required");
    }

    public string Name
    {
        get => myName ?? throw new InvalidOperationException(nameof(Name)+" has not been set");
        set => myName = string.IsNullOrEmpty(value)
            ? throw new ArgumentOutOfRangeException(paramName: nameof(Name), message: " cannot be null or empty.")
            : value;
    }

    public decimal Price
    {
        get => myPrice ?? throw new InvalidOperationException(nameof(Price)+" has not been set");
        set => myPrice = value > 0.0M ? value : throw new ArgumentOutOfRangeException(paramName: nameof(Name), message: "must be positive");
    }

    private int? myID;
    private string? myName;
    private decimal? myPrice;
}

public class ProductCreateDTO
{
    public ProductCreateDTO()
    {
        myName = null;
        myPrice = null;
    }

    public string Name
    {
        get => myName ?? throw new InvalidOperationException(nameof(Name) + " has not been set");
        set => myName = string.IsNullOrEmpty(value)
            ? throw new ArgumentOutOfRangeException(paramName: nameof(Name), message: " cannot be null or empty.")
            : value;
    }

    public decimal Price
    {
        get => myPrice ?? throw new InvalidOperationException(nameof(Price) + " has not been set");
        set => myPrice = value > 0.0M ? value : throw new ArgumentOutOfRangeException(paramName: nameof(Name), message: "must be positive");
    }

    private string? myName;
    private decimal? myPrice;
}

public class ProductDTO
{
    public ProductDTO()
    {
        myID = null;
        myName = null;
        myPrice = null;
    }

    public ProductDTO(Product from)
    {
        myID = from.ID;
        myName = from.Name;
        myPrice = from.Price;
    }

    public int ID
    {
        get => myID ?? throw new InvalidOperationException(nameof(ID) + " has not been set");
        set => myID = value > 0 ? value : throw new ArgumentOutOfRangeException(paramName: nameof(ID), "positive integer required");
    }

    public string Name
    {
        get => myName ?? throw new InvalidOperationException(nameof(Name) + " has not been set");
        set => myName = string.IsNullOrEmpty(value)
            ? throw new ArgumentOutOfRangeException(paramName: nameof(Name), message: " cannot be null or empty.")
            : value;
    }

    public decimal Price
    {
        get => myPrice ?? throw new InvalidOperationException(nameof(Price) + " has not been set");
        set => myPrice = value > 0.0M ? value : throw new ArgumentOutOfRangeException(paramName: nameof(Name), message: "must be positive");
    }

    private int? myID;
    private string? myName;
    private decimal? myPrice;
}

#endregion

