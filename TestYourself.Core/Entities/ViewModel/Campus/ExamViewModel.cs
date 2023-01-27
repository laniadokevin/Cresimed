using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestYourself.Core.Entities.Database;

namespace TestYourself.Core.Entities.ViewModel.Campus
{
    public class ExamViewModel
    {
        public ExamViewModel()
        {
            Exam = new Exam();
        }
        public Exam Exam { get; set; } 
        public List<Question> Questions { get; set; } 

    }
}
