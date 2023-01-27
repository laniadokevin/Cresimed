using System;
using System.Collections.Generic;
using System.Text;
using TestYourself.Core.Entities;
using System.Threading.Tasks;
using TestYourself.Core.Services;
using TestYourself.Core.Entities.Database;
using Microsoft.EntityFrameworkCore;
using TestYourself.Core.Entities.Base;

namespace TestYourself.Core.Interfaces
{
    public interface IAnswerRepository : IGenericService<Answer>
    {

        Answer InsertAnswer(Answer answer);
        Answer GetById(int id);
        List<Answer> GetAnswersForQuestion (int QuestionID);
        Answer UpdateAnswer(Answer Answer);
        int DeleteAnswer(int id);

    }
}
