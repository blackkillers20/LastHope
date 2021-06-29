using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LastHope.DAL;
using LastHope.Models;

namespace LastHope.Views
{
    public class CourseTopicsController : Controller
    {
        private TrainingContext db = new TrainingContext();

        // GET: CourseTopics
        public async Task<ActionResult> Index()
        {
            return View(await db.CourseTopics.ToListAsync());
        }

        // GET: CourseTopics/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseTopic courseTopic = await db.CourseTopics.FindAsync(id);
            if (courseTopic == null)
            {
                return HttpNotFound();
            }
            return View(courseTopic);
        }

        // GET: CourseTopics/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseTopics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name,Descriptions,CourseID")] CourseTopic courseTopic)
        {
            if (ModelState.IsValid)
            {
                db.CourseTopics.Add(courseTopic);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(courseTopic);
        }

        // GET: CourseTopics/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseTopic courseTopic = await db.CourseTopics.FindAsync(id);
            if (courseTopic == null)
            {
                return HttpNotFound();
            }
            return View(courseTopic);
        }

        // POST: CourseTopics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,Descriptions,CourseID")] CourseTopic courseTopic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseTopic).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(courseTopic);
        }

        // GET: CourseTopics/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseTopic courseTopic = await db.CourseTopics.FindAsync(id);
            if (courseTopic == null)
            {
                return HttpNotFound();
            }
            return View(courseTopic);
        }

        // POST: CourseTopics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CourseTopic courseTopic = await db.CourseTopics.FindAsync(id);
            db.CourseTopics.Remove(courseTopic);
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
