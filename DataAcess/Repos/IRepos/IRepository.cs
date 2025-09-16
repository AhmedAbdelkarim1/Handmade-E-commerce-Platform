﻿using System.Linq.Expressions;

namespace DataAcess.Repos.IRepos
{
	public interface IRepository<T> where T : class
	{

		Task<T> GetAsync(Expression<Func<T, bool>> filter = null, string? includes = null);
		Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, string? includes = null, int pageSize = 0, int pageNumber = 1);
		Task AddAsync(T entity);
		Task DeleteAsync(T entity);


	}
}
