﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CatalogoTiempos.Controllers
{
    public class Catalogo_Tiempos_LaboralesController : Controller
    {
        // GET: Catalogo_Tiempos_Laborales
        public ActionResult Listar()
        {
            ViewBag.Message = "Catálogo de Tiempos Laborales";
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
