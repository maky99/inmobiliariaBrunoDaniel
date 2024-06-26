using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Prectica_1.Models;


namespace Prectica_1.Controllers;

public class InmuebleController : Controller
{
    private readonly ILogger<InmuebleController> _logger;

    public InmuebleController(ILogger<InmuebleController> logger)
    {
        _logger = logger;
    }

    public IActionResult InmuebleIndex()
    {
        RepositorioInmueble ri = new RepositorioInmueble();
        var lista = ri.GetInmueble();
        return View(lista);
    }
    public IActionResult InmuebleNuevo()
    {
        RepositorioPropietario rp = new RepositorioPropietario();
        var lisPro = rp.PropietarioMuestra();
        ViewData["propietario"] = lisPro;

        return View();
    }

    public IActionResult AltaNuevoInmueble(Inmueble inmueble)
    {

        RepositorioInmueble ri = new RepositorioInmueble();
        ri.GuardarInmueble(inmueble);
        return RedirectToAction(nameof(InmuebleIndex));
    }


    public IActionResult InmuebleEditar(int numero)
    {
        RepositorioInmueble ri = new RepositorioInmueble();
        var inmueble = ri.ObtenerInmueblePorId(numero);
        RepositorioPropietario rp = new RepositorioPropietario();
        var propietarios = rp.PropietarioMuestra(); // Cambia esto según cómo obtengas la lista de propietarios en tu aplicación

        ViewData["propietario"] = propietarios;

        return View(inmueble);
    }

    public IActionResult Editada(Inmueble inmueble)
    {
        RepositorioInmueble ri = new RepositorioInmueble();
        ri.EditaDatosInmueble(inmueble);
        return RedirectToAction(nameof(InmuebleIndex));
    }
    public IActionResult EliminaInmueble(int numero)
    {
        RepositorioInmueble ri = new RepositorioInmueble();
        ri.EliminarInmueblePorId(numero);
        return RedirectToAction(nameof(InmuebleIndex));
    }


}