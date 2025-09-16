using Microsoft.AspNetCore.Http;

namespace IdentityManager.Services.ControllerService.IControllerService
{
	public interface IMailingService
	{
		Task SendEmailAsync(string mailTo, string subject, string body, IList<IFormFile> attachments = null);
	}
}
