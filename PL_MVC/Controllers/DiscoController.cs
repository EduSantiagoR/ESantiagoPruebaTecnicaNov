using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class DiscoController : Controller
    {
        public ActionResult GetAll()
        {
            ML.Result result = BL.Disco.GetAll();
            ML.Disco disco = new ML.Disco();
            disco.Discos = result.Objects;
            return View(disco);
        }
        [HttpGet]
        public ActionResult Form(int? idDisco)
        {
            if(idDisco != null)
            {
                ML.Result result = BL.Disco.GetById(idDisco.Value);
                ML.Disco disco = result.Object as ML.Disco;
                return View(disco);
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Form(ML.Disco disco)
        {
            if(disco.IdDisco == 0)
            {
                ML.Result result = BL.Disco.Add(disco);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "Agregado correctamente";
                }
                else
                {
                    ViewBag.Mensaje = result.Message;
                }
            }
            else
            {
                ML.Result result = BL.Disco.Update(disco);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "Actualizado correctamente";
                }
                else
                {
                    ViewBag.Mensaje = result.Message;
                }
            }
            return PartialView("Modal");
        }
        public ActionResult Delete(int idDisco)
        {
            ML.Result result = BL.Disco.Delete(idDisco);
            if (result.Correct)
            {
                ViewBag.Mensaje = "Eliminado correctamente";
            }
            else
            {
                ViewBag.Mensaje = result.Message;
            }
            return PartialView("Modal");
        }
    }
}