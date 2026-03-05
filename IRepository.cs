using NodeManagementAPI.Core.Dtos;
using NodeManagementAPI.Core.Entities.OrgManagementEntities;
using System.Linq.Expressions;


namespace NodeManagementAPI.Core.IRepositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T?>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<ResultDto> AddAsync(T entity);
        Task<ResultDto> UpdateAsync(T entity);
        Task<ResultDto> RemoveAsync(T entity);
        Task<ResultDto> RemoveAsync(int id);
        Task<IEnumerable<T?>> GetByConditionAsync(Expression<Func<T, bool>> condition);

        // Custom method added by Alexandra
        Task<IEnumerable<Node>> GetChildrenAsync(int parentId);
    }
}
