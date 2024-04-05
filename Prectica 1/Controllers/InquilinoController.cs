using System.Diagnostics;
using System.Configuration;
using Microsoft.AspNetCore.Mvc;
using Prectica_1.Models;

public class InquilinoController : Controller
{
    private readonly ILogger<InquilinoController> _logger;

    public InquilinoController(ILogger<InquilinoController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        RepositorioInquilino ri = new RepositorioInquilino();
        var lista = ri.GetInquilinos();
        return View(lista);
    }

    public IActionResult agregar(){
        return View();
    }

    public  IActionResult altaInquilino(Inquilino inquilino){
        RepositorioInquilino ri = new RepositorioInquilino();
        ri.guardarInquilino(inquilino);
        return RedirectToAction(nameof(Index));
    }


    public IActionResult EditarInquilino(int numero){
        RepositorioInquilino rp = new RepositorioInquilino();
        var inquilino = rp.ObtenerInquilinoPorId(numero);

        return  View(inquilino);
    }

     public IActionResult Editada(Inquilino inquilino)
    {
        RepositorioInquilino rp = new RepositorioInquilino();
        rp.EditaDatos(inquilino);
        return RedirectToAction(nameof(Index));
    }
    
    

    public  IActionResult Buscar(){
        return View();
    }

    public IActionResult buscarDNI(int dni){
        RepositorioInquilino ri =  new RepositorioInquilino();
        ri.buscarInquilinoPorDni(dni);
        return RedirectToAction(nameof(Index));
    }




    public  IActionResult Eliminar(int id){
        RepositorioInquilino ri = new RepositorioInquilino();
        var inquilino = ri.ObtenerInquilinoPorId(id);
        return  View(inquilino);
    }    

    public IActionResult bajaDeInquilino(Inquilino inquilino){
        RepositorioInquilino ri = new RepositorioInquilino();
        ri.elimiarInquilino(inquilino);
        return RedirectToAction(nameof(Index));
    } 

    








    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}