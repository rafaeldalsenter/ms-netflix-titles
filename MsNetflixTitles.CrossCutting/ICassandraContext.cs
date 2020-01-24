using System.Collections.Generic;
using System.Threading.Tasks;

namespace MsNetflixTitles.CrossCutting
{
    public interface ICassandraContext
    {
        Task DeleteAsync<T>(T obj);

        Task UpdateAsync<T>(T obj);

        Task InsertAsync<T>(T obj);

        Task<IEnumerable<T>> SelectAsync<T>(string cqlQuery, params object[] args);

        Task<T> FirstOrDefaultAsync<T>(string cqlQuery, params object[] args);
    }
}