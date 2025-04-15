using System.Collections;

namespace Project;

public class Person : IComparable{
    public string Name {get;}
    public int Age {get;}
    public Person(string name, int age){
        Name = name;
        Age = age;
    }

    public int CompareTo(object obj){
        if(obj == null) return 1;
        if(!(obj is Person other))
            throw new ArgumentException("faafadsdf");
        return Age.CompareTo(other.Age);
    }
    public override string ToString()
    {
        return $"{Name} {Age}";
    }

    public class MyComperer : IComparer{
        public int Compare(object x, object y){
            if(x == null || y == null) return 1;
            if(!(x is Person pX) || !(y is Person pY))
                throw new ArgumentException("sdfsdf");
            return pX.Name.CompareTo(pY.Name);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        ArrayList people = new ArrayList{
            new Person("Jan Kowalski", 70),
            new Person("Anna Nowak", 25),
            new Person("Piotr Wiśniewski", 35)
        };

        foreach(var person in people){
            System.Console.WriteLine(person.ToString());
        }
        System.Console.WriteLine();

        people.Sort();
        foreach(var person in people){
            System.Console.WriteLine(person.ToString());
        }
        people.Sort(new Person.MyComperer());
        System.Console.WriteLine();
        
        foreach(var person in people){
            System.Console.WriteLine(person.ToString());
        }
    }
}
