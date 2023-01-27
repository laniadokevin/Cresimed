using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestYourself.Core.Entities.Database;

namespace TestYourself.Core.Entities.ViewModel.Web
{
    public class FrontWebViewModel
    {
        public FrontWebViewModel()
        { 
            Faqs = new List<Faq>();
        }
        public List<Faq> Faqs { get; set; }
        public Contact Contact { get; set; }
    }
}
