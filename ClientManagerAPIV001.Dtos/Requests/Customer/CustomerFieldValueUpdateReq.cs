﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagerAPIV001.Dtos.Requests.Customer
{
    public class CustomerFieldValueUpdateReq
    {
        public string CustomerCD { get; set; } = string.Empty;
        public int  FieldID{ get; set; }
        public string? Name { get; set; }
        public string? Value { get; set; }
        public int? DataType { get; set; }
    }
}
