using Tuneloop.Data.Models;

namespace Tuneloop.Data.Infrastructure;

public interface IDatabaseService
{
    Task<List<T>> GetItemsWithQuery<T>(string query) where T : BaseEntity, new();
    Task<bool> ExecuteQuery(string query);
    Task<int> CountItemsWithQuery(string query);
    Task<List<T>> ListAll<T>() where T : BaseEntity, new();
    Task<int> CreateOrReplace<T>(T entity) where T : BaseEntity, new();
    Task<int> CreateList<T>(IEnumerable<T> entities) where T : BaseEntity, new();
    Task<int> Delete<T>(T entity) where T : BaseEntity, new();
    Task<int> DeleteAll<T>() where T : BaseEntity, new();
}
