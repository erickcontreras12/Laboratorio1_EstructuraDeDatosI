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
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Jugador jugadorBuscado = db.Jugadores.Find(x => x.jugadorID == id);

            if (jugadorBuscado == null)
            {
                return HttpNotFound();
            }

            return View(jugadorBuscado);
        }

        // POST: Jugador/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "JugadorID,Club,Nombre,Apellido,Posicion,Salario,Compensasion garantizada")] Jugador jugador)
        {
            try
            {
                // TODO: Add update logic here
                Jugador jugadorBuscado = db.Jugadores.Find(x => x.jugadorID == jugador.jugadorID);
                if (jugadorBuscado == null)
                {
                    return HttpNotFound();
                }

                jugadorBuscado.salarioBase = jugador.salarioBase;
                jugadorBuscado.club = jugador.club;
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
