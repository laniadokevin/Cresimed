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
    public interface IUserRepository:IGenericService<User>
    {

        User GetById(int id);
        List<User> GetAll();
        PaginatedList<User> GetAllFiltered(string sortOrder, string currentFilter, string searchString, int? pageNumber, int rolID);
        int TotalUsersCount();
        int TotalFilteredCount(string searchString, int roleID);
        User processLogin(string username, string password);
        User EnableOrDisable(int id);
        User InsertUser(User user);
        User UpdateUser(User user);
        void DeleteUser(int id);
        bool CheckUserNameDisponibility(string name);
        bool CheckEmailDisponibility(string email);
        bool UpdatePwd(string password);
    }
}
