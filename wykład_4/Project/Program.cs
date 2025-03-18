namespace Project;

interface IJadalny{
    bool ZdatnydoSpozycia();
    void Jedz();
}

abstract class Produkt : IJadalny{
    protected string nazwa;
    protected int dataWaznosci = 0;
    public virtual void Jedz(){
        if(ZdatnydoSpozycia()){
            System.Console.WriteLine("Mniam");
        }
        else System.Console.WriteLine("przeterminowany");
    }

    public virtual bool ZdatnydoSpozycia(){
        return dataWaznosci > 0;
    }
}

class Nabial : Produkt{
    public Nabial(){
        nazwa = "mleko";
        dataWaznosci = 5;
    }
}

class Pieczywo : Produkt{
    public Pieczywo(){
        nazwa = "chleb";
        dataWaznosci = 2;
    }
}

public class Temperature : IComparable{
    protected double temperatureF;
    public int CompareTo(object? obj){
        if(obj == null) return 1;
        else{
            Temperature? otherTemperature = obj as Temperature;
            if(otherTemperature != null){
               return this.temperatureF.CompareTo(otherTemperature.temperatureF); 
            }
        }
    }
    public double Fahrenheit{
        get {return this.temperatureF;}
        set {this.temperatureF = value;}
    }

    public double Celsius{
        get {return (this.temperatureF - 32.0) * (5.0/9.0);}
        set {this.temperatureF = (value * 9.0/5.0) + 32.0;}
    }  
}


class Program
{
    static void Main(string[] args)
    {

        int z = 10;
        Temperature[] temperatures = new Temperature[10];
        for(int i = 0; i < temperatures.Length; i++){
            temperatures[i] = new Temperature();
            temperatures[i].Fahrenheit = z--;
        }

        for(int i = 0; i < temperatures.Length; i++){
            System.Console.WriteLine(temperatures[i].Fahrenheit);
        }
        System.Console.WriteLine("Po sortowaniu");
        Array.Sort(temperatures);

        for(int i = 0; i < temperatures.Length; i++){
            System.Console.WriteLine(temperatures[i].Fahrenheit);
        }

        /*slajd 27
        Pieczywo chleb = new Pieczywo();
        chleb.Jedz();
        */
        
    }
}
