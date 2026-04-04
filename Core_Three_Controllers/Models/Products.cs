#region "Products.cs"
using Guid = System.Guid;
using StringLength = System.ComponentModel.DataAnnotations.StringLengthAttribute;
using Precision = Microsoft.EntityFrameworkCore.PrecisionAttribute;
using Unicode = Microsoft.EntityFrameworkCore.UnicodeAttribute;

namespace NullPointersEtc.ThreeControllers.Models;

public class Product
{
    public Product() { }

    public Product(
        Guid id,
        string name,
        decimal price)
    {
        myID.ID = id;
        myName.Name = name;
        myPrice.Price = price;
    }

    public Product(ProductCreateDTO from)
    {
        myName.Name = from.Name;
        myPrice.Price = from.Price;
    }

    public Product(ProductDTO from)
    {
        myID.ID = from.ID;
        myName.Name = from.Name;
        myPrice.Price = from.Price;
    }

    public Guid ID
    {
        get => myID.ID;
        set => myID.ID = value;
    }

    [property: Unicode(unicode: true),
        StringLength(maximumLength: ProductName.MaxLength,
        MinimumLength = ProductName.MinLength)]
    public string Name
    {
        get => myName.Name;
        set => myName.Name = value;
    }

    [property: Precision(
        precision: ProductPrice.Precision,
        scale: ProductPrice.Scale)]
    public decimal Price
    {
        get => myPrice.Price;
        set => myPrice.Price = value;
    }

    private ProductID myID;
    private ProductName myName;
    private ProductPrice myPrice;
}

public class ProductCreateDTO
{
    public ProductCreateDTO() { }

    public ProductCreateDTO(
        string name, decimal price)
    {
        myName.Name = name;
        myPrice.Price = price;
    }


    [property: Unicode(unicode: true),
        StringLength(maximumLength: ProductName.MaxLength,
        MinimumLength = ProductName.MinLength)]
    public string Name
    {
        get => myName.Name;
        set => myName.Name = value;
    }

    [property: Precision(
        precision: ProductPrice.Precision,
        scale: ProductPrice.Scale)]
    public decimal Price
    {
        get => myPrice.Price;
        set => myPrice.Price = value;
    }

    private ProductName myName;
    private ProductPrice myPrice;
}

public class ProductDTO
{
    public ProductDTO()
    {
    }

    public ProductDTO(Guid id,
        string name, decimal price)
    {
        myID.ID = id;
        myName.Name = name;
        myPrice.Price = price;
    }

    public ProductDTO(Product from)
    {
        myID.ID = from.ID;
        myName.Name = from.Name;
        myPrice.Price = from.Price;
    }

    public Guid ID
    {
        get => myID.ID;
        set => myID.ID = value;
    }

    [property: Unicode(unicode: true),
        StringLength(maximumLength: ProductName.MaxLength,
        MinimumLength = ProductName.MinLength)]
    public string Name
    {
        get => myName.Name;
        set => myName.Name = value;
    }

    [property: Precision(
        precision: ProductPrice.Precision,
        scale: ProductPrice.Scale)]
    public decimal Price
    {
        get => myPrice.Price;
        set => myPrice.Price = value;
    }

    private ProductID myID;
    private ProductName myName;
    private ProductPrice myPrice;
}

internal struct ProductID
{
    internal Guid ID
    {
        get => myID ??
            throw new ArgumentNullException(
                paramName: nameof(ID),
                message: "has not been set");

        set => myID = value;
    }

    private Guid? myID;
}

internal struct ProductName
{
    internal string Name
    {
        get => myName ??
            throw new ArgumentNullException(
                paramName: nameof(Name),
                message: "has not been set");

        set => myName = value is null
            ? throw new ArgumentNullException(
                paramName: nameof(Name),
                message: "cannot be null")
            : value.Length < MinLength
            ? throw new ArgumentOutOfRangeException(
                paramName: nameof(Name),
                message: "cannot be empty")
            : value.Length > MaxLength
            ? throw new ArgumentOutOfRangeException(
                paramName: nameof(Name),
                message: "cannot be longer than " +
                MaxLength.ToString() + " characters")
            : value;
    }

    internal const int MinLength = 1, MaxLength = 100;

    private string? myName;
}

internal struct ProductPrice
{
    public decimal Price
    {
        get => myPrice ??
            throw new ArgumentNullException(
                paramName: nameof(Price),
                message: " has not been set");

        set => myPrice = value > 0.0M ? value
            : throw new ArgumentOutOfRangeException(
                paramName: nameof(Price),
                message: "must be positive");
    }

    public const int Precision = 18, Scale = 2;
    private decimal? myPrice;
}

#endregion "Products.cs"

