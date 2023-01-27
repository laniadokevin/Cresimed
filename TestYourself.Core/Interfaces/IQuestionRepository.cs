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
    public interface IQuestionRepository : IGenericService<Question>
    {

        Question InsertQuestion(Question question);
        Question GetById(int id);
        List<Question> GetAll();
        PaginatedList<Question> GetAllFiltered(string sortOrder, string currentFilter, string searchString, int? pageNumber, int CategoryID, int SpecialtyID);
        int GetLastID();
        int TotalQuestionsCount();
        int TotalFilteredCount(string searchString, int CategoryID, int SpecialtyID);
        Question UpdateQuestion(Question Question);
        void DeleteQuestion(int id);

    }
}
