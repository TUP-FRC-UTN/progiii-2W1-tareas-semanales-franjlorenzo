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
    public class ActualizarPersonaController : Controller
    {
        // GET: ActualizarPersona
        public ActionResult ActualizarPersona(int idPersona)
        {
            List<SexoItemVM> listaTipo = AccesoDeDatos_SexoPersonaVM.ObtenerListaSexos(); //ESTO PARA VIEWMODELS

            List<SelectListItem> itemsCombo = listaTipo.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Nombre,
                    Value = d.IdSexo.ToString(),
                    Selected = false
                };
            });
            ViewBag.items = itemsCombo;

            Persona resultado = AccesoDatos_ActualizarPersona.ObtenerPersona(idPersona);

            foreach (var item in itemsCombo)
            {
                if (item.Value.Equals(resultado.IdSexo.ToString()))
                {
                    item.Selected = true;
                    break;
                }
            }
            return View(resultado);
        }
        
        [HttpPost]
        public ActionResult ActualizarPersona(Persona model)
        {
            if (ModelState.IsValid)
            {
                bool resultado = AccesoDatos_ActualizarPersona.ActualizarPersona(model);
                if (resultado)
                {
                    return RedirectToAction("ListadoPersona", "ListadoPersona");
                }
                else
                {
                    return View(model);
                }
            }
            return View();      
        }
    }
}