using System;
using System.Collections.Generic;
using System.Text;
using TestYourself.Core.Interfaces;
using TestYourself.Core.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq;
using TestYourself.Core.Entities.Database;
using TestYourself.Core.Entities.Base;

namespace TestYourself.Data.Repositories
{
    public class AnswerRepository : GenericRepository<Answer>, IAnswerRepository
    {
        private readonly TestYourselfDBContext _context;

        public AnswerRepository(TestYourselfDBContext context) : base(context)
        {
            _context = context;

        }

        public int DeleteAnswer(int id)
        {
            Answer answer = _context.Answers.Where(x => x.AnswerID == id).SingleOrDefault();
            int questionid = answer.QuestionID;
            _context.Remove(answer);
            _context.SaveChanges();
            return questionid;
        }

        public List<Answer> GetAnswersForQuestion(int QuestionID)
        {
            return _context.Answers.Where(x => x.QuestionID == QuestionID).ToList();
        }

        public Answer GetById(int id)
        {
            var p = _context.Answers.Where(x => x.AnswerID == id).SingleOrDefault();

            return p;
        }

        public Answer InsertAnswer(Answer answer)
        {

            _context.Answers.Add(answer);
            _context.SaveChanges();
                

            return answer;
        }

        public Answer UpdateAnswer(Answer answer)
        {
            var p = _context.Answers.Where(x => x.AnswerID == answer.AnswerID).SingleOrDefault();
            if (p != null)
            {
                p.Text = answer.Text;
                p.QuestionID = answer.QuestionID;
                p.IsCorrect = answer.IsCorrect;
                p.Ratio = answer.Ratio;

                _context.SaveChanges();
            }
            return p;
        }
    }
}




