using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Z1
{
    public class ProduktAGD
    {
        [JsonProperty("Nazwa")]
        public string Nazwa { get; set; }

        [JsonProperty("Marka")]
        public string Marka { get; set; }

        [JsonProperty("Model")]
        public string Model { get; set; }

        [JsonProperty("Cena")]
        public decimal Cena { get; set; }

        [JsonProperty("DataProdukcji")]
        [JsonConverter(typeof(CustomDateFormatConverter), "dd-MM-yyyy")]
        public DateTime DataProdukcji { get; set; }

        [JsonProperty("KrajProdukcji")]
        public string KrajProdukcji { get; set; }

        [JsonProperty("Opis")]
        public string Opis { get; set; }

        public ProduktAGD(string nazwa, string marka, string model, decimal cena, DateTime dataProdukcji, string krajProdukcji, string opis)
        {
            Nazwa = nazwa;
            Marka = marka;
            Model = model;
            Cena = cena;
            DataProdukcji = dataProdukcji;
            KrajProdukcji = krajProdukcji;
            Opis = opis;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not ProduktAGD other) return false;
            return Nazwa == other.Nazwa && Marka == other.Marka && Model == other.Model && DataProdukcji == other.DataProdukcji && KrajProdukcji == other.KrajProdukcji;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Nazwa, Marka, Model, DataProdukcji, KrajProdukcji);
        }

        public override string ToString()
        {
            return $"{Nazwa} {Marka} {Model} {Cena}";
        }
    }

    public class SklepAGD
    {
        [JsonProperty("Produkty")]
        public List<ProduktAGD> Produkty  = new List<ProduktAGD>();

        public void DodajProdukt(ProduktAGD produkt)
        {
            Produkty.Add(produkt);
        }

        public override bool Equals(object? obj)
        {
            if (obj is not SklepAGD other) return false;
            if (Produkty.Count != other.Produkty.Count) return false;

            for(int i = 0; i < Produkty.Count; i++)
            {
                if (!Produkty[i].Equals(other.Produkty[i])) return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hash = 17;

            foreach(ProduktAGD produkt in Produkty)
            {
                hash = hash * 31 + produkt.GetHashCode();
            }
            return hash;
        }

        public void Serializuj(string nazwa)
        {
            try
            {
                string json = JsonConvert.SerializeObject(this, Formatting.Indented);
                File.WriteAllText(nazwa, json);
                Console.WriteLine($"Zapisano do pliku {nazwa}.json");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Brak dostępu do pliku");
            }
            catch (IOException)
            {
                Console.WriteLine("Błąd wejścia/wyjścia");
            } catch (JsonException)
            {
                Console.WriteLine("Błąd serializacji Json");
            }
        }

        public static SklepAGD Deserializuj(string nazwa)
        {
            try
            {
                string json = File.ReadAllText(nazwa);
                SklepAGD? sklep = JsonConvert.DeserializeObject<SklepAGD>(json);
                if(sklep == null)
                {
                    Console.WriteLine("Deserializacja zakończona niepowodzeniem – plik nie zawiera prawidłowych danych.");
                    return new SklepAGD();
                }
                Console.WriteLine($"Wczytano dane z pliku {nazwa}.json");
                return sklep;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Nie znaleziono pliku");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Brak dostępu do pliku");
            }
            catch (IOException)
            {
                Console.WriteLine("Błąd wejścia/wyjścia");
            }
            catch (JsonException)
            {
                Console.WriteLine("Błąd serializacji Json");
            }
            return new SklepAGD();
        }

        public override string ToString()
        {
            StringBuilder ans = new StringBuilder();

            foreach(var prod in Produkty)
            {
                ans.AppendLine(prod.ToString());
            }
            return ans.ToString();
        }
    }

    public class CustomDateFormatConverter : IsoDateTimeConverter
    {
        public CustomDateFormatConverter(string format)
        {
            base.DateTimeFormat = format;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            ProduktAGD produkt1 = new ProduktAGD(
                "Czajnik",
                "Philips",
                "HD9350/90",
                49.99m,
                new DateTime(2022, 1, 1),
                "Chiny",
                "Czajnik ze stali nierdzewnej z wymiennym filtrem"
            );

                        ProduktAGD produkt2 = new ProduktAGD(
                            "Odkurzacz",
                            "Dyson",
                            "V11 Absolute",
                            599.99m,
                            new DateTime(2021, 6, 1),
                            "Malezja",
                            "Bezprzewodowy odkurzacz z cyfrowym silnikiem"
                        );

                        SklepAGD sklep = new SklepAGD();
                        sklep.DodajProdukt(produkt1);
                        sklep.DodajProdukt(produkt2);

                        sklep.Serializuj("produkty.json");
                        SklepAGD sklep2 = SklepAGD.Deserializuj("produkty.json");

                        Console.WriteLine(sklep);
                        Console.WriteLine(sklep2);

                        Console.WriteLine(sklep.Equals(sklep2));
                        Console.WriteLine(sklep == sklep2);
        }
    }
}
