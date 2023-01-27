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
    public class UserRoleRepository : GenericRepository<UserRole>,IUserRoleRepository
    {
        private readonly TestYourselfDBContext _context;

        public UserRoleRepository(TestYourselfDBContext context) : base(context)
        {
            _context = context;
        
        }

        public List<UserRole> GetUserRoles(int userID)
        {
            return _context.UserRoles.Include("Role").Where(x=>x.UserID == userID).ToList();
            
        }

        public void InsertOrUpdateUserRole(UserRole userRole)
        {
            var p = _context.UserRoles.Where(x => x.UserID == userRole.UserID && x.RoleID == userRole.RoleID).SingleOrDefault();

            if (p != null)
            {
                p.Enable = userRole.Enable; 
            }
            else
            {
                _context.UserRoles.Add(userRole);
            }
            _context.SaveChanges();
        }
    }
}
