using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagerAPIV001.Dtos.Responses
{
    public class CustomerFieldRes
    {
        public int ID { get; set; }
        public string LabelName { get; set; } = string.Empty;
        public int DataType { get; set; }
        public bool IsValueNullable { get; set; } = true;
        public bool IsRequired { get; set; } = false;
        public string? Value { get; set; }
    }
}
