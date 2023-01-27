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
    public interface IFaqRepository : IGenericService<Faq>
    {
        Faq GetById(int id);
        List<Faq> GetAll();
        PaginatedList<Faq> GetAllFiltered(string sortOrder, string currentFilter, string searchString, int? pageNumber);
        Faq InsertFaq(Faq Faq);
        Faq UpdateFaq(Faq Faq);
        void DeleteFaq(int id);
        int TotalFaqsCount();
        int TotalFilteredCount(string searchString);
    }
}
