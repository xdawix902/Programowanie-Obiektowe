namespace Z1;

public static class PrzetwarzaniePlikow{
    public static string Wczytaj(string path){
        if(!File.Exists(path)){
            File.WriteAllText(path, "");
        }
        string ans = File.ReadAllText(path);
        return ans;
    }

    public static void Zapisz(string s, string path){
        if(!File.Exists(path)){
            File.WriteAllText(path,s);
        }
        else{
            File.AppendAllText(path,s);
        }
        System.Console.WriteLine("Zapisano tekst");
    }

    public static void Duplikuj(string path){
        string tekst_z_path = Wczytaj(path);
        string nazwa_pliku = Path.GetFileName(path).Split(".")[0];
        string? sciezka = Path.GetDirectoryName(path) + @"\";

        for(int i = 0; i < int.MaxValue; i++){
            string path_1 = sciezka + nazwa_pliku+"_"+ i + Path.GetExtension(path);
            if(!File.Exists(path_1)){
                Zapisz(tekst_z_path,path_1);
                System.Console.WriteLine("ZDUPLIKOWANO");
                System.Console.WriteLine(path_1);
                break;
            }
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
       
        string sciezka =@"C:\Users\dawid\Desktop\ProgObiek\Programowanie-Obiektowe\11. Ćwiczenia\lalka";

        for(int i = 0; i < 5; i++){
            PrzetwarzaniePlikow.Duplikuj(sciezka + ".txt");
        }

        for (int i = 0; i < 5; i++){
            PrzetwarzaniePlikow.Duplikuj(sciezka + ".rtf");
        }
    }
}
