using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestYourself.Core.Entities.Database;

namespace TestYourself.Core.Entities.ViewModel.Admin.Edition
{
    public class KeyWordViewViewModel
    {
        public KeyWord KeyWord { get; set; }
        public Question Question { get; set; }
    }
}
