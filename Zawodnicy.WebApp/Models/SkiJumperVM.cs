using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zawodnicy.WebApp.Models
{
    public class SkiJumperVM
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public string ForeName { get; set; }
		public string Country { get; set; }
		public DateTime BirthDate { get; set; }
		public double Height { get; set; }
		public double Weight { get; set; }
	}
}
