using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClientManagerAPIV001.Models
{
    public class CustomerFieldValue : FieldValue
    {
        public long CustomerID { get; set; }
    }
}
