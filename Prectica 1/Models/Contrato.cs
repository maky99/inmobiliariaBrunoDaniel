namespace Prectica_1.Models
{
    public class Contrato
    {
        public int id_contrato { get; set; }
        public DateTime desde { get; set; }
        public DateTime hasta { get; set; }
        public string? detalle { get; set; }
        public DateTime finalizacion_anticipada { get; set; }
        public double monto { get; set; }
        public double multa { get; set; }
        public int id_inquilino { get; set; }
    }
}
