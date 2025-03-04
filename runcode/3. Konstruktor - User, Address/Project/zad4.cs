namespace zad4{

    public class User{
        private string firstName;
        private string lastName;

        public User(string firstName, string lastName){
            this.firstName = firstName;
            this.lastName = lastName;
        }
        
        public User(User other){
            this.firstName = other.firstName;
            this.lastName = other.lastName;
        }
    }
}