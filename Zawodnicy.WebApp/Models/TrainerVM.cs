using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zawodnicy.WebApp.Models
{
    public class TrainerVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
