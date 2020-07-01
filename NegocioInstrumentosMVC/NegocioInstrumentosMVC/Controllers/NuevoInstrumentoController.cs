using NegocioInstrumentosMVC.AccesoDeDatos;
using NegocioInstrumentosMVC.Models;
using NegocioInstrumentosMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NegocioInstrumentosMVC.Controllers
{
    public class NuevoInstrumentoController : Controller
    {
        // GET: NuevoInstrumento
        public ActionResult NuevoInstrumento()
        {
            List<TipoItemVM> listaTipo = AD_TipoInstrumentoVM.ObtenerListaTiposInstrumentos(); //ESTO PARA VIEWMODELS

            List<SelectListItem> items = listaTipo.ConvertAll(d => //ESTO PARA VIEWMODELS. Convierte la listaTipo en una SelectListItem
            {
                return new SelectListItem()
                {
                    Text = d.NombreTipo, //El texto del combo va a ser lo que haya en d.NombreTipo
                    Value = d.IdTipo.ToString(), //El value de cada item del combo va a ser lo que haya en d.IdTipo
                    Selected = false //Para que no haya ninguna opcion seleccionada cuando se carga el combo
                };
            });
            ViewBag.items = items; //Con esto llevamos el valor de la lista items a la vista para que cargue el combo

            return View();
        }

        [HttpPost]
        public ActionResult NuevoInstrumento(Instrumento instrumento)
        {
            if (ModelState.IsValid)
            {
                bool resultado = AD_NuevoInstrumento.InsertarNuevoInstrumento(instrumento);
                if (resultado)
                {
                    return RedirectToAction("NuevoInstrumento", "NuevoInstrumento");
                }
                else
                {
                    return View(instrumento);
                }
            }
            else
            {
                return View(instrumento);
            }
        }
    }
}