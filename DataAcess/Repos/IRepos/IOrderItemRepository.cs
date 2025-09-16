using Models.Domain;

namespace DataAcess.Repos.IRepos
{
	public interface IOrderItemRepository : IRepository<OrderItem>
	{
		Task<OrderItem> GetByIdAsync(int id);
		void Update(OrderItem item);
		Task<bool> SaveChangesAsync();
	}
}
