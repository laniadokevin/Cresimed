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
    public interface IContactRepository : IGenericService<Contact>
    {
        Contact GetById(int id);
        List<Contact> GetAll();
        PaginatedList<Contact> GetAllFiltered(string sortOrder, string currentFilter, string searchString, int? pageNumber);
        Contact SaveContact(Contact Contact);
        void DeleteContact(int id);
        int TotalContactsCount();
        int TotalFilteredCount(string searchString);

    }
}
