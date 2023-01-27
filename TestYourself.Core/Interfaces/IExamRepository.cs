using System;
using System.Collections.Generic;
using System.Text;
using TestYourself.Core.Entities;
using System.Threading.Tasks;
using TestYourself.Core.Services;
using TestYourself.Core.Entities.Database;
using TestYourself.Core.Entities.ViewModel.Campus;
using TestYourself.Core.Entities.Base;

namespace TestYourself.Core.Interfaces
{
    public interface IExamRepository:IGenericService<Exam>
    {
        Exam GetById(int id);
        Exam GetNewExam(CreateExamIndexViewModel filters);
        PaginatedList<Exam> GetAllFiltered(int userID, string sortOrder, string currentFilter, string searchString, int? pageNumber);
        Exam InsertNewExam(List<Question> questions, CreateExamIndexViewModel filters);
        Exam AnswerExam(List<ExamDetail> details);
        int TotalExamsCount(int userID);
        List<Exam> GetAllExams(int userID);
        ExamStatsViewModel GetAllBySpecialty(int userID);
        List<Exam> GetLast5Exams(int userID);



    }
}
