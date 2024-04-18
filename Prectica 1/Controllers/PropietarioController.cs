using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Prectica_1.Models;


namespace Prectica_1.Controllers;

public class PropietarioController : Controller
{
    private readonly ILogger<PropietarioController> _logger;

    public PropietarioController(ILogger<PropietarioController> logger)
    {
        _logger = logger;
    }

    public IActionResult PropietarioIndex()
    {
        RepositorioPropietario ri = new RepositorioPropietario();
        var lista = ri.GetPropietario();
        return View(lista);
    }

    public IActionResult NuevaPropietario()
    {
        return View();
    }

    public IActionResult AltaNuevaPropietario(Propietario propietario)
    {
        if (!ModelState.IsValid){
            return View(nameof(NuevaPropietario));
        }
        RepositorioPropietario rp = new RepositorioPropietario();
        rp.GuardarPropietario(propietario);
        return RedirectToAction(nameof(PropietarioIndex));
    }

    public IActionResult EditarPropietario(int numero)
    {
        RepositorioPropietario rp = new RepositorioPropietario();
        var propietario = rp.ObtenerPropietarioPorId(numero);

        return View(propietario);
    }
    public IActionResult Editada(Propietario propietario)
    {
        RepositorioPropietario rp = new RepositorioPropietario();
        rp.EditaDatos(propietario);
        return RedirectToAction(nameof(PropietarioIndex));
    }
    public IActionResult EliminaPropietario(int numero)
    {
        RepositorioPropietario rp = new RepositorioPropietario();
        rp.CambioEstado(numero);

        return RedirectToAction(nameof(PropietarioIndex));
    }
    public IActionResult EditaEstado(Propietario propietario)
    {
        RepositorioPropietario rp = new RepositorioPropietario();
        rp.EditaDatos(propietario);
        return RedirectToAction(nameof(PropietarioIndex));
    }
    public IActionResult BuscarPropietario()
    {
        return View();
    }
    public IActionResult BuscaNuevaPropietario()
    {
        return View();
    }
    public IActionResult BuscaNuevaPropietarioDNI(int dni)
    {
        RepositorioPropietario rp = new RepositorioPropietario();
        var propietario = rp.BuscaNuevaPropietarioDNI(dni);

        if (propietario.dni == 99)
        {
            return RedirectToAction(nameof(NuevaPropietario));
        }
        else
        {
            if (propietario.estado == 1)
            {
                return RedirectToAction(nameof(EditarPropietario), new { numero = propietario.id_propietario });
            }
            else
            {
                return RedirectToAction(nameof(EditarPropietario2), new { numero = propietario.id_propietario });
            }
        }

    }
    public IActionResult PropietarioMuestra()
    {
        RepositorioPropietario ri = new RepositorioPropietario();
        var lista = ri.PropietarioMuestra();
        return View(lista);
    }
    public IActionResult EditarPropietario2(int numero)
    {
        RepositorioPropietario rp = new RepositorioPropietario();
        var propietario = rp.ObtenerPropietarioPorId(numero);

        return View(propietario);
    }


}

