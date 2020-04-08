using System;

namespace Lab6
{
	class Employee
	{
		public readonly string Firstname;
		public readonly string Lastname;
		public readonly DateTime DateOfBirth;
		public DateTime DateOfEmployment { get; set; }
		public Employee(string firstname, string lastname, DateTime dateOfBirth, DateTime dateOfEmployment)
		{
			ParamCheck.IsNullOrWhitespace(firstname);
			ParamCheck.IsNullOrWhitespace(lastname);
			
			Firstname = firstname;
			Lastname = lastname;
			DateOfBirth = dateOfBirth;
			DateOfEmployment = dateOfEmployment;
		}
	}
}
