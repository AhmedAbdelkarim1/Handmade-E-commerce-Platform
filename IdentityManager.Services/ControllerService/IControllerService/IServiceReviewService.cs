using Models.DTOs.ServiceReview;

namespace IdentityManager.Services.ControllerService.IControllerService
{
	public interface IServiceReviewService
	{
		IEnumerable<ServiceReviewDto> GetAll();
		ServiceReviewDto GetById(int id);
		ServiceReviewDto Create(CreateServiceReviewDto dto);
		ServiceReviewDto Update(int id, UpdateServiceReviewDto dto);
		bool Delete(int id);
		IEnumerable<ServiceReviewDto> GetByServiceId(int serviceId);
	}
}
