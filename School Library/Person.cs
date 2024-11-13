using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLibrary
{
	public class Person
	{
		//#region Instance fields
		//private int id;
		//private string name;
		//#endregion

		#region Constructor
		//public Person (int id, string name)
		//{
		//	Id = id;
		//	Name = name;
		//}
		#endregion


		public enum GenderType
		{
			Male,
			Female,
			Other
		}

		#region Properties
		public int Id { get; set; }
		public string Name { get; set; }
		public GenderType Gender { get; set; }
		#endregion


		#region Methods
		public void ValidateName()
		{
			if (string.IsNullOrEmpty(Name))
			{
				throw new ArgumentException("Name space can't be empty");
			}
		}
		#endregion
	}
}
