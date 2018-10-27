using System;
using System.Linq;
using System.Threading.Tasks;
using Dell.CustomerService.Domain.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dell.CustomerService.Domain.Repositories
{
	public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity
	{
		private readonly CustomersDbContext _dbContext;

		public GenericRepository(CustomersDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IQueryable<TEntity> GetAll()
		{
			return _dbContext.Set<TEntity>().AsNoTracking();
		}

		public async Task<TEntity> GetById(Guid id)
		{
			return await _dbContext.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
		}

		public async Task Create(TEntity entity)
		{
			await _dbContext.Set<TEntity>().AddAsync(entity);
		}

		public async Task Update(Guid id, TEntity entity)
		{
			_dbContext.Set<TEntity>().Update(entity);
		}

		public async Task Delete(Guid id)
		{
			var entity = await _dbContext.Set<TEntity>().FindAsync(id);
			_dbContext.Set<TEntity>().Remove(entity);
		}
	}
}