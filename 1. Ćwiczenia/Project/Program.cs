namespace Project;

class Student{
    public string nazwisko;
    public string imie;
    private int nr_albumu;
    private int semestr;
    private int rok_urodzenia;
    private double ocena_z_programowania;

    public Student(string nazwisko, string imie, int nr_albumu, int semestr, int rok_urodzenia, double ocena_z_programowania){
        this.nazwisko = nazwisko;
        this.imie = imie;
        this.nr_albumu = nr_albumu;
        this.semestr = semestr;
        this.rok_urodzenia = rok_urodzenia;
        this.ocena_z_programowania = ocena_z_programowania;
    }

    public Student(string imie, string nazwisko)
    :this(nazwisko,imie, 1000,1,2000,2.0)
    {}

    public string WyswietlInformacje(){
        return $"{this.imie} {this.nazwisko} {this.nr_albumu} {this.semestr} {this.rok_urodzenia} {this.ocena_z_programowania}";
    }
    public int ZwrocWiek(){
        return 2025-this.rok_urodzenia;
    }
    private string zwrocStatystykiStudiowania(){
        return $"{this.nr_albumu} {this.semestr}";
    }
    public string StudentIJegoStatystyki(){
        return $"{this.zwrocStatystykiStudiowania()} {this.rok_urodzenia}";
    }
    public double ZwrocOcene(){
        return this.ocena_z_programowania;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Student student1 = new Student("Dawid","Nazwisko",2137,2,2005,2);
        Student student2 = new Student("Jan","Kowalski",2009,3,2003,3.5);
        Student student3 = new Student("Magnus","Carlsen");
        Student student4 = new Student("Joe","Rogan");

        System.Console.WriteLine($"{student1.imie} {student1.nazwisko}");
        System.Console.WriteLine($"{student2.imie} {student2.nazwisko}");
        System.Console.WriteLine($"{student3.imie} {student3.nazwisko}");
        System.Console.WriteLine($"{student4.imie} {student4.nazwisko}");

        System.Console.WriteLine(student1.WyswietlInformacje());
        System.Console.WriteLine(student2.WyswietlInformacje());
        System.Console.WriteLine(student3.WyswietlInformacje());
        System.Console.WriteLine(student4.WyswietlInformacje());

        Console.WriteLine(student1.ZwrocWiek());
        Console.WriteLine(student2.ZwrocWiek());
        Console.WriteLine(student3.ZwrocWiek());
        Console.WriteLine(student4.ZwrocWiek());

        Console.WriteLine();

        Console.WriteLine(student1.StudentIJegoStatystyki());
        Console.WriteLine(student2.StudentIJegoStatystyki());
        Console.WriteLine(student3.StudentIJegoStatystyki());
        Console.WriteLine(student4.StudentIJegoStatystyki());

        Student[] studenci = {student1, student2, student3,student4};
        double suma = 0;
        foreach(Student student in studenci){
            suma += student.ZwrocOcene();
        }
        System.Console.WriteLine($"Średnia: {suma/4.0}");
        
        
    }
}
