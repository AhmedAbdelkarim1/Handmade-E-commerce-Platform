using Models.DTOs.Categories;

namespace IdentityManager.Services.ControllerService.IControllerService
{
	public interface ICategoryService
	{
		Task<IEnumerable<CategoryDto>> GetAllAsync();
		Task<CategoryDto> GetByIdAsync(int id);
		Task<CategoryDto> CreateAsync(string? userId, CreateCategoryDto dto);
		Task<CategoryDto> UpdateAsync(string? userId, int id, UpdateCategoryDto dto);
		Task DeleteAsync(int id);
        Task<CategoryDto> SearchByName(string name);
	}
}
