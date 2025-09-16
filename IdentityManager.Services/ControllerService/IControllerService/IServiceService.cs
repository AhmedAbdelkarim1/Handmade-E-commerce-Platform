using Models.Domain;
using Models.DTOs.Service;

namespace IdentityManager.Services.ControllerService.IControllerService
{
	public interface IServiceService
	{
		IEnumerable<ServiceDto> GetAll();
		ServiceDto GetByID(int id);
		ServiceDto Create(CreateServiceDto dto);
		ServiceDto Update(int id, UpdateServiceDto dto);
		bool Delete(int id);
		IEnumerable<ServiceDto> GetAllBySellerId(string sellerId);
		IEnumerable<ServiceDto> GetAllByCategoryId(int categoryId);
		IEnumerable<ServiceDto> GetMyServices();
		IEnumerable<ServiceDto> GetAllByCategoryName(string categoryName);
		Task<Service?> UpdateServiceStatusAsync(int id, UpdateServiceStatusDTO dto);
		Task<Service?> UpdateServiceReason(int id, UpdateServiceReason dto);


	}
}
