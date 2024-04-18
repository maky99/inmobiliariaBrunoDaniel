
namespace Prectica_1.Models;

    public class Informes
    {
        public Propietario dueno { get; set; }
        public Inmueble inmueble { get; set; }
        public Inquilino inquilino { get; set; }
        public Pago pago { get; set; }
        public Contrato contrato {get;set;}

    }