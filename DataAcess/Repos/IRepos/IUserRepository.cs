using Models.Domain;
using Models.DTOs.Auth;
using Models.DTOs.User;

namespace DataAcess.Repos.IRepos
{
	public interface IUserRepository : IRepository<ApplicationUser>
	{
		Task<bool> IsUniqueUserName(string username);
		Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
		Task<UserDTO> RegisterAdmin(RegisterRequestDTO registerRequestDTO);
		Task<UserDTO> RegisterSeller(RegisterRequestDTO sellerRegisterDto);
		Task<UserDTO> RegisterCustomer(RegisterRequestDTO customerRegisterDto);
		Task<ApplicationUser> GetUserByID(string userID);
		Task<bool> UpdateAsync(ApplicationUser user);
		Task UpdateUser(ApplicationUser user);
        
    }
}
