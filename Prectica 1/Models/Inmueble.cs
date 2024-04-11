namespace Prectica_1.Models;

public class Inmueble
{
    public int id_inmueble { get; set; }
    public string tipoDebien { get; set; }
    public string tipoDeUso { get; set; }
    public string direccion { get; set; }
    public string condicion { get; set; }
    public double costo { get; set; }
    public string detalle { get; set; }
    public int estado { get; set; }
    public int id_propietario { get; set; }
    public Propietario dueno { get; set; }


}