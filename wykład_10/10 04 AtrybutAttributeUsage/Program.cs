internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Atrybut AttributeUsage");

        Type t = typeof(UseAttrib);
        Console.WriteLine("Attributes in " + t.Name + ": ");
        object[] attribs = t.GetCustomAttributes(false);
        foreach (object o in attribs)
        {
            Console.WriteLine(o);
            RemarkAttribute ra = (RemarkAttribute)o;
            Console.WriteLine(ra.remark);
        }
    }
}

[RemarkAttribute("jeden atrybut")]
[RemarkAttribute("drugi atrybut")]
class UseAttrib { }


[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, 
    AllowMultiple = true)]
class RemarkAttribute : Attribute
{
    string _remark;
    public RemarkAttribute(string comment)
    { _remark = comment; }
    public string remark { get { return _remark; } }
}

