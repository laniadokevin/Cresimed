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
    public interface IReportRepository : IGenericService<Report>
    {
        Report GetById(int id);
        List<Report> GetAll();
        PaginatedList<Report> GetAllFiltered(string sortOrder, string currentFilter, string searchString, int? pageNumber);
        Report InsertReport(Report Report);
        void DeleteReport(int id);
        int TotalReportsCount();
        int TotalFilteredCount(string searchString);
    }
}
