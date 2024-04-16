using System.Configuration;
using System.Net.WebSockets;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Prectica_1.Models;

public class UsuarioController : Controller
{
    // Si esta es la acción que estás usando para mostrar el formulario


    //GET 
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    // public IActionResult Login(string Clave, string  Email)
    // {
    //     if(Email != null){
    //         RepositorioUsuario ru =  new RepositorioUsuario();
    //         var usuario = ru.ObtenerPorEmail(Email);
    //         if(usuario.Clave == Clave){
    //             return RedirectToAction("Index", "Inquilino");
    //         }else{
    //             return RedirectToAction("Login","Usuario");
    //         }
    //     }else{
    //         return RedirectToAction("Login","Usuario");
    //     }

    // }

    public IActionResult Login(string Clave, string Email)
    {
        if (Email != null && Clave != null)
        {
            RepositorioUsuario ru = new RepositorioUsuario();
            var usuario = ru.ObtenerPorEmail(Email);
            string claveBase = usuario.Clave;
            string claveEntra = ru.HashPassword(Clave);
            if (claveBase.Equals(claveEntra))
            {
                return RedirectToAction("Index", "Inquilino");
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }
        else
        {
            return RedirectToAction("Login", "Usuario");
        }

    }

    [HttpPost]

    public IActionResult altaUsuario(Usuario _usuario)
    {
        if (ModelState.IsValid)
        {
            // Hashing de la contraseña
            _usuario.Clave = Usuario.HashPassword(_usuario.Clave);

            RepositorioUsuario ru = new RepositorioUsuario();
            ru.guardarUsuario(_usuario);

            // Redirigir al usuario después de guardar los datos
            return RedirectToAction("Index", "Home"); // Asegúrate de que "Index" y "Home" son los controlador y acción correctos
        }

        // Si hay un problema, vuelve a cargar la vista
        var roles = Usuario.ObtenerRoles();
        ViewBag.Roles = new SelectList(roles, "Key", "Value");
        return View("CrearUsuario", _usuario);
    }




    public IActionResult CrearUsuario()
    {
        var roles = Usuario.ObtenerRoles();
        ViewBag.Roles = new SelectList(roles, "Key", "Value");
        return View();
    }



    /*  //logIn

  [HttpPost]
  [AllowAnonymous]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> Login(Login login)
  {
      try
      {
          var returnUrl = string.IsNullOrEmpty(TempData["returnUrl"] as string) ? "/Inquilino/Index" : TempData["returnUrl"].ToString();

          //var returnUrl = string.IsNullOrEmpty(TempData["returnUrl"] as string) ? "/Home" : TempData["returnUrl"].ToString();
          if (ModelState.IsValid)
          {
              RepositorioUsuario ru = new RepositorioUsuario();
              var usuario = ru.ObtenerPorEmail(login.Email);
              if (usuario == null)
              {
                  ModelState.AddModelError("", "El email o la clave no son correctos");
                  TempData["returnUrl"] = returnUrl;
                  return View();
              }

              var claims = new List<Claim>
              {
                  new Claim(ClaimTypes.Name, usuario.Email),
                  new Claim("FullName", usuario.Nombre + " " + usuario.Apellido),
                  new Claim(ClaimTypes.Role, usuario.RolNombre),
              };

              var claimsIdentity = new ClaimsIdentity(
                      claims, CookieAuthenticationDefaults.AuthenticationScheme);

              await HttpContext.SignInAsync(
                      CookieAuthenticationDefaults.AuthenticationScheme,
                      new ClaimsPrincipal(claimsIdentity));
              TempData.Remove("returnUrl");
              return Redirect(returnUrl);
          }
          TempData["returnUrl"] = returnUrl;
          return View();
      }
      catch (Exception ex)
      {
          ModelState.AddModelError("", ex.Message);
          return View();
      }
  }

  */

    public IActionResult salir()
    {
        return RedirectToAction("Login", "Usuario");
    }
}

