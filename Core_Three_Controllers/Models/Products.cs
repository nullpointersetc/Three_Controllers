#region "Products.cs"
using Guid_t = System.Guid;
using Precision_a = Microsoft.EntityFrameworkCore.PrecisionAttribute;

namespace NullPointersEtc.ThreeControllers.Models;

public class Product
{
    public Product()
    {
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

    public Guid_t ID
    {
        get => myID ??
            throw new ArgumentNullException(
                paramName: nameof(ID),
                message: "has not been set");

        set => myID = value;
    }

    public string Name
    {
        get => myName ??
            throw new ArgumentNullException(
                paramName: nameof(Name),
                message: "has not been set");

        set => myName = value is null
            ? throw new ArgumentNullException(
                paramName: nameof(Name),
                message: "cannot be null")
            : value.Length == 0
            ? throw new ArgumentOutOfRangeException(
                paramName: nameof(Name),
                message: "cannot be empty")
            : value.Length > 100
            ? throw new ArgumentOutOfRangeException(
                paramName: nameof(Name),
                message: "cannot be longer than 100 characters")
            : value;
    }

    [property: Precision_a(18, 2)]
    public decimal Price
    {
        get => myPrice ??
            throw new ArgumentNullException(
                paramName: nameof(Price),
                message: " has not been set");

        set => myPrice = value > 0.0M ? value
            : throw new ArgumentOutOfRangeException(
                paramName: nameof(Name),
                message: "must be positive");
    }

    private Guid_t? myID;
    private string? myName;

    [field: Precision_a(18, 2)]
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
        get => myName ??
            throw new ArgumentNullException(
                paramName: nameof(Name),
                message: "has not been set");

        set => myName = value is null
            ? throw new ArgumentNullException(
                paramName: nameof(Name),
                message: "cannot be null")
            : value.Length == 0
            ? throw new ArgumentOutOfRangeException(
                paramName: nameof(Name),
                message: "cannot be empty")
            : value.Length > 100
            ? throw new ArgumentOutOfRangeException(
                paramName: nameof(Name),
                message: "cannot be longer than 100 characters")
            : value;
    }

    [property: Precision_a(18, 2)]
    public decimal Price
    {
        get => myPrice ??
            throw new ArgumentNullException(
                paramName: nameof(Price),
                message: " has not been set");

        set => myPrice = value > 0.0M ? value
            : throw new ArgumentOutOfRangeException(
                paramName: nameof(Name),
                message: "must be positive");
    }

    private string? myName;

    [field: Precision_a(18, 2)]
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

    public Guid_t ID
    {
        get => myID ??
            throw new ArgumentNullException(
                paramName: nameof(ID),
                message: "has not been set");

        set => myID = value;
    }

    public string Name
    {
        get => myName ??
            throw new ArgumentNullException(
                paramName: nameof(Name),
                message: "has not been set");

        set => myName = value is null
            ? throw new ArgumentNullException(
                paramName: nameof(Name),
                message: "cannot be null")
            : value.Length == 0
            ? throw new ArgumentOutOfRangeException(
                paramName: nameof(Name),
                message: "cannot be empty")
            : value.Length > 100
            ? throw new ArgumentOutOfRangeException(
                paramName: nameof(Name),
                message: "cannot be longer than 100 characters")
            : value;
    }

    [property: Precision_a(18, 2)]
    public decimal Price
    {
        get => myPrice ??
            throw new ArgumentNullException(
                paramName: nameof(Price),
                message: " has not been set");

        set => myPrice = value > 0.0M ? value
            : throw new ArgumentOutOfRangeException(
                paramName: nameof(Name),
                message: "must be positive");
    }

    private Guid_t? myID;
    private string? myName;

    [field: Precision_a(18, 2)]
    private decimal? myPrice;
}

#endregion "Products.cs"

