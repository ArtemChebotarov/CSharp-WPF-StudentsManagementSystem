using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeansOffice.DAL
{
	public class Student
	{
        public string IdStudent { get; set; }
		public string IndexNumber { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string IdStudies { get; set; }
		public string Address { get; set; }
        public List<int> Subjects { get; set; }
	}

   
}

