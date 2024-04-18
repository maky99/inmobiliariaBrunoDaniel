using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Prectica_1.Models;


namespace Prectica_1.Controllers;

public class InformesController : Controller
{
    private readonly ILogger<InformesController> _logger;

    public InformesController(ILogger<InformesController> logger)
    {
        _logger = logger;
    }

    public IActionResult InformeIndex()
    {
        RepositorioInmueble rinmu=new RepositorioInmueble();
        var inmueble = rinmu.GetInmueble();
        ViewData["inmueble"] = inmueble;
        // RepositorioInquilino rInqui = new RepositorioInquilino();
        // var inquilino = rInqui.InquilinosAptos();
        // ViewData["inquilino"] = inquilino;

        // RepositorioContraro rc = new RepositorioContraro();
        // var contrato = rc.GetContratos();

        return View();
    }

}