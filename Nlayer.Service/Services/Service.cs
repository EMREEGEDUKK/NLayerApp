using Microsoft.EntityFrameworkCore;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Repository.Repositories;
using NLayer.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nlayer.Service.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public Service( IGenericRepository<T> genericRepository, IUnitOfWork unitOfWork)
        {
            _repository = genericRepository;
            _unitOfWork = unitOfWork;
            
        }
        public async Task<T> AddAsync(T entity)
        {
           await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
          return await _repository.AnyAsync(expression);

        }

        public async void DeleteAsync(T entitiy)
        {
             _repository.Delete(entitiy);
            await _unitOfWork.CommitAsync();

        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await  _repository.GetAll().ToListAsync();
           
        }

        public async Task<T> GetByIdAsync(int id)
        {
           return await _repository.GetByIdAsync(id);
           
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _repository.RemoveRange(entities);
            _unitOfWork.Commit();
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
            _unitOfWork.Commit();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
           return  _repository.Where(expression);
        }
    }
}
