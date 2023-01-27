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
    public class CategoryGridViewModel
    {
        public CategoryGridViewModel()
        {
            NewCategory = new Category();
        }
        public Category NewCategory { get; set; }
        public PaginatedList<Category> Categories { get; set; }
    }
}
