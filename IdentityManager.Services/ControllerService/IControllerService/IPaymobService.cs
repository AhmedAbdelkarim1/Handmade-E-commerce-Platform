using Models.Domain;

namespace IdentityManager.Services.ControllerService.IControllerService
{
	public interface IPaymobService
	{
		Task<(Payment payment, string RedirectUrl)> ProcessPaymentAsync(int orderId, string paymentMethod);
		Task<CustomerOrder> UpdateOrderSuccess(string specialReference);
		Task<CustomerOrder> UpdateOrderFailed(string specialReference);
		string ComputeHmacSHA512(string data, string secret);
	}
}
