namespace zad5{
    public class Address{
        private string addressLine;
        private string city;
        private string zipCode;

        public Address(string addressLine, string city, string zipCode){
            this.addressLine = addressLine;
            this.city = city;
            this.zipCode = zipCode;
        }

        public string GetFullAddress(){
            return $"{this.addressLine} {this.zipCode} {this.city}";
        }
    }

    public class User{
        private string firstName;
        private string lastName;
        private Address homeAddress;

        public User(string firstName, string lastName, Address homeAddress){
            this.firstName = firstName;
            this.lastName = lastName;
            this.homeAddress = homeAddress;
        }
        
        public string GetUserDetails(){
            return $"{this.firstName} {this.lastName} {this.homeAddress.GetFullAddress()}";
        }
    }
}