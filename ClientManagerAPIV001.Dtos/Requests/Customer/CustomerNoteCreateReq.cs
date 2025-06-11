using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagerAPIV001.Dtos.Requests.Customer
{
    public class CustomerNoteCreateReq
    {
        public Guid CustomerCD {  get; set; }
        public int ID { get; set; }
        public string Title { get; set; } = string.Empty;
        public required string Value { get; set; }
    }
}
