using System;
using System.Linq;
using System.Threading.Tasks;
using Dell.CustomerService.Domain.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dell.CustomerService.Domain.Repositories
{
	public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity
	{
		private readonly IUnitOfWork _unitOfWork;

		public GenericRepository(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public IQueryable<TEntity> GetAll()
		{
			return _unitOfWork.Context.Set<TEntity>().AsNoTracking();
		}

		public async Task<TEntity> GetById(Guid id)
		{
			return await _unitOfWork.Context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
		}

		public async Task Create(TEntity entity)
		{
			await _unitOfWork.Context.Set<TEntity>().AddAsync(entity);
			await _unitOfWork.SaveAsync();
		}

		public async Task Update(TEntity entity)
		{
			_unitOfWork.Context.Set<TEntity>().Update(entity);
			await _unitOfWork.SaveAsync();
		}

		public async Task Delete(Guid id)
		{
			var entity = await _unitOfWork.Context.Set<TEntity>().FindAsync(id);
			_unitOfWork.Context.Set<TEntity>().Remove(entity);
		}
	}
}