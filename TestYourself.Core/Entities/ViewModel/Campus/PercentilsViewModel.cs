using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestYourself.Core.Entities.Database;

namespace TestYourself.Core.Entities.ViewModel.Campus
{
    public class PercentilsViewModel
    {
        public PercentilsViewModel()
        {
            Percentils = new List<Percentil>();
        }

        public int TotalCorrect { get; set; }
        public int TotalIncorrect { get; set; }
        public int TotalCount { get; set; }
        public List<Percentil> Percentils { get; set; }

    }
}
