internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Atrybut z parametrem nazwanym");

        // uzywając klasy Type wykorzystujemy refleksję
        Type tUseAttrib = typeof(UseAttrib); // pusta klasa, ale ma atrybut RemarkAttribute
        Console.Write("atrybuty " + tUseAttrib.Name + ": ");

        // wersja metody GetCustomAttributes()
        object[] attribs = tUseAttrib.GetCustomAttributes(false);
        foreach (object o in attribs) 
            Console.WriteLine(o);

        Type tRemAtt = typeof(RemarkAttribute); // ten atrybut nas interesje
        // inna wersja metody GetCustomAttributes(typ klasy z atrybutem, typ samego atrybutu)
        RemarkAttribute ra = (RemarkAttribute)Attribute.GetCustomAttribute(tUseAttrib, tRemAtt);

        Console.WriteLine("Remark: " + ra.remark);
        Console.WriteLine("Supplement: " + ra.supplement);
    }

    // pierwszy parametr jest identyfikowany przez pozycję na liści,
    // drugi przez nazwę
    [RemarkAttribute("nasz atrybut", supplement = "dodatek")]
    class UseAttrib { }
    // pusta klasa UseAttrib opisana przez atrybut RemarkAttribute
    
    class RemarkAttribute : Attribute
    {
        private string _remark;
        public string supplement; // nazwany parameter 
        public RemarkAttribute(string comment)
        {
            _remark = comment;
            supplement = "None";
        }
        public string remark
        {
            get { return _remark; }
        }
    }
}