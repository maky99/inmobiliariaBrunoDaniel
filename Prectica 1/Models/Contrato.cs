
namespace Prectica_1.Models;

    public class Contrato
    {
        public int? id_contrato { get; set; }
        public DateTime desde { get; set; }
        public int meses { get; set; }
        public DateTime hasta { get; set; }
        public string detalle { get; set; }
        public DateTime finalizacionAnticipada { get; set; }
        public double? monto { get; set; }
        public double multa { get; set; }
        public int estado { get; set; }
        public int id_inquilino { get; set; }
        public int id_inmueble { get; set; }
        public Propietario dueno { get; set; }
        public Inmueble inmueble { get; set; }
        public Inquilino inquilino { get; set; }
        public Pago pago { get; set; }

    }