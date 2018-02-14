using Lab1ED1_1C18.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab1ED1_1C18.Models;
using System.Net;

namespace Lab1ED1_1C18.Controllers
{
    public class JugadorController : Controller
    {

        DefaultConnection db = DefaultConnection.getInstance;

        // GET: Jugador
        public ActionResult Index()
        {
            return View(db.Jugadores.ToList());
        }

        // GET: Jugador/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Jugador/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jugador/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "JugadorID,Club,Nombre,Apellido,Posicion,Salario,Compensasion garantizada")] Jugador jugador)
        {
            try
            {
                // TODO: Add insert logic here
                jugador.jugadorID = ++db.IDActual;
                db.Jugadores.Add(jugador);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Jugador/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Jugador/Edit/5
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

        // GET: Jugador/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Jugador/Delete/5
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
