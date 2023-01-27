using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestYourself.Core.Entities.Database;

namespace TestYourself.Core.Entities.ViewModel.Admin.Edition
{
    public class CountryViewViewModel
    {
        public CountryViewViewModel()
        {
            Country = new Country();
        }
        public Country Country { get; set; }
    }
}
