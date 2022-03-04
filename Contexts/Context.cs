using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Entities;

namespace RepositoryPattern.Contexts{
    public class Context : DbContext  {
        public Context()
        {
            
        }
        public Context(DbContextOptions<Context> options): base(options)
        {
            
        }
        public DbSet<Person> Persons {get;set;}
    }    
}