using Models.Domain;

namespace DataAcess.Repos.IRepos
{
	public interface IOrderRepository : IRepository<Order>
	{
		Task<Order> GetByIdAsync(int id);
		void Update(Order order);
		Task<bool> SaveChangesAsync();
		Task<Order> GetByBuyerIdAsync(string id);
	}
}
