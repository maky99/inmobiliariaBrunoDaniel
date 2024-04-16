using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Prectica_1.Models
{

    public enum enRoles
    {
        Administrador = 1,
        Empleado = 2
    }

    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Debe ser una dirección de correo electrónico válida.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "La clave es obligatoria")]
        [DataType(DataType.Password)]
        public string Clave { get; set; }

        public string Avatar { get; set; } = "";
        public IFormFile AvatarFile { get; set; }

        public int Rol { get; set; }

        [NotMapped]
        public string RolNombre => Rol > 0 ? ((enRoles)Rol).ToString() : "";

        public static IDictionary<int, string> ObtenerRoles()
        {
            SortedDictionary<int, string> roles = new SortedDictionary<int, string>();
            Type tipoEnumRol = typeof(enRoles);
            foreach (var valor in Enum.GetValues(tipoEnumRol))
            {
                roles.Add((int)valor, Enum.GetName(tipoEnumRol, valor));
            }
            return roles;
        }

        // public static string HashPassword(string password)
        // {
        //     // Generar una sal aleatoria
        //     byte[] salt = new byte[128 / 8];
        //     using (var rng = RandomNumberGenerator.Create())
        //     {
        //         rng.GetBytes(salt);
        //     }

        //     // Hashear la contraseña
        //     string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
        //         password: password,
        //         salt: salt,
        //         prf: KeyDerivationPrf.HMACSHA256,
        //         iterationCount: 10000,
        //         numBytesRequested: 256 / 8));

        //     // Devolver la sal y la contraseña hasheada como un único string
        //     return $"{Convert.ToBase64String(salt)}.{hashed}";
        // }
        public static string HashPassword(string password)
        {
            // Generar una sal aleatoria
            byte[] salt = new byte[128 / 8];

            // Hashear la contraseña
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            // Devolver la sal y la contraseña hasheada como un único string
            return hashed;
        }
    }
}
