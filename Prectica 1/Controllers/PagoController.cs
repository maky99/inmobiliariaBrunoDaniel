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
        RepositorioPago rp = new RepositorioPago();
        var lista = rp.GetPagos();
        return View(lista);
    }
    public IActionResult PagoNuevo()
    {
        RepositorioPago rc = new RepositorioPago();
        var contratosVigentes = rc.GetContratosVigentes();
        ViewData["ContratosVigentes"] = contratosVigentes;

        return View();
    }

    public IActionResult PagoGuardar(Pago pago)
    {
        RepositorioPago rp = new RepositorioPago();
        rp.GuardarPago(pago);
        return RedirectToAction(nameof(PagoIndex));
    }
    public IActionResult PagoNuevoDirecto(int numid)
    {
        RepositorioContraro rc = new RepositorioContraro();
        var contrato = rc.ContratoMonto(numid);
        ViewData["contra"] = contrato;

        return View();
    }
    public IActionResult PagoEditar(int numid)
    {
        RepositorioPago rp = new RepositorioPago();
        var traepago = rp.BuscarPagoPorId(numid);

        return View(traepago);
    }
    public IActionResult PagoEditarCocnepto(int id_pago, string concepto)
    {
        RepositorioPago rp = new RepositorioPago();
        rp.modifiConcepto(id_pago, concepto);

        return RedirectToAction(nameof(PagoIndex));
    }
    public IActionResult AnulaPago(int id_pago)
    {
        RepositorioPago rp = new RepositorioPago();
        rp.modifiEstado(id_pago);

        return RedirectToAction(nameof(PagoIndex));
    }


}
