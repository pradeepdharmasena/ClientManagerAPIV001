using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagerAPIV001.Models
{
    public abstract class FieldDefintion
    {
        public int ID { get; set; }
        public string LabelName { get; set; } =  string.Empty;
        public int DataType { get; set; }
        public bool IsValueNullable { get; set; } = true;
        public bool IsRequired { get; set; } = false;
    }
}
