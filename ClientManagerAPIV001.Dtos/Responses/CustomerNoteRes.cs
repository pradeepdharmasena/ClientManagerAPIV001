using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagerAPIV001.Dtos.Responses
{
    public class CustomerNoteRes
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public required string Value { get; set; }
    }
}
