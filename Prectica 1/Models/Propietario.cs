using System.ComponentModel.DataAnnotations;

namespace Prectica_1.Models;

public class Propietario
{
    public int id_propietario { get; set; }
    [Required(ErrorMessage = "El Dni es obligatorio.")]
    [Range(0, 99999999)]
    public int? dni { get; set; }
    [Required(ErrorMessage = "El Apellido es obligatorio.")]
    public string apellido { get; set; }
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    public string nombre { get; set; }
    [Required(ErrorMessage = "El teléfono es obligatorio.")]
    public string telefono { get; set; }
    [Required(ErrorMessage = "El email es obligatorio.")]
    public string email { get; set; }
    public int estado { get; set; }

}