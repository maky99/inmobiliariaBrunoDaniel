using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Prectica_1.Models;


namespace Prectica_1.Controllers;

public class PagoController : Controller
{
    private readonly ILogger<PagoController> _logger;

    public PagoController(ILogger<PagoController> logger)
    {
        _logger = logger;
    }

    public IActionResult PagoIndex()
    {
       RepositorioPago rp=new RepositorioPago();
       var lista = rp.GetPagos();
        return View(lista);
    }
    

}
