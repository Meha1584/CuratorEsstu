﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entity
{
    public class BasisOfLearning
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Student> Students { get; set; }
    }
}
