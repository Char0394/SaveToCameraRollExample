using System;

namespace ContextActionXamarin.Model
{
	public class Food
	{
		public string Name {get;set;}
		public string Image { get; set; }

		public string NameSort
		{
			get 
			{
				if (string.IsNullOrWhiteSpace(Name) || Name.Length == 0)
					return "?";

				return Name[0].ToString().ToUpper();
			}
		}
	}
}

