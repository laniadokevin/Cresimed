using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestYourself.Core.Entities.Database;

namespace TestYourself.Core.Entities.ViewModel.Campus
{
    public class ContactViewModel
    {
        public Contact Contact { get; set; }
        public string Status { get; set; }
        public bool isOk { get; set; }
    }
}
