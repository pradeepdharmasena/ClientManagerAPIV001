using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagerAPIV001.Dtos.Requests.Customer
{
    public class CustomerFieldDefUpdateReq
    {
        public int ID { get; set; }
        public string? LabelName { get; set; }
        public int? DataType { get; set; }
        public bool? IsValueNullable { get; set; } 
        public bool? IsRequired { get; set; }
    }
}
