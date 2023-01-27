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
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        private readonly TestYourselfDBContext _context;

        public RoleRepository(TestYourselfDBContext context) : base(context)
        {
            _context = context;

        }

        public List<Role> GetAll()
        {
            return _context.Roles.ToList();
        }

        public void SaveRole(Role Role)
        {
            _context.Roles.Add(Role);
            _context.SaveChanges();
        }

    }
}