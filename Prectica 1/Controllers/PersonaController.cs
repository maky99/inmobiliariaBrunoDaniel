using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Prectica_1.Models;


namespace Prectica_1.Controllers;

public class PersonaController : Controller
{
    private readonly ILogger<PersonaController> _logger;

    public PersonaController(ILogger<PersonaController> logger)
    {
        _logger = logger;
    }

    public IActionResult PersonaIndex()
    {
        RepositorioPersona ri = new RepositorioPersona();
        var lista = ri.GetPersonas();
        return View(lista);
    }
    public IActionResult NuevaPersona()
    {
        return View();
    }

    public IActionResult AltaNuevaPersona(Persona persona)
    {
        RepositorioPersona rp = new RepositorioPersona();
        rp.GuardarPersona(persona);
        return RedirectToAction(nameof(PersonaIndex));
    }

    public IActionResult EditarPersona(int numero)
    {
        RepositorioPersona rp = new RepositorioPersona();
        var persona = rp.ObtenerPersonaPorId(numero);

        return View(persona);
    }
    public IActionResult Editada(Persona persona)
    {
        RepositorioPersona rp = new RepositorioPersona();
        rp.EditaDatos(persona);
        return RedirectToAction(nameof(PersonaIndex));
    }
    public IActionResult EliminaPersona(int numero)
    {
        RepositorioPersona rp = new RepositorioPersona();
        var persona = rp.ObtenerPersonaPorId(numero);

        return View(persona);
    }
    public IActionResult EditaEstado(Persona persona)
    {
        RepositorioPersona rp = new RepositorioPersona();
        rp.EditaDatos(persona);
        return RedirectToAction(nameof(PersonaIndex));
    }
    public IActionResult BuscarPersona()
    {
        return View();
    }
    public IActionResult BuscaNuevaPersona()
    {
        return View();
    }
    public IActionResult BuscaNuevaPersonaDNI(int dni)
    {
        RepositorioPersona rp = new RepositorioPersona();
        var persona = rp.BuscaNuevaPersonaDNI(dni);

        if (persona.dni == 99)
        {
            return RedirectToAction(nameof(NuevaPersona));
        }
        else
        {
            return RedirectToAction(nameof(EditarPersona), new { numero = persona.id });
        }

    }


}
