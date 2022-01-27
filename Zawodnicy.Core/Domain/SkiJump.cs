using System;
using System.Collections.Generic;
using System.Text;

namespace Zawodnicy.Core.Domain
{
    public class SkiJump
    {
        public int Id { get; set; }
        public Town Town { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }
        public int DesignPoint { get; set; }
        public int JudgePoint { get; set; }
    }
}
