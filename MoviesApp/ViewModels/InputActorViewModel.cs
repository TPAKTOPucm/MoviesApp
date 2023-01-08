using MoviesApp.Filters;
using System;

namespace MoviesApp.ViewModels
{
	public class InputActorViewModel
	{
		[ActorsName]
		public string FirstName { get; set; }
		[ActorsName]
		public string LastName { get; set; }
		public DateTime BirthDay { get; set; }
	}
}
