using Models.Domain;
using Models.DTOs.Categories;

namespace DataAcess.Repos.IRepos
{
	public interface ICategoryRepository
	{
		Task<IEnumerable<CategoryDto>> GetAllAsync();
		Task<CategoryDto> GetByIdForDisplayAsync(int id);
		Task<Category> GetByIdForTrackingAsync(int id);
		Task<Category> AddAsync(Category category);
		Task<Category> UpdateAsync(Category category);
		Task DeleteAsync(int id);
        Task<IEnumerable<Category>> SearchByName(string name);
	}
}
