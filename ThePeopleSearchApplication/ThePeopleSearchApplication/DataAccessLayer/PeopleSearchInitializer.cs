using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThePeopleSearchApplication.Models;

namespace ThePeopleSearchApplication.DataAccessLayer
{
	public class PeopleSearchInitializer: System.Data.Entity.DropCreateDatabaseIfModelChanges<PeopleSearchContext>
	{
		protected override void Seed(PeopleSearchContext context)
		{
			var persons = new List<Person>
			{
				new Person
				{
					FirstName = "Chris",
					MiddleName = "Paul",
					LastName = "Johnston",
					Address = new Address
					{
						Address1 = "7843 S. Prospector Dr.",
						City = "Salt Lake City",
						State = "UT",
						PostalCode = "84121",
						Country = "US"
					},
					PictureURL = "https://media.licdn.com/mpr/mpr/shrinknp_400_400/p/1/000/0a1/211/2f5f6df.jpg",
					Interests = "Health Catalyst, Software, Technology, Weight Lifting, Mobile Phones, Hiking, Skiing, Snowboarding, Movies, Comic Books, Bowling, Pocket Billiards, Italy, Video Games, VR",
				},
				new Person
				{
					FirstName = "Christopher",
					MiddleName = "D'Olier",
					LastName = "Reeve",
					Address = new Address
					{
						Address1 = "636 Morris Turnpike",
						Address2 = "Suite 3A",
                        City = "Short Hills",
						State = "NJ",
						PostalCode = "07078",
						Country = "US"
					},
					PictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/2e/C_Reeve_in_Marriage_of_Figaro_Opening_night_1985.jpg/220px-C_Reeve_in_Marriage_of_Figaro_Opening_night_1985.jpg",
					Interests = "Acting, directing, producing, screenwriting, writing, activism",
				},
				new Person
				{
					FirstName = "Stephen",
					LastName = "Barlow",
					Address = new Address
					{
						Address1 = "3165 Millrock Dr.",
						Address2 = "#400",
						City = "Salt Lake City",
						State = "UT",
						PostalCode = "84121",
						Country = "US"
					},
					PictureURL = "https://media.licdn.com/mpr/mpr/shrinknp_400_400/p/1/000/262/03e/122fd8d.jpg",
					Interests = "Health Catalyst, Software, Technology, Best People, Company Growth",
				},
				new Person
				{
					FirstName = "Tom",
					LastName = "Burton",
					Address = new Address
					{
						Address1 = "3165 Millrock Dr.",
						Address2 = "#400",
						City = "Salt Lake City",
						State = "UT",
						PostalCode = "84121",
						Country = "US"
					},
					PictureURL = "https://media.licdn.com/media/p/2/000/01e/3c5/19b56c4.jpg",
					Interests = "Health Catalyst, Software, Technology, Best People, Company Growth",
				},
				new Person
				{
					FirstName = "Dale",
					LastName = "Sanders",
					Address = new Address
					{
						Address1 = "3165 Millrock Dr.",
						Address2 = "#400",
						City = "Salt Lake City",
						State = "UT",
						PostalCode = "84121",
						Country = "US"
					},
					PictureURL = "https://media.licdn.com/mpr/mpr/shrinknp_400_400/AAEAAQAAAAAAAAk1AAAAJGVmN2RmZTFkLWY1NTYtNDU3NC1iZjFjLWUyM2JjMTNiMDVjMA.jpg",
					Interests = "Health Catalyst, Software, Technology, Best People, Company Growth",
				},
				new Person
				{
					FirstName = "Trevor",
					LastName = "Smith",
					Address = new Address
					{
						Address1 = "3165 Millrock Dr.",
						Address2 = "#400",
						City = "Salt Lake City",
						State = "UT",
						PostalCode = "84121",
						Country = "US"
					},
					PictureURL = "https://media.licdn.com/media/AAEAAQAAAAAAAAT0AAAAJDk5NDhiYTMzLTZhOTMtNDE4ZC04NjI1LWUxNmEwNDE5MTc0Nw.jpg",
					Interests = "Health Catalyst, Software, Technology, Best People, Recruiting, Getting Chris Johnston On Board",
			}
			};

			persons.ForEach(p => context.Persons.Add(p));
			context.SaveChanges();
		}
	}
}