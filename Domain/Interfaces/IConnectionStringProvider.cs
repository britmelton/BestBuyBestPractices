using System.Data;

namespace Domain.Interfaces
{
    public interface IConnectionStringProvider
    {
        IDbConnection GetConnectionString();
    }
}
