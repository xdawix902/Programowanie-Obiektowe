namespace Project;
using Drugie;
class Program
{
    static void Main(string[] args)
    {
        User user1 = new User();
        user1.ResetId();
        Console.WriteLine(user1.GetId());
    }
}
