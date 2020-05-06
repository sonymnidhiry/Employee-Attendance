using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrackEmployeeAbsence.Models;
using TrackEmployeeAbsence.ViewModel;

namespace TrackEmployeeAbsence.Controllers
{
    public class AbsenceListsController : Controller
    {
        private EmployeeAbsenceTrackerEntities1 db = new EmployeeAbsenceTrackerEntities1();

        // GET: AbsenceLists
        public ActionResult Index()
        {
            return View(db.AbsenceLists.ToList());
        }

        // GET: AbsenceLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AbsenceList absenceList = db.AbsenceLists.Find(id);
            if (absenceList == null)
            {
                return HttpNotFound();
            }
            return View(absenceList);
        }

        // GET: AbsenceLists/Create
        public ActionResult Create(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee emp = db.Employees.Find(id);
            EmployeeAbsenceViewModel employeeAbsenceViewModel = new EmployeeAbsenceViewModel()
            {
                EmployeeId = id,
                FirstName=emp.FirstName,
                LastName=emp.LastName
            };
            
          
            if (employeeAbsenceViewModel == null)
            {
                return HttpNotFound();
            }
            return View(employeeAbsenceViewModel);
        }

        // POST: AbsenceLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LeaveId,EmployeeId,FirstName,LastName,LeaveDate,LeaveReason")] EmployeeAbsenceViewModel employeeAbsenceViewModel)

        {
            if (ModelState.IsValid)
            {
                var data = db.SP_ApplyLeave(employeeAbsenceViewModel.EmployeeId, employeeAbsenceViewModel.FirstName, employeeAbsenceViewModel.LastName, employeeAbsenceViewModel.LeaveDate, employeeAbsenceViewModel.LeaveReason);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: AbsenceLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AbsenceList absenceList = db.AbsenceLists.Find(id);
            if (absenceList == null)
            {
                return HttpNotFound();
            }
            return View(absenceList);
        }

        // POST: AbsenceLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LeaveId,EmployeeId,FirstName,LastName,LeaveDate,LeaveReason")] AbsenceList absenceList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(absenceList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(absenceList);
        }

        // GET: AbsenceLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AbsenceList absenceList = db.AbsenceLists.Find(id);
            if (absenceList == null)
            {
                return HttpNotFound();
            }
            return View(absenceList);
        }

        // POST: AbsenceLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AbsenceList absenceList = db.AbsenceLists.Find(id);
            db.AbsenceLists.Remove(absenceList);
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
