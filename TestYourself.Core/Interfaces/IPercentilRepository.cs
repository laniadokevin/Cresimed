using System;
using System.Collections.Generic;
using System.Text;
using TestYourself.Core.Entities;
using System.Threading.Tasks;
using TestYourself.Core.Services;
using TestYourself.Core.Entities.Database;
using TestYourself.Core.Entities.Base;
using TestYourself.Core.Entities.ViewModel.Campus;

namespace TestYourself.Core.Interfaces
{
    public interface IPercentilRepository : IGenericService<Percentil>
    {
        Percentil UpdatePercentil(List<ExamDetail> examDetails);
        PercentilsViewModel GetPercentilsForUser(int userID);


    }
}
