namespace NullPointersEtc.Three_Controllers.Models
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get => m_Name; set => m_Name = value; }
        public decimal Price { get; set; }
        private string m_Name = string.Empty;
    }

    public class Product {
        public static Product From(ProductDTO from) => new Product { Id = from.Id, Name = from.Name, Price = from.Price };

        public ProductDTO AsDTO() => new ProductDTO { Id = this.Id, Name = this.Name, Price = this.Price };

        public int Id { get; set; }
        public string Name { get => m_Name; set => m_Name = value; }
        public decimal Price { get; set; }

        private string m_Name = string.Empty;
    }
}
