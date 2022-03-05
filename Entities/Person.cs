using System.Collections.Generic;

namespace RepositoryPattern.Entities{
    public class Person{
        public int Id{get;set;}
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public int Age {get;set;}
        public virtual IEnumerable<PersonPhoneNumber> PersonPhoneNumbers{get;set;}
    }
}