﻿using System.Linq;
using System.Web.Mvc;
using receivingAppDotNet.DataServices;
using receivingAppDotNet.Models;

namespace receivingAppDotNet.Controllers
{
    public class PartController : Controller
    {
        //
        // GET: /Part/
        public ActionResult Index()
        {
            return View(PartDataService.Parts.OrderBy(x => x.Name));
        }

        //
        // GET: /Part/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Part/Create
        [HttpPost]
        public ActionResult Create(Part part)
        {
            try
            {
                PartDataService.Parts.Add(part);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Part/Edit/5
        public ActionResult Edit(int id)
        {
            var model = PartDataService.Parts.Find(x => x.Id == id);

            return View(model);
        }

        //
        // POST: /Part/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Part part)
        {
            try
            {
                // Totally hacky but this is an example
                PartDataService.Parts.Remove(PartDataService.Parts.Find(x => x.Id == id));
                PartDataService.Parts.Add(part);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Part/Delete/5
        public ActionResult Delete(int id)
        {
            var model = PartDataService.Parts.Find(x => x.Id == id);

            return View(model);
        }

        //
        // POST: /Part/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                PartDataService.Parts.Remove(PartDataService.Parts.Find(x => x.Id == id));

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
