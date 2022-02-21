using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConnectionData;
using DataComponent;

namespace Shopping.Controllers
{
    public class BoutiqueController : Controller
    {
        Boutique boutique = new Boutique();
        // GET: Boutique
        public ActionResult GetCloths()
        {
            var con = new DataConnection();
            var data = con.GetCloths();
            return View(data);
        }
        public ActionResult AddNewCloth()
        {
            var con = new DataConnection();
            return View(new Boutique());
        }
        [HttpPost]
        public ActionResult AddNewCloth(Boutique boutique)
        {
            var con = new DataConnection();
            try
            {
                con.AddNewCloth(boutique);
                return View("");
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                ViewBag.ErrorMessage = message;
                return View(new Boutique());
            }
        }
        public ActionResult UpdateCloth(string id)
        {
            int Id = Convert.ToInt32(id);
            var con = new DataConnection();
            try
            {
                var bo = con.UpdateCloth(id);
                return View("");
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public ActionResult UpdateCloth(Boutique boutique)
        {
            
            var con = new DataConnection();
            try
            {
                con.UpdateCloth(boutique);
              
                return RedirectToAction("GetCloths");
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ActionResult DeleteCloth(string id)
        {
            var con = new DataConnection();
            int CId = Convert.ToInt32(id);
            try
            {
                con.DeleteCloth(CId);
                return RedirectToAction("GetCloths");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                boutique.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}