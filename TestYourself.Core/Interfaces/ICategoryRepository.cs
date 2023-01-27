using System;
using System.Collections.Generic;
using System.Text;
using TestYourself.Core.Entities;
using System.Threading.Tasks;
using TestYourself.Core.Services;
using TestYourself.Core.Entities.Database;
using TestYourself.Core.Entities.Base;

namespace TestYourself.Core.Interfaces
{
    public interface ICategoryRepository : IGenericService<Category>
    {

        Category GetById(int id);
        List<Category> GetAll();
        PaginatedList<Category> GetAllFiltered(string sortOrder, string currentFilter, string searchString, int? pageNumber);
        Category GetOrSave(Category Category);
        Category UpdateCategory(Category Category);
        void DeleteCategory(int id);
        int TotalCategoriesCount();
        int TotalFilteredCount(string searchString);
    }
}
