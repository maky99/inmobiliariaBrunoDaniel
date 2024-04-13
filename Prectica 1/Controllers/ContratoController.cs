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
    RepositorioInmueble ri = new RepositorioInmueble();
    var inmueble = ri.InmuebleLibre();
    ViewData["inmueble"] = inmueble;

    RepositorioInquilino rInqui = new RepositorioInquilino();
    var inquilino = rInqui.InquilinosAptos();
    ViewData["inquilino"] = inquilino;

    RepositorioContraro rc = new RepositorioContraro();
    var contrato = rc.Contrato(numid);

    return View(contrato); 
}
public IActionResult Finalizacion(Contrato contrato)
    {
        RepositorioContraro rc = new RepositorioContraro();
        rc.GuardarContratoFinalizado(contrato);

        return RedirectToAction(nameof(ContratoIndex));
    }



}