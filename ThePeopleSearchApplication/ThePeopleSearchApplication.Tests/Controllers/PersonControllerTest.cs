using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThePeopleSearchApplication.Controllers;
using System.Web.Mvc;
using ThePeopleSearchApplication.Common;
using System.Web.Script.Serialization;
using System.Collections.Generic;

namespace ThePeopleSearchApplication.Tests.Controllers
{
	[TestClass]
	public class PersonControllerTest
	{
		static int testPersonID = -1;

		[TestMethod]
		public void PersonCreate()
		{
			// Arrange
			PersonController controller = new PersonController();

			// Act
			RedirectToRouteResult routeResult = controller.Create(new Models.Person { PersonID = 999999999, FirstName = "Firstname", MiddleName = "Middlename", LastName = "LastName" }) as RedirectToRouteResult;

			// Assert
			Assert.IsNotNull(routeResult);
			Assert.AreEqual(routeResult.RouteValues["action"], "Details");

			// Save person id for future tests
			testPersonID = System.Convert.ToInt16(routeResult.RouteValues["id"]);
		}

		[TestMethod]
		public void PersonSearch()
		{
			// Arrange
			PersonController controller = new PersonController();

			// Act
			JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
			JsonRequest jsonRequest = new JsonRequest();
			jsonRequest.keyword = "Firstname";
			jsonRequest.simulateSlow = false;
			PartialViewResult result = controller.PersonSearch(jsonSerializer.Serialize(jsonRequest)) as PartialViewResult;

			// Assert
			Assert.IsNotNull(result);
			List<Models.Person> personList = jsonSerializer.Deserialize(result.Model as string, typeof(List<Models.Person>)) as List<Models.Person>;
			Assert.IsNotNull(personList);
			Assert.IsTrue(personList.Count > 0);
			Assert.AreEqual("Firstname", personList[0].FirstName);
		}

		[TestMethod]
		public void PersonEdit()
		{
			// Arrange
			PersonController controller = new PersonController();

			// Act
			RedirectToRouteResult routeResult = controller.Edit(new Models.Person { PersonID = testPersonID, FirstName = "Firstname_Updated", MiddleName = "Middlename", LastName = "LastName" }) as RedirectToRouteResult;

			// Assert
			Assert.IsNotNull(routeResult);
			Assert.AreEqual(routeResult.RouteValues["action"], "Details");

			Models.Person person = controller.GetPerson(testPersonID);
            Assert.AreEqual("Firstname_Updated", person.FirstName);
		}

		[TestMethod]
		public void PersonDetails()
		{
			// Arrange
			PersonController controller = new PersonController();

			// Act
			ViewResult result = controller.Details(testPersonID) as ViewResult;

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual("Firstname_Updated", (result.Model as Models.Person).FirstName);
		}

		[TestMethod]
		public void PersonDeleteConfirmed()
		{
			// Arrange
			PersonController controller = new PersonController();

			// Act
			RedirectToRouteResult routeResult = controller.DeleteConfirmed(testPersonID) as RedirectToRouteResult;

			// Assert
			Assert.IsNotNull(routeResult);
			Assert.AreEqual(routeResult.RouteValues["action"], "../Home/Index");
			// Make sure the person was deleted
			Models.Person person = controller.GetPerson(testPersonID);
			Assert.IsNull(person);
		}
	}
}
