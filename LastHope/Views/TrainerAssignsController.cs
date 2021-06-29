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
    public class TrainerAssignsController : Controller
    {
        private TrainingContext db = new TrainingContext();

        // GET: TrainerAssigns
        public async Task<ActionResult> Index()
        {
            var trainerAssigns = db.TrainerAssigns.Include(t => t.Topic).Include(t => t.Trainer);
            return View(await trainerAssigns.ToListAsync());
        }

        // GET: TrainerAssigns/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainerAssign trainerAssign = await db.TrainerAssigns.FindAsync(id);
            if (trainerAssign == null)
            {
                return HttpNotFound();
            }
            return View(trainerAssign);
        }

        // GET: TrainerAssigns/Create
        public ActionResult Create()
        {
            ViewBag.TopicID = new SelectList(db.Topics, "TopicID", "Title");
            ViewBag.TrainerID = new SelectList(db.Trainers, "TrainerID", "Email");
            return View();
        }

        // POST: TrainerAssigns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,TopicID,TrainerID")] TrainerAssign trainerAssign)
        {
            if (ModelState.IsValid)
            {
                db.TrainerAssigns.Add(trainerAssign);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.TopicID = new SelectList(db.Topics, "TopicID", "Title", trainerAssign.TopicID);
            ViewBag.TrainerID = new SelectList(db.Trainers, "TrainerID", "Email", trainerAssign.TrainerID);
            return View(trainerAssign);
        }

        // GET: TrainerAssigns/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainerAssign trainerAssign = await db.TrainerAssigns.FindAsync(id);
            if (trainerAssign == null)
            {
                return HttpNotFound();
            }
            ViewBag.TopicID = new SelectList(db.Topics, "TopicID", "Title", trainerAssign.TopicID);
            ViewBag.TrainerID = new SelectList(db.Trainers, "TrainerID", "Email", trainerAssign.TrainerID);
            return View(trainerAssign);
        }

        // POST: TrainerAssigns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,TopicID,TrainerID")] TrainerAssign trainerAssign)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainerAssign).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.TopicID = new SelectList(db.Topics, "TopicID", "Title", trainerAssign.TopicID);
            ViewBag.TrainerID = new SelectList(db.Trainers, "TrainerID", "Email", trainerAssign.TrainerID);
            return View(trainerAssign);
        }

        // GET: TrainerAssigns/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainerAssign trainerAssign = await db.TrainerAssigns.FindAsync(id);
            if (trainerAssign == null)
            {
                return HttpNotFound();
            }
            return View(trainerAssign);
        }

        // POST: TrainerAssigns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TrainerAssign trainerAssign = await db.TrainerAssigns.FindAsync(id);
            db.TrainerAssigns.Remove(trainerAssign);
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
