using CatalogoTiempos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CatalogoTiempos.Controllers
{
    public class Catalogo_Tiempos_LaboralesController : Controller
    {
        public ActionResult Agregar(String horario) {
            Tiempos t = new Tiempos { TC_Horario = horario, TH_Duracion = "00:00:00" };

            //primero debemos confirmar si el tiempo ya existe
            Tiempos temp = t.consultarTiempo(t);
            if (temp.TC_Horario == null){
                int res = t.agregarTiempos(t);
            }
            else {
                if (temp.TC_Horario.Equals(t.TC_Horario) && temp.TH_Duracion.Equals(t.TH_Duracion)){
                    ViewBag.Respuesta = "El registro de tiempo ya existe";
                }else{
                    int res = t.agregarTiempos(t);
                }
            }


            ViewBag.Message = "Catálogo de Tiempos Laborales";
            List<Tiempos> lista = new Tiempos().listarTiempos();
            ViewBag.ListaTiempos = lista;
            return View("Listar");
        }

        public int Eliminar(String horario) {
            Tiempos temp = new Tiempos().consultarTiempo(new Tiempos { TC_Horario = horario, TH_Duracion = "00:00:00" });
            if (temp.TC_Horario == null){
                ViewBag.Respuesta = "El registro '" + horario + "' no existe";
                return 0;
            }else{
                Tiempos t = new Tiempos();
                t.TC_Horario = horario;
                t.TH_Duracion = "00:00:00";
                ViewBag.Respuesta = "El registro se eliminó correctamente";
                return t.eliminarTiempos(horario);
            }
        }


        public ActionResult Actualizar(String viejo, String nuevo) {

            //confirmar que existe un registro con el nombre viejo
            Tiempos temp = new Tiempos().consultarTiempo(new Tiempos {TC_Horario = viejo, TH_Duracion= "00:00:00" });
            if (temp.TC_Horario == null){
                ViewBag.Respuesta = "El registro '"+viejo+"' no existe";
            }
            else {
                Tiempos t = new Tiempos();
                t.TC_Horario = nuevo;
                t.TH_Duracion = "00:00:00";
                int res = t.actualizarTiempos(viejo, t);
                ViewBag.Respuesta = "El registro se actualizó correctamente";
            }

            ViewBag.Message = "Catálogo de Tiempos Laborales";
            List<Tiempos> lista = new Tiempos().listarTiempos();
            ViewBag.ListaTiempos = lista;
            return View("Listar");
        }

        // GET: Catalogo_Tiempos_Laborales
        public ActionResult Listar()
        {
            ViewBag.Message = "Catálogo de Tiempos Laborales";
            List<Tiempos> lista = new Tiempos().listarTiempos();
            ViewBag.ListaTiempos = lista;
            ViewBag.Respuesta = "";

            return View();
        }

        // GET: Catalogo_Tiempos_Laborales/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Catalogo_Tiempos_Laborales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Catalogo_Tiempos_Laborales/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Catalogo_Tiempos_Laborales/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Catalogo_Tiempos_Laborales/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Catalogo_Tiempos_Laborales/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Catalogo_Tiempos_Laborales/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
