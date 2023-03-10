using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestYourself.Core.Entities.Database
{
    public class Contact
    {
        public int ContactID { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email{ get; set; }
        public string Country { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
