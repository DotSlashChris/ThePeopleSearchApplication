using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThePeopleSearchApplication.Models
{
	public class Address
	{
		#region Properties

		public int AddressID { get; set; }
		public int PersonID { get; set; }
        public string Address1 { get; set; }
		public string Address2 { get; set; }
		public string City { get; set; }
		public string County { get; set; }
		public string State { get; set; }
		public string PostalCode { get; set; }
		public string Country { get; set; }

		#endregion Properties
	}
}