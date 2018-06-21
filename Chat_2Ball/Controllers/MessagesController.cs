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
    public class MessagesController : Controller
    {
        private ContextDB db = new ContextDB();

        // GET: Messages
        public async Task<ActionResult> Index()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            result.Data = await db.Messages.Select(s => new { Id = s.Id, Text = s.Text, UsersId = s.UsersId }).ToListAsync();

            return result;

        }

        //// GET: Messages/Details/5
        //public async Task<ActionResult> Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Messages messages = await db.Messages.FindAsync(id);
        //    if (messages == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(messages);
        //}

        //// GET: Messages/Create
        //public ActionResult Create()
        //{
        //    ViewBag.UsersId = new SelectList(db.Users, "ConnectionId", "Name");
        //    return View();
        //}

        // POST: Messages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(string Text, byte?[] Image, string UserId)
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            if (ModelState.IsValid)
            {
                db.Messages.Add( new Messages { Text = Text, Image = Image, UsersId = UserId });
                await db.SaveChangesAsync();
                result.Data = new Messages { Text = Text, Image = Image, UsersId = UserId };
                return result;
            }

            result.Data = false;
            return result;
        }

        //// GET: Messages/Edit/5
        //public async Task<ActionResult> Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Messages messages = await db.Messages.FindAsync(id);
        //    if (messages == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.UsersId = new SelectList(db.Users, "ConnectionId", "Name", messages.UsersId);
        //    return View(messages);
        //}

        // POST: Messages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string Text, byte?[] Image, string UserId)
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            if (ModelState.IsValid)
            {
                db.Entry(new Messages { Text = Text, Image = Image, UsersId = UserId }).State = EntityState.Modified;
                await db.SaveChangesAsync();
                result.Data = new Messages { Text = Text, Image = Image, UsersId = UserId };
                return result;
            }

            result.Data = false;
            return result;
        }

        //// GET: Messages/Delete/5
        //public async Task<ActionResult> Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Messages messages = await db.Messages.FindAsync(id);
        //    if (messages == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(messages);
        //}

        // POST: Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            Messages messages = await db.Messages.FindAsync(id);
            if(null != messages)
            {
                db.Messages.Remove(messages);
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
