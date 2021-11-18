using IBMServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebAppProvaIBM.Models;

namespace WebAppProvaIBM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]        
        public IActionResult Enviar(InformacoesDTO model)
        {
            var data = new DateTime(model.Ano, DateTime.Now.Month, DateTime.Now.Day);            
            var servico = new CalculadorInssService();
            var resultado = servico.CalcularDesconto(data, model.Salario);

            var novaModel = new ResultadoDTO();
            novaModel.Desconto = resultado;

            if (resultado == 0) novaModel.MensagemErro = "Houve algum problema durante a execução, entre em contato com o suporte.";

            return View("Resultado", novaModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
