using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Common.Types
{
	public interface IRepository<TEntity>: IRepository<TEntity, string> where TEntity : IBaseKeyEntity<string>
    {
    }

	public interface IRepository<TEntity, TKey> where TEntity : IBaseKeyEntity<TKey>
	{
		Task<IQueryable<TEntity>> GetQuery();

		Task<TEntity> GetAsync(TKey id);

		Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> whereCondition);

		Task<IEnumerable<TEntity>> FindAsync(
			Expression<Func<TEntity, bool>> whereCondition);

		Task<IEnumerable<TDto>> FindAsync<TDto>(
			Expression<Func<TEntity, bool>> whereCondition,
			Expression<Func<TEntity, TDto>> mapper);

		Task<PagedResult<TEntity>> FindAsync<TQuery>(
			Expression<Func<TEntity, bool>> whereCondition, 
			TQuery query) 
			where TQuery : IQuery;

		Task<PagedResult<TDto>> FindAsync<TQuery, TDto>(
			Expression<Func<TEntity, bool>> whereCondition,
			TQuery query,
			Expression<Func<TEntity, TDto>> mapper) 
			where TQuery : IQuery;

		Task<PagedResult<TDto>> FindAsync<TQuery, TDto>(
			IEnumerable<Expression<Func<TEntity, bool>>> whereConditions,
			TQuery query,
			Expression<Func<TEntity, TDto>> mapper)
			where TQuery : IQuery;

		Task AddAsync(TEntity entity);

		Task AddManyAsync(List<TEntity> entity);

		Task UpdateAsync(TEntity entity);

		Task UpdateAsync<TField>(
			Expression<Func<TEntity, bool>> whereCondition, 
			Expression<Func<TEntity, TField>> field,
			TField value);

		Task UpdateAsync<TField>(TKey id, 
			Expression<Func<TEntity, TField>> field, TField value);

		Task UpdateAsync<TField>(TEntity entity, 
			Expression<Func<TEntity, TField>> field, TField value);

		Task DeleteAsync(TKey id);

		Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> whereCondition);

		Task<long> CountAsync(Expression<Func<TEntity, bool>> whereCondition);
	}
}