using System.ComponentModel.DataAnnotations;

namespace Z2
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DateOfBirthAttribute : ValidationAttribute
    {
        public int MinimimAge { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (IsValid(value))
            {
                return ValidationResult.Success;
            }

            var propertyName = validationContext.DisplayName ?? validationContext.MemberName;

            string errorMessage = ErrorMessage ?? $"{propertyName} wymaga minimalnego wieku {this.MinimimAge} lat.";

            return new ValidationResult(errorMessage);
        }

        public override bool IsValid(object value)
        {
            if(value is DateTime dateOfBirth)
            {
                DateTime today = DateTime.Today;
                int age = today.Year - dateOfBirth.Year;

                if(dateOfBirth > today.AddYears(-age))
                {
                    age--;
                }
                return age >= MinimimAge;


            }
            return false;
        }

    }


    public class Klient
    {
        [DateOfBirthAttribute(ErrorMessage = "Musisz mieć 18 lat")]
        public DateTime DataUrodzenia { get; set; }

        [Required(ErrorMessage = "Email jest wymagany")]
        [EmailAddress(ErrorMessage = "Nieprawidłowy format adresu email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Imie jest wymagane")]
        public string Imie { get; set; }

        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        public string Nazwisko { get; set; }

        public override string ToString()
        {
            return $"{Imie} {Nazwisko} {Email} {DataUrodzenia.ToShortDateString()}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var klienci = new List<Klient>()
{
    new Klient() { Nazwisko = "Nowak", Email = "jan_nowak@domena.pl", DataUrodzenia = new DateTime(2000, 1, 1)},
    new Klient() { Imie = "Anna", Email = "anna_kowalska@domena.pl", DataUrodzenia = new DateTime(2003, 5, 7)},
    new Klient() { Imie = "Adam", Nazwisko = "Mickiewicz", Email = "adam_mickiewicz", DataUrodzenia = new DateTime(1999, 12, 31)},
    new Klient() { Imie = "Barbara", Nazwisko = "Nowacka", Email = "barbara_nowacka@domena.pl", DataUrodzenia = new DateTime(2020, 1, 12) },
    new Klient() {},
    new Klient() {DataUrodzenia = new DateTime(2050, 1, 1)},
    new Klient() { Imie = "Andrzej", Nazwisko = "Dudu", Email = "andrzej_dudu@domena.pl", DataUrodzenia = new DateTime(2004, 2, 29) }
};

            foreach (var klient in klienci)
            {
                Console.WriteLine("Sprawdzam klienta: ");
                Console.WriteLine(klient);
                var validationContext = new ValidationContext(klient);
                var validationResults = new List<ValidationResult>();
                bool isValid = Validator.TryValidateObject(klient, validationContext, validationResults, true);

                if (!isValid)
                {
                    foreach (ValidationResult validationResult in validationResults)
                    {
                        Console.WriteLine("\tBłąd: " + validationResult.ErrorMessage + "\n\n");
                    }
                }
                else
                {
                    Console.WriteLine("\tPoprawna walidacja!\n");
                }
            }
        }
    }
}

