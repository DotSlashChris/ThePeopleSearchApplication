using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using ThePeopleSearchApplication.Common;
using ThePeopleSearchApplication.DataAccessLayer;
using ThePeopleSearchApplication.Models;

namespace ThePeopleSearchApplication.Controllers
{
    public class PersonController : Controller
    {
        private PeopleSearchContext db = new PeopleSearchContext();

		public PartialViewResult PersonSearch(string json)
		{
			JavaScriptSerializer jsonDecoder = new JavaScriptSerializer();
			JsonRequest jsonRequest = jsonDecoder.Deserialize<JsonRequest>(json);

			// Simulate a slow search.
			if (jsonRequest.simulateSlow == true)
			{
				System.Threading.Thread.Sleep(5000); // Sleep for 5 seconds.
			}

			// Retrieve results from database if there is valid input. Otherwise just return an empty result set.
			List<Person> model = new List<Person>();
			if (!string.IsNullOrEmpty(jsonRequest.keyword))
			{
				model = new List<Person>();
				var linqQuery = db.Persons.Where(p => p.FirstName.Contains(jsonRequest.keyword) || p.LastName.Contains(jsonRequest.keyword));
				model = linqQuery.ToList();
			}

			// Return results as JSON
			JavaScriptSerializer jsonWriter = new JavaScriptSerializer();
			string modelJson = jsonWriter.Serialize(model);
            return PartialView(viewName: "PersonResultsPartialView", model: modelJson);
		}

		// Direct call to get a person from the database without changing view state
		public Person GetPerson(int personID)
		{
			return db.Persons.Find(personID);
		}

        // GET: Person/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonID,FirstName,MiddleName,LastName,PictureURL,Interests")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Persons.Add(person);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = person.PersonID });
            }

            return View(person);
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: Person/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonID,FirstName,MiddleName,LastName,PictureURL,Interests,BirthDate")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", new { id = person.PersonID });
            }
            return View(person);
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = db.Persons.Find(id);
            db.Persons.Remove(person);
            db.SaveChanges();
            return RedirectToAction("../Home/Index");
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
