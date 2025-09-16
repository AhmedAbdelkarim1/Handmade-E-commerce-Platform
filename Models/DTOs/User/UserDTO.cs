namespace Models.DTOs.User
{
	public class UserDTO
	{
		public string UserName { get; set; }
		public string FullName { get; set; }
		public string Email { get; set; }
		public List<string> ErrorMessages { get; set; } = new List<string>();
	}
}
