using Models.Domain;

namespace DataAcess.Repos.IRepos
{
	public interface IServiceReviewRepository
	{
		IEnumerable<ServiceReview> GetAll();
		ServiceReview GetById(int id);
		ServiceReview Add(ServiceReview serviceReview);
		ServiceReview Update(ServiceReview serviceReview);
		bool Delete(int id);
		IEnumerable<ServiceReview> GetByServiceId(int serviceId);
		void SavaChange();

	}
}
