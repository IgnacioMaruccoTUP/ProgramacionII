namespace FechaAPI.Models
{
    public class Fecha
    {
        public int Numero { get; set; }
        public string Dia { get; set; }
        public int Mes { get; set; }
        public int Anio { get; set; }

        public Fecha()
        {
            DateTime fechaActual = DateTime.Today;

            Numero = fechaActual.Day;
            Dia = fechaActual.DayOfWeek.ToString();
            Mes = fechaActual.Month;
            Anio = fechaActual.Year;
        }
    }
}
