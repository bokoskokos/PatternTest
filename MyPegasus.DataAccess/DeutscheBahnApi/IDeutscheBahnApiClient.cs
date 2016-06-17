using System.Threading.Tasks;

namespace MyPegasus.DataAccess.DeutscheBahnApi
{
    public interface IDeutscheBahnApiClient
    {
        Task<T> GetAsync<T>(string uri);
    }
}
