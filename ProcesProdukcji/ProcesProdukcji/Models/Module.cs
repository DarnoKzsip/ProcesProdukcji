﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProcesProdukcji.Models
{
    public class Module
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double AssemblyTime { get; set; }
        public double Weight { get; set; }
        public string Description { get; set; }
        public virtual SearchHistory SearchHistory { get; set; }
    }
}