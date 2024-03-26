using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_practica09_EsmeraldaGarcia.Models;

namespace MVC_practica09_EsmeraldaGarcia.Controllers
{
    public class EquipoControllercs : Controller
    {
        public IActionResult Index()
        {
            var listaDeMarcas = (from m in _equiposContext.marcas
                                 select m).ToList();
            ViewData["listadoDeMarcas"] = new SelectList(listaDeMarcas, "marca_id", "nombre_marca");
            return View();
        }

        private readonly  equiposContext _equiposContext;   
        public  EquipoControllercs(equiposContext equiposcontext) 
        { 
            _equiposContext = equiposcontext;
        }

    }
}
