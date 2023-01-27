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
    public interface ICareerRepository : IGenericService<Career>
    {
        Career GetById(int id);
        List<Career> GetAll();
        PaginatedList<Career> GetAllFiltered(string sortOrder, string currentFilter, string searchString, int? pageNumber);
        Career GetOrSave(Career Career);
        Career UpdateCareer(Career Career);
        void DeleteCareer(int id);
        int TotalCareersCount();
        int TotalFilteredCount(string searchString);

    }
}
