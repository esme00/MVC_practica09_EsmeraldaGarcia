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

            var listaDetipo = (from m in _equiposContext.tipo_equipo
                                 select m).ToList();
            ViewData["listadotipo"] = new SelectList(listaDetipo, "tipo_equipo_id", "descripcion");

            var listaDeEstado = (from m in _equiposContext.marcas
                                 select m).ToList();
            ViewData["listadoEstado"] = new SelectList(listaDeEstado, "marca_id", "estados");


            var listadodeequipo = (from e in  _equiposContext.equipos
                                   join m in _equiposContext.marcas  on e.marca_id equals m.marca_id
                                   select new{
                nombre = e.nombre,
                descripcion = e.descripcion,
                marca_id = e.marca_id,
                marca_nombre = m.nombre_marca
            }).ToList();
            ViewData["listadodeequipo"] = listadodeequipo;

           return View();
        }


        public IActionResult CrearEquipos(equipos nuevoEquipo)
        {
            _equiposContext.Add(nuevoEquipo); 
            _equiposContext.SaveChanges();

            return RedirectToAction("Index");
        }
       

        private readonly  equiposContext _equiposContext;   
        public  EquipoControllercs(equiposContext equiposcontext) 
        { 
            _equiposContext = equiposcontext;
        }

    }
}
