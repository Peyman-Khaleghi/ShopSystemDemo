using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ShopSystem.Domain.Models;
using ShopSystem.Infrastructure;
using ShopSystem.Services;
using ShopSystem.Services.Exceptions;

public class ApplicationGenericServices<TEntity, TId, TItem, TOutput, TInput, TUpdate> :
    IApplicationGenericServices<TEntity, TId, TItem, TOutput, TInput, TUpdate>
    where TEntity : class, IBaseEntity<TId>
{
    private readonly IRepository<TEntity, TId> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ApplicationGenericServices(
        IRepository<TEntity, TId> repository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<TOutput> GetByIdAsync(TId id)
    {
        TEntity entity = await _repository.GetByIdAsync(id);

        if (entity == null)
            throw new NotFoundException<TId>(id);

        return _mapper.Map<TOutput>(entity);
    }

    public async Task<IEnumerable<TItem>> GetAllAsync()
    {
        var query = _repository.Query();
        return await query.ProjectTo<TItem>(_mapper.ConfigurationProvider).ToListAsync();
    }

    public async Task<TId> AddAsync(TInput input)
    {
        var newEntity = _mapper.Map<TEntity>(input);

        await _repository.AddAsync(newEntity);
        await _unitOfWork.CompleteAsync();

        return newEntity.Id;
    }

    public async Task UpdateAsync(TId id, TUpdate update)
    {
        var entityToUpdate = await _repository.GetByIdAsync(id);

        if (entityToUpdate == null)
        {
            throw new NotFoundException<TId>(id);
        }

        _mapper.Map(update, entityToUpdate);

        _repository.Update(entityToUpdate);
        await _unitOfWork.CompleteAsync();
    }

    public async Task DeleteAsync(TId id)
    {
        await _repository.Delete(id);
        await _unitOfWork.CompleteAsync();
    }
}