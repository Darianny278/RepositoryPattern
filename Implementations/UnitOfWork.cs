using System.Threading.Tasks;
using RepositoryPattern.Contexts;
using RepositoryPattern.Interfaces;

namespace RepositoryPattern.Implementations{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        public IPersonRepository PersonRepository {get;}
        public UnitOfWork(Context context, IPersonRepository personRepository)
        {
            _context = context;
            PersonRepository = personRepository;
        }


        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}