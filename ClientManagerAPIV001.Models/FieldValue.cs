﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagerAPIV001.Models
{
    public abstract class FieldValue
    {
        public int ID { get; set; }
        public string? Value { get; set; }
    }
}
