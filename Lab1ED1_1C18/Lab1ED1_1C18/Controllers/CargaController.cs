using Lab1ED1_1C18.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Lab1ED1_1C18.DBContext;
using System.Web.Mvc;
using System.Net;

namespace Lab1ED1_1C18.Controllers
{
    public class CargaController : Controller
    {
        ConnectionCSV db = ConnectionCSV.getInstance;

        // GET: Carga
        public ActionResult Index()
        {
            return View(db.Jugadores.ToList());
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase postedFile)
        {            
            if (postedFile != null)
            {
                

                string filepath = string.Empty;
                string path = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                filepath = path + Path.GetFileName(postedFile.FileName);
                string extension = Path.GetExtension(postedFile.FileName);
                postedFile.SaveAs(filepath);

                string csvData = System.IO.File.ReadAllText(filepath);
                foreach (string row in csvData.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        try
                        {
                                                  
                            db.Jugadores.Add(new Jugador
                            {

                                club = row.Split(',')[0],
                                apellido = row.Split(',')[1],
                                nombre = row.Split(',')[2],
                                posicion = row.Split(',')[3],
                                salarioBase = Convert.ToDouble(row.Split(',')[4]),
                                compensasion = Convert.ToDouble(row.Split(',')[5]),
                                
                            });
                        }catch(Exception e)
                        {
                            ViewBag.Message = "Dato erroneo.";
                        }
                    }
                }
            
            ViewBag.Message = "File uploaded successfully.";
            }

            return View(db.Jugadores.ToList());
        }

        // GET: Carga/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Carga/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Carga/Create
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

        // GET: Carga/Edit/5
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

        // POST: Carga/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "jugadorID,club,nombre,apellido,posicion,salarioBase,compensasion")] Jugador jugador)
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

        // GET: Carga/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Carga/Delete/5
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
