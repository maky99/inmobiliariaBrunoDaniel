using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Prectica_1.Models;


namespace Prectica_1.Controllers;

public class ContratoController : Controller
{
    private readonly ILogger<ContratoController> _logger;

    public ContratoController(ILogger<ContratoController> logger)
    {
        _logger = logger;
    }

    public IActionResult ContratoIndex()
    {
        RepositorioInmueble ri = new RepositorioInmueble();
        var inmueble = ri.InmuebleLibre();
        ViewData["inmueble"] = inmueble;
        RepositorioInquilino rInqui = new RepositorioInquilino();
        var inquilino = rInqui.InquilinosAptos();
        ViewData["inquilino"] = inquilino;

        RepositorioContraro rc = new RepositorioContraro();
        var contrato = rc.GetContratos();

        return View(contrato);
    }

    public IActionResult ContratoNuevo()
    {
        RepositorioContraro rc = new RepositorioContraro();
        var inquilinosSinContrato = rc.inquilinosSinContrato();
        var inmueblesSinContrato = rc.inmueblesSinContrato();
        ViewData["inquilino"] = inquilinosSinContrato;
        ViewData["inmueble"] = inmueblesSinContrato;

        return View();
    }

    public IActionResult NuevoContrato(Contrato contrato)
    {
        RepositorioContraro rc = new RepositorioContraro();
        rc.GuardarContrato(contrato);

        return RedirectToAction(nameof(ContratoIndex));
    }
    
    public IActionResult ContratoBajaMulta(int numid)
    {
                RepositorioContraro rc = new RepositorioContraro();
        var contrato = rc.Contrato(numid);

        return View(contrato);
    }
    public IActionResult Finalizacion(Contrato contrato)
    {
        RepositorioContrato2 rc = new RepositorioContrato2();
       // rc.GuardarContratoFinalizado(contrato);

        rc.modifiContra(contrato);

        return RedirectToAction(nameof(ContratoIndex));
    }

    public IActionResult ActaContrato(int numid){
        Console.WriteLine("ID CONTRATO " + numid);
        RepositorioContraro rc = new RepositorioContraro();
       
        var resultado = rc.getDetallesContrato(numid);
        if (resultado == null) {
            Console.WriteLine("No se encontró ningún contrato con el ID especificado.");
        }else {
            Console.WriteLine("Contrato obtenido con éxito.");
        }
        return View(resultado);
    }


}