using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestYourself.Core.Entities.Base;
using TestYourself.Core.Entities.Database;

namespace TestYourself.Core.Entities.ViewModel.Admin.Grid
{
    public class SpecialtyGridViewModel
    {
        public SpecialtyGridViewModel()
        {
            NewSpecialty = new Specialty();
            Countries = new List<Country>();
            Careers = new List<Career>();
        }
        public Specialty NewSpecialty { get; set; }
        public PaginatedList<Specialty> Specialties { get; set; }
        public List<Country> Countries { get; set; }
        public List<Career> Careers { get; set; }
    }
}
