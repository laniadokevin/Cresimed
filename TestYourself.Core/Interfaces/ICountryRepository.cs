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
    public interface ICountryRepository : IGenericService<Country>
    {

        Country GetById(int id);
        List<Country> GetAll();
        PaginatedList<Country> GetAllFiltered(string sortOrder, string currentFilter, string searchString, int? pageNumber);
        Country GetOrSave(Country Country);
        Country UpdateCountry(Country Country);
        void DeleteCountry(int id);
        int TotalCountriesCount();
        int TotalFilteredCount(string searchString);

    }
}
