using System;
using System.Collections.Generic;
using System.Text;
using TestYourself.Core.Entities;
using System.Threading.Tasks;
using TestYourself.Core.Services;
using TestYourself.Core.Entities.Database;

namespace TestYourself.Core.Interfaces
{
    public interface ILogRepository:IGenericService<Log>
    {
        void SaveLog(Log log);

    }
}
