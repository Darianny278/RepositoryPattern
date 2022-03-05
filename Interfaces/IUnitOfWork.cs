using System.Threading.Tasks;

namespace RepositoryPattern.Interfaces{
    public interface IUnitOfWork{
        Task<int> CommitAsync();
        Task DisposeAsync();
    }
}