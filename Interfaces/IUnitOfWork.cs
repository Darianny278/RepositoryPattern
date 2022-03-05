using System.Threading.Tasks;

namespace RepositoryPattern.Interfaces{
    public interface IUnitOfWork{

        IPersonRepository PersonRepository{get;}
        Task<int> CommitAsync();
        Task DisposeAsync();
    }
}