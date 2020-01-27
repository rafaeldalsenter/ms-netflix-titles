using Cassandra;
using Cassandra.Mapping;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MsNetflixTitles.CrossCutting
{
    public class CassandraContext : ICassandraContext
    {
        private readonly Cluster _cluster;
        private readonly ISession _session;
        private readonly IMapper _mapper;

        public CassandraContext(IConfiguration configuration)
        {
            _cluster = Cluster.Builder()
                .AddContactPoint(configuration.GetSection("HostCassandra").Value)
                .Build();

            _session = _cluster.Connect(configuration.GetSection("KeyspaceCassandra").Value);

            _mapper = new Mapper(_session);
        }

        public async Task<T> FirstOrDefaultAsync<T>(string cqlQuery, params object[] args) => await _mapper.FirstOrDefaultAsync<T>(cqlQuery, args);

        public async Task<IEnumerable<T>> SelectAsync<T>(string cqlQuery, params object[] args) => await _mapper.FetchAsync<T>(cqlQuery, args);

        public async Task InsertAsync<T>(T obj) => await _mapper.InsertAsync<T>(obj);

        public async Task UpdateAsync<T>(T obj) => await _mapper.UpdateAsync<T>(obj);

        public async Task DeleteAsync<T>(T obj) => await _mapper.DeleteAsync<T>(obj);
    }
}