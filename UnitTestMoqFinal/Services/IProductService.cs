using UnitTestMoqFinal.Models;

namespace UnitTestMoqFinal.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetProductList();
        Product GetProductById(int id);
        Product AddProduct(Product product);
        Product UpdateProduct(Product product);
        bool DeleteProduct(int Id);
        Task<dynamic> MusicList();

    }
}
