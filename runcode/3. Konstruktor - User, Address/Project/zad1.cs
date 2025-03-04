namespace zad1{
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
        return($"{this.addressLine} {this.zipCode} {this.city}");
    }

    
    }
}