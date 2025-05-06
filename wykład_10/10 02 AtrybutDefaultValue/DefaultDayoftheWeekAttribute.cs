using System.ComponentModel;

namespace AtrybutDefaultValue
{
    public class DefaultDayofWeekAttribute : DefaultValueAttribute
    // dziedziczy po klasie służącej do podawania domyślnych wartości
    {
        // Ten atrybut realizuje podstawienie pod Value nazwy dnia tygodnia
        // z daty podanej w argumencie tego atrybutu 
        private DateTime date;
        private string day;

        public DefaultDayofWeekAttribute(int year, int month, int day) : base(year)
        {
            date = new DateTime(year, month, day);
            this.day = date.DayOfWeek.ToString();
        }

        public override object Value
        {
            get { return day; }
        }
    }
}
