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
    public interface ISpecialtyRepository : IGenericService<Specialty>
    {

        Specialty GetById(int id);
        List<Specialty> GetAll ();
        PaginatedList<Specialty> GetAllFiltered(string sortOrder, string currentFilter, string searchString, int? pageNumber);
        Specialty GetOrSave(Specialty specialty);
        Specialty UpdateSpecialty(Specialty specialty);
        void DeleteSpecialty(int id);
        int TotalSpecialtiesCount();
        int TotalFilteredCount(string searchString);


    }
}
