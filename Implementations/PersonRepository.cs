using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Contexts;
using RepositoryPattern.Entities;
using RepositoryPattern.Interfaces;

namespace RepositoryPattern.Implementations{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        private readonly Context _context;
        private readonly DbSet<Person> _people;
        public PersonRepository(Context context): base(context)
        {
            _context = context;
            _people = _context.People;
        }

        public async Task<Person> GetByName(string name)
        {
            return await _people
                .Where(person=>person.FirstName.Equals(name))
                .FirstOrDefaultAsync();
        }
    }
}