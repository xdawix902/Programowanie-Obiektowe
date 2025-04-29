namespace Zad1;

interface IZwierzecy{
    string WydajDzwiek();
}

class Zoo<T> where T : IZwierzecy{
    List<T> zwierzeta = new List<T>();
    public List<T> Zwierzeta{
        get {return zwierzeta;}
    }

    public void DodajZwierzeta<U>(U animal) where U : T{
        zwierzeta.Add(animal);
    }

    public T GetZwierzeAtIndex(int index){
        return zwierzeta[index];
    }

    public void KarmZwierzeta(IEnumerable<T> zwierzeta){
        foreach(T a in zwierzeta){
            System.Console.WriteLine($"Karmimy: {a.WydajDzwiek()}");
        }
    }
    
    public void UsunZwierzeta<U>(U animal) where U : T{
        zwierzeta.Remove(animal);
    }
}


class Pies : IZwierzecy{
    public string WydajDzwiek(){
        return "Hau hau";
    }
}

class Kot : IZwierzecy{
    public string WydajDzwiek(){
        return "Miau";
    }
}

class Ryba : IZwierzecy{
    public string WydajDzwiek(){
        return "bul bul";
    }
}

class Program
{
    static void Main(string[] args)
    {
        var zoo = new Zoo<IZwierzecy>();

        zoo.DodajZwierzeta(new Pies());

        zoo.DodajZwierzeta(new Kot());

        zoo.DodajZwierzeta(new Ryba());

        zoo.KarmZwierzeta(zoo.Zwierzeta); // Hau hau!, Miau miau!, Bul bul!
    }
}
