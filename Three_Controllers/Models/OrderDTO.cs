namespace NullPointersEtc.Three_Controllers.Models
{
    using ListOfProductsDTO = System.Collections.Generic.List<NullPointersEtc.Three_Controllers.Models.ProductDTO>;
    using ListOfProducts = System.Collections.Generic.List<NullPointersEtc.Three_Controllers.Models.Product>;
    public class OrderDTO
    {
        public int Id { get; set; }
        public int User { get; set; }
        public ListOfProductsDTO Products {
            get => m_products;
            set => m_products = value;
        }

        private ListOfProductsDTO m_products = new();
    }

    public class Order
    {
        public static Order From(OrderDTO from) => new Order {
            Id = from.Id,
            User = from.User,
            Products = from.Products.ConvertAll(p => Product.From(p)) };

        public OrderDTO AsDTO() => new OrderDTO{
            Id= this.Id,
            User = this.User,
            Products = this.Products.ConvertAll(p => p.AsDTO()) };

        public int Id { get; set; }
        public int User { get; set; }
        public ListOfProducts Products { get => m_products; set => m_products = value; }
        private ListOfProducts m_products = new();
    }
}
