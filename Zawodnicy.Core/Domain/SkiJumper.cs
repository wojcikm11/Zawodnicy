using System;
using System.Collections.Generic;
using Zawodnicy.Core.Domain;

namespace Zawodnicy.core.Domain
{
	public class SkiJumper
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string ForeName { get; set; }
		public string Country { get; set; }
		public DateTime BirthDate { get; set; }
		public double Height { get; set; }
		public double Weight { get; set; }
		public Trainer Trainer { get; set; }
		public List<Participation> Participations { get; set; }
    }
}
