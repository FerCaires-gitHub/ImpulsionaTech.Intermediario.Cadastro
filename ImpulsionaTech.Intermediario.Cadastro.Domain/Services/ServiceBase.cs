using AutoMapper;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Base;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Interfaces;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ImpulsionaTech.Intermediario.Cadastro.Domain.Services
{
    public class ServiceBase<TSource, TDestination, T> : IServiceBase<TSource, TDestination, T> where TSource : class where TDestination : class where T : BaseEntity
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<T> _unitOfWork;
        private readonly IAsyncRepository<T> _repository;

        public ServiceBase(IMapper mapper, IUnitOfWork<T> unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetAsyncRepository();
        }
        public async Task DeletetAsync(int id)
        {
            if (id <= 0)
                throw new CustomException(400, "Id inválido");
            var entity = await _repository.GetById(id);
            if (entity == null)
                throw new CustomException(404, "");
            await _repository.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<TDestination> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new CustomException(400, "Id inválido");
            var entity = await _repository.GetById(id);
            if (entity == null)
                throw new CustomException(404, "");
            return _mapper.Map<TDestination>(entity);
        }

        public async Task<TDestination> InsertAsync(TSource entity)
        {
            if (entity == null)
                throw new CustomException(400, $"{typeof(T).Name} nula ou não informaada");
            var response = await _repository.AddAsync(_mapper.Map<T>(entity));
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<TDestination>(response);
        }

        public async Task<IEnumerable<TDestination>> ListAsync(Expression<Func<TSource, bool>> expression)
        {
            var mapperExpression = _mapper.Map <Expression<Func<T, bool>>>(expression);
            var response = await _repository.ListAsync(mapperExpression);
            if (response == null || !response.Any())
                throw new CustomException(404, "");
            return response.Select(x => _mapper.Map<TDestination>(x));
        }

        public virtual async Task<TDestination> UpdateAsync(T entity)
        {
            if (entity == null)
                throw new CustomException(400, $"{typeof(T).Name} nula ou não informaada");
            var response  = await _repository.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<TDestination>(response);

        }
    }
}
