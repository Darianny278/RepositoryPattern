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
        public DbSet<Person> People {get;set;}
        public DbSet<PersonPhoneNumber> PersonPhoneNumbers {get;set;}

        protected override void OnModelCreating(ModelBuilder builder){

            builder.Entity<Person>(x=>{
                x.Property(y=>y.Id)
                    .HasColumnName("Id")
                    .UseMySqlIdentityColumn();

                x.Property(y=>y.Age)
                    .HasColumnName("Age");

                x.Property(y=>y.FirstName)
                    .HasColumnName("FirstName")
                    .HasMaxLength(50);
                    
                x.Property(y=>y.LastName)
                    .HasColumnName("LastName")
                    .HasMaxLength(50);
            });

            builder.Entity<PersonPhoneNumber>(x=>{
                x.Property(y=>y.Id)
                    .HasColumnName("Id")
                    .UseMySqlIdentityColumn();

                x.HasOne(y=>y.Person)
                    .WithMany(y=>y.PersonPhoneNumbers)
                    .HasConstraintName("FK_PersonPhone");
                
                x.Property(y=>y.PhoneNumber)
                    .HasColumnName("Phone Number")
                    .HasMaxLength(10);
            });
        }
    }    
}