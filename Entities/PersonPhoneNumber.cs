namespace RepositoryPattern.Entities{
    public class PersonPhoneNumber{
        public int Id{get;set;}
        public int PersonId{get;set;}
        public string PhoneNumber {get;set;}

        public virtual Person Person {get;set;}
    }
}