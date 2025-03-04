namespace zad3{

    public class User{
        private string firstName;
        private string lastName;

        public User(string firstName, string lastName){
            this.firstName = firstName;
            this.lastName = lastName;
        }
        
        public string GetUserDetails(){
            return ($"{this.firstName} {this.lastName}");
        }
    }
}