using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestYourself.Core.Entities.Database;

namespace TestYourself.Core.Entities.ViewModel.Campus
{
    public class DashboardViewModel
    {
        public ExamStatsViewModel PieChart { get; set; }
        public PercentilsViewModel PercentilChart { get; set; }
        public List<Exam> Last5Exams{ get; set; }
        
    }
}
