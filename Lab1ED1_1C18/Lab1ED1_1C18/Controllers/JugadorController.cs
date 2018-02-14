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
        Jugador eliminado,PersonaBuscada;


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
        public ActionResult Create([Bind(Include = "jugadorID,club,nombre,apellido,posicion,salarioBase,compensasion")] Jugador jugador)
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
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Corregir
            PersonaBuscada = db.Jugadores.Find(x => x.jugadorID == id);
            eliminado = PersonaBuscada;

            if (PersonaBuscada == null)
            {
                return HttpNotFound();
            }

            return View(PersonaBuscada);
        }

        // POST: Jugador/Delete/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete([Bind(Include = "jugadorID,club,nombre,apellido,posicion,salarioBase,compensasion")] Jugador jugador)
        {
            try
            {

                //Corregir
                eliminado = PersonaBuscada;
                db.Jugadores.Remove(eliminado);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
