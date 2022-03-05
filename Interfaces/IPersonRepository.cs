using System.Threading.Tasks;
using RepositoryPattern.Entities;

namespace RepositoryPattern.Interfaces{
    public interface IPersonRepository : IRepository<Person>{
        Task<Person> GetByName(string name); 
    }
}