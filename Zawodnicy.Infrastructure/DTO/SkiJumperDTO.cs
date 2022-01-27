using System;
using System.Collections.Generic;
using System.Text;
using Zawodnicy.Core.Domain;

namespace Zawodnicy.Infrastructure.DTO
{
    public class SkiJumperDTO
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public string ForeName { get; set; }
		public string Country { get; set; }
		public DateTime BirthDate { get; set; }
		public double Height { get; set; }
		public double Weight { get; set; }

        public override bool Equals(object obj)
        {
            return obj is SkiJumperDTO dTO &&
                   Id == dTO.Id &&
                   Name == dTO.Name &&
                   ForeName == dTO.ForeName &&
                   Country == dTO.Country &&
                   BirthDate == dTO.BirthDate &&
                   Height == dTO.Height &&
                   Weight == dTO.Weight;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, ForeName, Country, BirthDate, Height, Weight);
        }
    }
}
