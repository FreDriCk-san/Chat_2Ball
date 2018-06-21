using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Chat_2Ball.Context;
using Chat_2Ball.Models;

namespace Chat_2Ball.Controllers
{
    public class UsersController : Controller
    {
        private ContextDB db = new ContextDB();

        // GET: Users
        public async Task<ActionResult> Index()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = await db.Users.Select(u => new { ConnectionId = u.ConnectionId, Name = u.Name }).ToListAsync();
            return result;
        }

        //// GET: Users/Details/5
        //public async Task<ActionResult> Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Users users = await db.Users.FindAsync(id);
        //    if (users == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(users);
        //}

        //// GET: Users/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(string ConnectionId, string Name)
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            var user = db.Users.FirstOrDefault(u => u.Name == Name);
            if (ModelState.IsValid && null == user)
            {
                db.Users.Add(new Users { ConnectionId = ConnectionId, Name = Name });
                await db.SaveChangesAsync();
                result.Data = true;
                return result;
            }

            result.Data = false;
            return RedirectPermanent("/Home/Index");
        }

        //// GET: Users/Edit/5
        //public async Task<ActionResult> Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Users users = await db.Users.FindAsync(id);
        //    if (users == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(users);
        //}

        //// POST: Users/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "ConnectionId,Name")] Users users)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(users).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return View(users);
        //}

        //// GET: Users/Delete/5
        //public async Task<ActionResult> Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Users users = await db.Users.FindAsync(id);
        //    if (users == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(users);
        //}

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            Users users = await db.Users.FindAsync(id);
            if(null != users)
            {
                db.Users.Remove(users);
                await db.SaveChangesAsync();
                result.Data = true;
                return result;
            }

            result.Data = false;
            return result;
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
