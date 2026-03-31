using Microsoft.AspNetCore.Mvc;
using NullPointersEtc.ThreeControllers.Controllers;
using NullPointersEtc.ThreeControllers.Models;
using NullPointersEtc.ThreeControllers.Services;

namespace NullPointersEtc.ThreeControllers.Tests.Controllers;

#region "MockProductService"

public sealed class MockProductService : IProductService
{
    // Configurable responses
    public IEnumerable<Product> GetAllResult { get; set; } = [];
    public Product? GetByIdResult { get; set; } = new();

    // Call tracking
    public Guid LastGetByIdId { get; private set; }
    public Product? LastCreatedProduct { get; private set; }
    public Guid LastDeletedId { get; private set; }
    public int CreateCallCount { get; private set; }
    public int DeleteCallCount { get; private set; }

    public IEnumerable<Product> GetAll() => GetAllResult;

    public Product GetById(Guid id)
    {
        LastGetByIdId = id;
        return GetByIdResult ?? throw new KeyNotFoundException($"No product with id {id}");
    }

    public void Create(Product product)
    {
        LastCreatedProduct = product;
        CreateCallCount++;
    }

    public void Update(Product product) => throw new NotImplementedException();

    public void Delete(Guid id)
    {
        LastDeletedId = id;
        DeleteCallCount++;
    }
}

#endregion "MockProductService"

#region "Tests"

public class ProductsControllerTests
{
    private readonly MockProductService myService = new();
    private ProductsController CreateSystemUnderTest() => new(myService);

    #region "------------ GetAll ------------"

    public class GetAll : ProductsControllerTests
    {
        [Fact]
        public void Returns_Ok()
        {
            var result = CreateSystemUnderTest().GetAll();

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Returns_All_Products_From_Service()
        {
            List<Product> products = new List<Product> { new(), new() };
            myService.GetAllResult = products;

            OkObjectResult result = (OkObjectResult)CreateSystemUnderTest().GetAll();

            Assert.Equal(products, result.Value);
        }

        [Fact]
        public void Returns_Empty_List_When_No_Products()
        {
            myService.GetAllResult = [];

            OkObjectResult result = (OkObjectResult)CreateSystemUnderTest().GetAll();

            IEnumerable<Product> list = Assert.IsAssignableFrom<IEnumerable<Product>>(result.Value);
            Assert.Empty(list);
        }
    }

    #endregion "------------ GetAll ------------"

    #region "------------ GetProduct ------------"

    public class GetProduct : ProductsControllerTests
    {
        [Fact]
        public void Returns_Ok_When_Product_Exists()
        {
            var result = CreateSystemUnderTest().GetProduct(Guid.NewGuid());

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Returns_Correct_Product()
        {
            var id = Guid.NewGuid();
            var product = new Product { ID = id };
            myService.GetByIdResult = product;

            var result = (OkObjectResult)CreateSystemUnderTest().GetProduct(id);

            Assert.Equal(product, result.Value);
        }

        [Fact]
        public void Passes_Correct_Id_To_Service()
        {
            var id = Guid.NewGuid();

            CreateSystemUnderTest().GetProduct(id);

            Assert.Equal(id, myService.LastGetByIdId);
        }
    }

    #endregion "------------ GetProduct ------------"

    #region "------------ Create ------------"

    public class Create : ProductsControllerTests
    {
        [Fact(Skip = "This doesn't currently work because the create parameters are not filled in.")]
        public void Returns_CreatedAtAction()
        {
            var result = CreateSystemUnderTest().Create(new ProductCreateDTO());

            Assert.IsType<CreatedAtActionResult>(result);
        }

        [Fact(Skip = "This doesn't currently work because the create parameters are not filled in.")]
        public void CreatedAtAction_Points_To_GetProduct()
        {
            var result = (CreatedAtActionResult)CreateSystemUnderTest().Create(new ProductCreateDTO());

            Assert.Equal(nameof(ProductsController.GetProduct), result.ActionName);
        }

        [Fact(Skip = "This doesn't currently work because the create parameters are not filled in.")]
        public void CreatedAtAction_RouteValues_Contain_New_Id()
        {
            var result = (CreatedAtActionResult)CreateSystemUnderTest().Create(new ProductCreateDTO());

            Assert.NotNull(result.RouteValues);
            Assert.True(result.RouteValues.ContainsKey("Id"));
            var id = Assert.IsType<Guid>(result.RouteValues["Id"]);
            Assert.NotEqual(Guid.Empty, id);
        }

        [Fact(Skip = "This doesn't currently work because the create parameters are not filled in.")]
        public void Returns_ProductDTO_As_Value()
        {
            var result = (CreatedAtActionResult)CreateSystemUnderTest().Create(new ProductCreateDTO());

            Assert.IsType<ProductDTO>(result.Value);
        }

        [Fact(Skip = "This doesn't currently work because the create parameters are not filled in.")]
        public void Calls_Service_Create_Exactly_Once()
        {
            CreateSystemUnderTest().Create(new ProductCreateDTO());

            Assert.Equal(1, myService.CreateCallCount);
        }

        [Fact(Skip = "This doesn't currently work because the create parameters are not filled in.")]
        public void Passes_Product_Built_From_Dto_To_Service()
        {
            var dto = new ProductCreateDTO { /* set properties */ };

            CreateSystemUnderTest().Create(dto);

            Assert.NotNull(myService.LastCreatedProduct);
        }

        [Fact]
        public void Throws_ArgumentNullException_When_Dto_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(() => CreateSystemUnderTest().Create(null!));
        }

        [Fact]
        public void Does_Not_Call_Service_When_Dto_Is_Null()
        {
            try { CreateSystemUnderTest().Create(null!); } catch (ArgumentNullException) { }

            Assert.Equal(0, myService.CreateCallCount);
        }
    }

    #endregion "------------ Create ------------"

    #region "------------ DeleteProduct ------------"

    public class DeleteProduct : ProductsControllerTests
    {
        [Fact]
        public void Returns_Ok()
        {
            var result = CreateSystemUnderTest().DeleteProduct(Guid.NewGuid());

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void Passes_Correct_Id_To_Service()
        {
            var id = Guid.NewGuid();

            CreateSystemUnderTest().DeleteProduct(id);

            Assert.Equal(id, myService.LastDeletedId);
        }

        [Fact]
        public void Calls_Service_Delete_Exactly_Once()
        {
            CreateSystemUnderTest().DeleteProduct(Guid.NewGuid());

            Assert.Equal(1, myService.DeleteCallCount);
        }
    }

    #endregion "------------ DeleteProduct ------------"
}

#endregion "Tests"
