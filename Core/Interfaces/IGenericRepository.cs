using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifcation;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetBYIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAync();
        Task<T> GetEntityWithSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> ListAsync (ISpecification<T> spec);
        Task<int> CountAsync(ISpecification<T> spec);

    }
}