using System.ComponentModel.DataAnnotations;

namespace Prectica_1.Models;

public class Persona
{
    public int id { get; set; }
    public int? dni { get; set; }
    public string? apellido { get; set; }
    public string? nombre { get; set; }
    public int? telefono { get; set; }
    public int? estado { get; set; }


}