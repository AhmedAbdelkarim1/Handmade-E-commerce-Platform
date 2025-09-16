using Models.Domain;

namespace DataAcess.Repos.IRepos
{
	public interface IProductRepository
	{
		Task<List<Product>> GetAllProducts();

		Task<Product?> GetProductByIdAsync(int id);
		Task<List<Product>> GetAllProductsBySeriviceId(int seriviceId);
		Task<List<Product>> GetAllProductsBySellerId(string sellerId);

		Task CreateProductAsync(Product product);
		Task UpdateProductAsync(Product product);
		Task<Product> UpdateProductReasonAsync(int id, string Reason);
		Task DeleteProductAsync(Product p);
		Task<int> SaveAsync();
		Task<Product?> UpdateProductStatusAsync(int id, string status);

	}
}
