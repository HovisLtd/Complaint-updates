using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ComplaintsEntry.Models;

namespace ComplaintsEntry.Controllers
{
    public class ComplaintsController : Controller
    {
        private CarelineEntities db = new CarelineEntities();

        // GET: Complaints
        [Authorize(Roles = "ComplaintscanEdit")]
        public ActionResult Index()
        {
            DateTime MyDateTime = DateTime.Now.AddDays(-7);
            //return View(db.t_Prm_Fct_Complaints.ToList());

            //var t_Prm_Fct_Complaints = db.t_Prm_Fct_Complaints.Where(c => c.coReference == "290135");
            //return View(t_Prm_Fct_Complaints.ToList());

            var t_Prm_Fct_Complaints = db.t_Prm_Fct_Complaints.Where(c => c.coDateEntered > MyDateTime && c.coPremierCSNCode.Contains("H")).OrderByDescending(c => c.coReference);
            return View(t_Prm_Fct_Complaints.ToList());

        }

        // GET: Complaints/Details/5
        [Authorize(Roles = "ComplaintscanEdit")]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_Prm_Fct_Complaints t_Prm_Fct_Complaints = db.t_Prm_Fct_Complaints.Find(id);
            if (t_Prm_Fct_Complaints == null)
            {
                return HttpNotFound();
            }
            return View(t_Prm_Fct_Complaints);
        }

        // GET: Complaints/Create
        [Authorize(Roles = "ComplaintscanEdit")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Complaints/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ComplaintscanEdit")]
        public ActionResult Create([Bind(Include = "coID,coCarelineRef,coExtractDate,coReference,coType,coSource,coRetailer,coDateEntered,coBestBeforeDate,coRetailerStoreRef,coRetailerHORef,coProductionCode,coJulianCode,coAdditionalDetail,coComplaintCategory,coElement,coSubElement,coConsumerFault,coConfirmedAS,coDepartmentCode,coCurrencySymbol,coTotalReimbursement,coPremierCSNCode,coManufacturingLocation,coDoughCode,coBakery,coRetailerAdmin")] t_Prm_Fct_Complaints t_Prm_Fct_Complaints)
        {
            if (ModelState.IsValid)
            {
                db.t_Prm_Fct_Complaints.Add(t_Prm_Fct_Complaints);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t_Prm_Fct_Complaints);
        }

        // GET: Complaints/Edit/5
        [Authorize(Roles = "ComplaintscanEdit")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_Prm_Fct_Complaints t_Prm_Fct_Complaints = db.t_Prm_Fct_Complaints.Find(id);
            if (t_Prm_Fct_Complaints == null)
            {
                return HttpNotFound();
            }
            return View(t_Prm_Fct_Complaints);
        }

        // POST: Complaints/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ComplaintscanEdit")]
        public ActionResult Edit([Bind(Include = "coID,coCarelineRef,coExtractDate,coReference,coType,coSource,coRetailer,coDateEntered,coBestBeforeDate,coRetailerStoreRef,coRetailerHORef,coProductionCode,coJulianCode,coAdditionalDetail,coComplaintCategory,coElement,coSubElement,coConsumerFault,coConfirmedAS,coDepartmentCode,coCurrencySymbol,coTotalReimbursement,coPremierCSNCode,coManufacturingLocation,coDoughCode,coBakery,coRetailerAdmin")] t_Prm_Fct_Complaints t_Prm_Fct_Complaints)
        {
            if (ModelState.IsValid)
            {
                if (t_Prm_Fct_Complaints.coRetailerHORef == null) 
                {
                    t_Prm_Fct_Complaints.coRetailerHORef = "";
                }
                if (t_Prm_Fct_Complaints.coProductionCode == null)
                {
                    t_Prm_Fct_Complaints.coProductionCode = "";
                }
                if (t_Prm_Fct_Complaints.coJulianCode == null)
                {
                    t_Prm_Fct_Complaints.coJulianCode = "";
                }
                if (t_Prm_Fct_Complaints.coConfirmedAS == null)
                {
                    t_Prm_Fct_Complaints.coConfirmedAS = "";
                }
                if (t_Prm_Fct_Complaints.coDepartmentCode == null)
                {
                    t_Prm_Fct_Complaints.coDepartmentCode = "";
                }
                if (t_Prm_Fct_Complaints.coDoughCode == null)
                {
                    t_Prm_Fct_Complaints.coDoughCode = "";
                }
                if (t_Prm_Fct_Complaints.coBakery == null)
                {
                    t_Prm_Fct_Complaints.coBakery = "";
                }
                db.Entry(t_Prm_Fct_Complaints).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_Prm_Fct_Complaints);
        }

        // GET: Complaints/Delete/5
        [Authorize(Roles = "ComplaintscanEdit")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_Prm_Fct_Complaints t_Prm_Fct_Complaints = db.t_Prm_Fct_Complaints.Find(id);
            if (t_Prm_Fct_Complaints == null)
            {
                return HttpNotFound();
            }
            return View(t_Prm_Fct_Complaints);
        }

        // POST: Complaints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ComplaintscanEdit")]
        public ActionResult DeleteConfirmed(string id)
        {
            t_Prm_Fct_Complaints t_Prm_Fct_Complaints = db.t_Prm_Fct_Complaints.Find(id);
            db.t_Prm_Fct_Complaints.Remove(t_Prm_Fct_Complaints);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
