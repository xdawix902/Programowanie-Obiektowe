namespace zad1{
    
    struct Osoba{
        public string Imie;
        public string Nazwisko;
    }

}



//public string Imie;   //wartość publiczna, dostępna dla wszystkich
//priavate string Imie; //wartość prywatna, dostępna wewnątrz
// string Imie;    // TO TEŻ JEST PRIVATE 
//Jeśli nie ma przypisanego moodyfikatora to jest to PRIVATE
//protected string Imie;   //wartość chroniona, dostępna wewnątrz i w dziedzicznych

//jeśli do drugiej zmiennej przypiszemy wartości z pierwszej:
//struct - przepisuje wartości
//class - pointuje do tego samego miejsca w pamięci