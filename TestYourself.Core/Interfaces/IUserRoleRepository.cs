using System;
using System.Collections.Generic;
using System.Text;
using TestYourself.Core.Entities;
using System.Threading.Tasks;
using TestYourself.Core.Services;
using TestYourself.Core.Entities.Database;
using TestYourself.Core.Entities.Base;

namespace TestYourself.Core.Interfaces
{
    public interface IUserRoleRepository:IGenericService<UserRole>
    {
        void InsertOrUpdateUserRole(UserRole userRole);
        List<UserRole> GetUserRoles(int userID);
    }
}
