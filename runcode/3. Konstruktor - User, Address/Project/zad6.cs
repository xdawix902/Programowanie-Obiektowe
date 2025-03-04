namespace zad6{

    public class Address{
        private string addressLine;
        private string city;
        private string zipCode;

        public Address(string addressLine, string city, string zipCode){
            this.addressLine = addressLine;
            this.city = city;
            this.zipCode = zipCode;
        }

        public Address(Address other){
            this.addressLine = other.addressLine;
            this.city = other.city;
            this.zipCode = other.zipCode;
        }
    }

    public class User{
        private string firstName;
        private string lastName;
        private Address homeAddress;

        public User(string firstName, string lastName, Address homeAddress){
            this.firstName = firstName;
            this.lastName = lastName;
            this.homeAddress = new Address(homeAddress);
        }

        public User(User other){
            this.firstName = other.firstName;
            this.lastName = other.lastName;
            this.homeAddress = new Address(other.homeAddress);
        }
    }

}