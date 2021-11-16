using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SchoolManagment.Models;

namespace SchoolManagment.Controllers
{
    public class EnrollmentsController : Controller
    {
        private SchoolManagmentEntities db = new SchoolManagmentEntities();

        // GET: Enrollment
        public async Task<ActionResult> Index()
        {
            var Enrollment = db.Enrollment.Include(e => e.Course).Include(e => e.Student).Include(e => e.Lecturers);
            return View(await Enrollment.ToListAsync());
        }

        // GET: Enrollment/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = await db.Enrollment.FindAsync(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }

        // GET: Enrollment/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Course, "CourseId", "Title");
            ViewBag.StudentID = new SelectList(db.Student, "StudentId", "FirstName");
            ViewBag.LecturerID = new SelectList(db.Lecturers, "Id", "FirstName");
            return View();
        }

        // POST: Enrollment/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "EnrollmentId,Grade,CourseID,StudentID,LecturerID")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                db.Enrollment.Add(enrollment);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Course, "CourseId", "Title", enrollment.CourseID);
            ViewBag.StudentID = new SelectList(db.Student, "StudentId", "FirstName", enrollment.StudentID);
            ViewBag.LecturerID = new SelectList(db.Lecturers, "Id", "FirstName", enrollment.LecturerID);
            return View(enrollment);
        }

        // GET: Enrollment/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = await db.Enrollment.FindAsync(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Course, "CourseId", "Title", enrollment.CourseID);
            ViewBag.StudentID = new SelectList(db.Student, "StudentId", "FirstName", enrollment.StudentID);
            ViewBag.LecturerID = new SelectList(db.Lecturers, "Id", "FirstName", enrollment.LecturerID);
            return View(enrollment);
        }

        // POST: Enrollment/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "EnrollmentId,Grade,CourseID,StudentID,LecturerID")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enrollment).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Course, "CourseId", "Title", enrollment.CourseID);
            ViewBag.StudentID = new SelectList(db.Student, "StudentId", "FirstName", enrollment.StudentID);
            ViewBag.LecturerID = new SelectList(db.Lecturers, "Id", "FirstName", enrollment.LecturerID);
            return View(enrollment);
        }

        // GET: Enrollment/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = await db.Enrollment.FindAsync(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }

        // POST: Enrollment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Enrollment enrollment = await db.Enrollment.FindAsync(id);
            db.Enrollment.Remove(enrollment);
            await db.SaveChangesAsync();
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
