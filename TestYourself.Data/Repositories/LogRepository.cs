using System;
using System.Collections.Generic;
using System.Text;
using TestYourself.Core.Interfaces;
using TestYourself.Core.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq;
using TestYourself.Core.Entities.Const;
using TestYourself.Core.Entities.Database;

namespace TestYourself.Data.Repositories
{
    public class LogRepository : GenericRepository<Log>, ILogRepository
    {
        private readonly TestYourselfDBContext _context;

        public LogRepository(TestYourselfDBContext context) : base(context)
        {
            _context = context;

        }

        public void SaveLog(Log log)
        {
            _context.Logs.Add(log);
            _context.SaveChanges();
        }

    }
}