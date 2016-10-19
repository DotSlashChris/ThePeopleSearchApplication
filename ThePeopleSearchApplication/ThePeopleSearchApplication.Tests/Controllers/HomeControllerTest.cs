using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThePeopleSearchApplication;
using ThePeopleSearchApplication.Controllers;

namespace ThePeopleSearchApplication.Tests.Controllers
{
	[TestClass]
	public class HomeControllerTest
	{
		[TestMethod]
		public void HomeIndex()
		{
			// Arrange
			HomeController controller = new HomeController();

			// Act
			ViewResult result = controller.Index() as ViewResult;

			// Assert
			Assert.IsNotNull(result);
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			Assert.AreEqual("Index", (result as ViewResult).ViewName);
		}

		[TestMethod]
		public void HomeAbout()
		{
			// Arrange
			HomeController controller = new HomeController();

			// Act
			ActionResult result = controller.About();

			// Assert
			Assert.IsNotNull(result);
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			Assert.AreEqual("About", (result as ViewResult).ViewName);
		}
	}
}
