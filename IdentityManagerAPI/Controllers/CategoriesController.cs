using System.Security.Claims;
using FluentValidation;
using IdentityManager.Services.ControllerService.IControllerService;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.Categories;

namespace IdentityManagerAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CategoriesController : ControllerBase
	{
		private readonly ICategoryService _service;
		private readonly IValidator<CategorySearchDto> _validator;
        public CategoriesController(ICategoryService service, IValidator<CategorySearchDto> validator)
        {
            _service = service;
            _validator = validator;
        }

        [HttpGet]
		public async Task<IActionResult> GetAll()
			=> Ok(await _service.GetAllAsync());

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var category = await _service.GetByIdAsync(id);
			return Ok(category);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromForm] CreateCategoryDto dto)
		{
			//var validationResult = await _validator.ValidateAsync(dto);
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var createdUser = await _service.CreateAsync(userId, dto);

            return CreatedAtAction(nameof(GetById),new { id = createdUser.Id },createdUser);
		}

		[HttpPut("{id}")]

		public async Task<IActionResult> Update(int id, [FromForm] UpdateCategoryDto dto)
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			return Ok(await _service.UpdateAsync(userId, id, dto));
		}


		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			await _service.DeleteAsync(id);
			return NoContent();
        }

		[HttpGet("search")]
		public async Task<IActionResult> SearchByName([FromQuery]CategorySearchDto request)
		{
			var validationResult = await _validator.ValidateAsync(request);
			if (!validationResult.IsValid)
				throw new ValidationException(validationResult.Errors);

			var searchResult = await _service.SearchByName(request.Name);
			return Ok(searchResult);
		}
	}
}
