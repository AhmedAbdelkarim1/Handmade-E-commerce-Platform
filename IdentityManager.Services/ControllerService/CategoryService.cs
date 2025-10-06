using AutoMapper;
using DataAcess.Repos.IRepos;
using IdentityManager.Services.ControllerService.IControllerService;
using Models.Domain;
using Models.DTOs.Categories;
using System.Threading.Tasks;

namespace IdentityManager.Services.ControllerService
{
	public class CategoryService : ICategoryService
	{
		private readonly ICategoryRepository _repo;
		private readonly IMapper _mapper;
		private readonly IImageRepository _imageService = null;

		public CategoryService(ICategoryRepository repo, IMapper mapper, IImageRepository imageService)
		{
			_repo = repo;
			_mapper = mapper;
			_imageService = imageService ?? throw new InvalidOperationException("Image service not available at runtime.");
		}

		private CategoryDto ToDto(Category c) => new CategoryDto
		{
			Id = c.Id,
			Name = c.Name,
			ImageUrl = c.ImageId.HasValue ? _imageService.GetImageUrl(c.ImageId.Value) : null,
		};

		public async Task<IEnumerable<CategoryDto>> GetAllAsync()
		{
			var list = await _repo.GetAllAsync();
			return list;
		}

		public async Task<CategoryDto> GetByIdAsync(int id)
		{
			var cat = await _repo.GetByIdForDisplayAsync(id);
			return cat;
		}

		public async Task<CategoryDto> CreateAsync(string? userId, CreateCategoryDto dto)
		{
			int? imageId = null;


			if (dto.File != null)
			{
				var img = new Image
				{
					FileName = DateTime.Now.ToString("yyyyMMddHHmmssfff"),
					FileExtension = Path.GetExtension(dto.File.FileName),
					FileSize = dto.File.Length,
					File = dto.File
				};

				var savedImage = await _imageService.Upload(img);
				imageId = savedImage.Id;
			}

			var entity = new Category
			{
				Name = dto.Name,
				ImageId = imageId,
				CreatedById = userId
			};

			var saved = await _repo.AddAsync(entity);
			return ToDto(saved);
		}

		public async Task<CategoryDto> UpdateAsync(string? userId, int id, UpdateCategoryDto dto)
		{
			var existing = await _repo.GetByIdForTrackingAsync(id);

			existing.Name = dto.Name;
			existing.LastUpdatedOn = DateTime.Now;
			existing.LastUpdatedById = userId;


			if (dto.File != null)
			{
				var img = new Image
				{
					FileName = Path.GetFileNameWithoutExtension(dto.File.FileName),
					FileExtension = Path.GetExtension(dto.File.FileName),
					FileSize = dto.File.Length,
					File = dto.File
				};

				var savedImage = await _imageService.Upload(img);
				existing.ImageId = savedImage.Id;
			}

			var updated = await _repo.UpdateAsync(existing);
			return ToDto(updated);
		}


		public async Task DeleteAsync(int id) => await _repo.DeleteAsync(id);

		public async Task<CategoryDto> SearchByName(string name)
		{
			var category = await _repo.SearchByName(name);
			return ToDto(category);
		}
	}
}
