using Models.Domain;

namespace DataAcess.Repos.IRepos
{
	public interface ICustomRequestRepository : IRepository<CustomRequest>
	{
		Task<CustomRequest> GetByIdAsync(int id);
		void Update(CustomRequest request);
		Task<bool> SaveChangesAsync();

	}
}
