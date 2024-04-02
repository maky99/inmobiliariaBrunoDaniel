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
       
        return View();
    }
}