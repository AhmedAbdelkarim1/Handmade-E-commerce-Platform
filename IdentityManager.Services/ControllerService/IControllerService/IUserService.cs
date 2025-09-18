﻿using Models.DTOs.image;
using Models.DTOs.User;

namespace IdentityManager.Services.ControllerService.IControllerService
{
	public interface IUserService
	{
		Task<object> UploadUserImageAsync(string userId, ImageUploadRequestDto request);
		Task<UserProfileDto> GetById(string userId);
		Task<IEnumerable<UserMangementDto>> GetAllUsers(string? status = null);
		Task DeleteUser(string userId);
		Task ChangeSellerStatus(string userId, string status);
		Task<IEnumerable<UserMangementDto>> GetAllPendingSellers();
		Task<string> GetSellerStatus(string userId);
	}
}
