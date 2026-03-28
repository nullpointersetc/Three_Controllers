namespace NullPointersEtc.Three_Controllers.Services
{
    using ProductDTO_t=NullPointersEtc.Three_Controllers.Models.ProductDTO;

    public interface IProductService
    {
        IEnumerable<ProductDTO_t> GetAll();
        ProductDTO_t? GetById(int id);
        void Create(ProductDTO_t product);
        void Update(ProductDTO_t product);
        void Delete(int id);
    }

    public class ProductService : IProductService
    {
        private readonly List<ProductDTO_t> _products = new();

        public IEnumerable<ProductDTO_t> GetAll() => _products;

        public ProductDTO_t? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);

        public void Create(ProductDTO_t product) => _products.Add(product);

        public void Update(ProductDTO_t product)
        {
            var existing = GetById(product.Id);
            if (existing != null)
            {
                existing.Name = product.Name;
                existing.Price = product.Price;
            }
        }

        public void Delete(int id) => _products.RemoveAll(p => p.Id == id);
    }
}