﻿using System;
using System.Collections.Generic;
using System.Text;
using Zawodnicy.core.Domain;

namespace Zawodnicy.Core.Domain
{
    public class Participation
    {
        public int Id { get; set; }
        public SkiJumper SkiJumper { get; set; }
        public Competition Competition { get; set; }
    }
}
