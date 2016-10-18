using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
		public string FormattedAddress
		{
			get
			{
				return toFormattedText();
            }
		}

		#endregion Properties

		#region Functions

		private string toFormattedText()
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (!string.IsNullOrEmpty(this.Address1))
			{
				stringBuilder.AppendLine(this.Address1);
			}
			if (!string.IsNullOrEmpty(this.Address2))
			{
				stringBuilder.AppendLine(Address2);
			}
			if (!string.IsNullOrEmpty(this.City) && !string.IsNullOrEmpty(this.State))
			{
				stringBuilder.Append(this.City + ", " + this.State + " ");
			}
			else
			{
				stringBuilder.Append((this.City + " " + this.State).Trim() + " ");
			}
			if (!string.IsNullOrEmpty(this.PostalCode))
			{
				stringBuilder.AppendLine(this.PostalCode);
			}
			if (!string.IsNullOrEmpty(this.Country))
			{
				stringBuilder.AppendLine(this.Country);
			}

			return stringBuilder.ToString();
		}


		#endregion Functions
	}
}