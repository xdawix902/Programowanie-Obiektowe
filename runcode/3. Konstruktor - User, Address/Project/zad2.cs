namespace zad2{
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
}