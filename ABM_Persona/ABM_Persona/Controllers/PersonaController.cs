using ABM_Persona.AccesoDeDatos;
using ABM_Persona.Models;
using ABM_Persona.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ABM_Persona.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult CargarNuevaPersona() //Este metodo muestra la vista CargarNuevaPersona
        {
            List<SexoItemVM> listaTipo = AccesoDeDatos_SexoPersonaVM.ObtenerListaSexos(); //ESTO PARA VIEWMODELS

            List<SelectListItem> items = listaTipo.ConvertAll(d => //ESTO PARA VIEWMODELS. Convierte la listaTipo en una SelectListItem
            {
                return new SelectListItem()
                {
                    Text = d.Nombre, //El texto del combo va a ser lo que haya en d.NombreTipo
                    Value = d.IdSexo.ToString(), //El value de cada item del combo va a ser lo que haya en d.IdTipo
                    Selected = false //Para que no haya ninguna opcion seleccionada cuando se carga el combo
                };
            });
            ViewBag.items = items; //Con esto llevamos el valor de la lista items a la vista para que cargue el combo

            return View();
        }

        [HttpPost]
        public ActionResult CargarNuevaPersona(Persona persona)
        {
            if (ModelState.IsValid)
            {
                bool resultado = AccesoDatos_Persona.InsertarNuevaPersona(persona);
                if (resultado)
                {
                    return RedirectToAction("ListadoPersona", "ListadoPersona");
                }
                else
                {
                    return View(persona);
                }
            }
            else
            {
                return View(persona);
            } 
        }
    }
}