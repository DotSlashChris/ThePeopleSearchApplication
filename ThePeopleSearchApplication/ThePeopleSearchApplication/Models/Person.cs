using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ThePeopleSearchApplication.Models
{
	public class Person
	{
		#region Properties

		public int PersonID { get; set; }
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		public virtual Address Address { get; set; } // Virtual to take advantage of Entity Framework functionality like lazy loading.
		public string PictureURL { get; set; }
		public string Interests { get; set; }
		public string BirthDate { get; set; }
		public string Age { get { return toAgeString(); } }

		#endregion Properties

		#region Derived Properties

		public string FullName
		{
			get
			{
				return (this.FirstName + " " + this.MiddleName + " " + this.LastName).Replace("  ", " ");
			}
		}

		public string ShortName
		{
			get
			{
				return (this.FirstName + " " + this.LastName).Trim();
			}
		}

		#endregion Derived Properties

		#region Methods

		public List<string> GetInterestsList()
		{
			List<string> interestsList = this.Interests.Split(',').ToList<string>();
			interestsList.ForEach(s => s.Trim());

			return interestsList;
		}

		public void SetInterests(List<string> interestsList)
		{
			StringBuilder interests = new StringBuilder();
			foreach (string interest in interestsList)
			{
				if (interests.Length > 0)
				{
					interests.Append(", ");
                }
				interests.Append(interest);
			}

			this.Interests = interests.ToString();
		}

		#endregion Methods

		#region Functions

		private string toAgeString()
		{
			string ageString = "Unknown.";
			DateTime birthDate;
            DateTime.TryParse(this.BirthDate, out birthDate);
			if (birthDate != DateTime.MinValue)
			{
				DateTime today = DateTime.Today;
				int age = today.Year - birthDate.Year;
				if (birthDate > today.AddYears(-age))
				{
					age--; // Correction for days
				}
				ageString = age.ToString();
			}
			return ageString;
        }

		#endregion Functions
	}
}