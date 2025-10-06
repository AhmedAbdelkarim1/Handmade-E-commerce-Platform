using DataAcess.CustomExceptions;
using DataAcess.Repos.IRepos;
using Microsoft.EntityFrameworkCore;
using Models.Const;
using Models.Domain;
using Models.DTOs.Categories;
using System.Threading.Tasks;

namespace DataAcess.Repos
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly ApplicationDbContext _db;
		public CategoryRepository(ApplicationDbContext db)
		{
			_db = db;
		}

		public async Task<IEnumerable<CategoryDto>> GetAllAsync()
		{
			var categories = await _db.Categories
				.Where(c => !c.IsDeleted)
				.Select(c => new CategoryDto
				{
					Name = c.Name,
					Id = c.Id,
					ImageUrl = !c.ImageId.HasValue ? null : c.Image!.FilePath,
					serviceCount = c.Services!.Count,
				})
				
				.AsNoTracking().ToListAsync();
			return categories;
		}


		public async Task<CategoryDto> GetByIdForDisplayAsync(int id)
		{
			return await _db.Categories
				.Where(c => !c.IsDeleted)
				.Select(c => new CategoryDto
				{
                    Name = c.Name,
                    Id = c.Id,
                    ImageUrl = !c.ImageId.HasValue ? null : c.Image!.FilePath,
                    serviceCount = c.Services!.Count,
                })
				.FirstOrDefaultAsync(c => c.Id == id)
				?? throw new NotFoundException("Category not found");
        }

		public async Task<Category> GetByIdForTrackingAsync(int id)
		{
			return await _db.Categories.FirstOrDefaultAsync(c => c.Id == id)
				?? throw new NotFoundException("Category not found");
        }

		public async Task<Category> AddAsync(Category category)
		{
			_db.Categories.Add(category);
			await _db.SaveChangesAsync();
			return category;
		}

		public async Task<Category> UpdateAsync(Category category)
		{
			_db.Categories.Update(category);
			await _db.SaveChangesAsync();
			return category;
		}

		public async Task DeleteAsync(int id)
		{
			var category = await _db.Categories.FindAsync(id);
			if (category == null)
                throw new NotFoundException("Category not found");

			category.IsDeleted = true;
			await _db.SaveChangesAsync();
		}

		public async Task<Category> SearchByName(string name)
		{
			var searchTerm = name.Trim().ToLower();
			var category = await _db.Categories
				.FirstOrDefaultAsync(c => c.Name.ToLower().Contains(searchTerm));

			if (category is null )
				throw new NotFoundException("Category not found");

			return category;
		}
	}


}
