﻿		using Models.Domain;

namespace DataAcess.Repos.IRepos
{
	public interface IServiceRepository
	{

		IEnumerable<Service> GetAll();
		Service Getbyid(int id);
		Service ADD(Service service);
		Service UPDATE(Service service);
		bool Delete(int id);
		void SavaChange();
		IEnumerable<Service> GetAllBySellerId(string sellerId);
		IEnumerable<Service> GetAllByCategoryId(int categoryId);
		IEnumerable<Service> GetAllByCategoryName(string categoryName);
		Task<Service?> UpdateServiceStatusAsync(int id, string status);
		Task<Service?> UpdateServiceReason(int id, string status);

	}
}
