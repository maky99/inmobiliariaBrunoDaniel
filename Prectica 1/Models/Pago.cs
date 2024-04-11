namespace Prectica_1.Models
{
    public class Pago
    {
        public int id_pago { get; set; }
        public string? concepto { get; set; }
        public double importe { get; set; }
        public DateTime fecha { get; set; }
        public int estado { get; set; }
        public int id_contrato { get; set; }
        
    }
}
