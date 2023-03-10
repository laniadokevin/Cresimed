using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestYourself.Core.Entities.Database;

namespace TestYourself.Core.Entities.ViewModel.Admin.Edition
{
    public class CareerViewViewModel
    {
        public CareerViewViewModel()
        {
            Career = new Career();
            Countries = new List<Country>();
        }
        public Career Career { get; set; }
        public List<Country> Countries { get; set; }
    }
}
