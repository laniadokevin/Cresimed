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
using Microsoft.Data.SqlClient;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace TestYourself.Data.Repositories
{
    public class UserRepository : GenericRepository<User>,IUserRepository
    {
        private readonly TestYourselfDBContext _context;

        public UserRepository(TestYourselfDBContext context) : base(context)
        {
            _context = context;
        
        }

        public List<User> GetAll()
        {
            var u = _context.Users.Where(x => x.Deleted == false).Include("UserRoles").Include("UserRoles.Role").ToList();
         
            return u;
        }
        public PaginatedList<User> GetAllFiltered(string sortOrder, string currentFilter, string searchString, int? pageNumber, int rolID)
        {

            var user = _context.Users.Where(x=>x.Deleted == false).Include("UserRoles").Include("UserRoles.Role").AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
            {
          
                user = user.Where(s => (s.FullName.ToLower().Replace("à", "a")
                .Replace("â", "a")
                .Replace("ä", "a")
                .Replace("ç", "c")
                .Replace("é", "e")
                .Replace("è", "e")
                .Replace("ê", "e")
                .Replace("ë", "e")
                .Replace("î", "i")
                .Replace("ï", "i")
                .Replace("ô", "o")
                .Replace("ù", "u")
                .Replace("û", "u")
                .Replace("ü", "u").Contains(searchString) || s.Email.ToLower().Replace("à", "a")
                .Replace("â", "a")
                .Replace("ä", "a")
                .Replace("ç", "c")
                .Replace("é", "e")
                .Replace("è", "e")
                .Replace("ê", "e")
                .Replace("ë", "e")
                .Replace("î", "i")
                .Replace("ï", "i")
                .Replace("ô", "o")
                .Replace("ù", "u")
                .Replace("û", "u")
                .Replace("ü", "u").Contains(searchString) || s.Username.ToLower().Replace("à", "a")
                .Replace("â", "a")
                .Replace("ä", "a")
                .Replace("ç", "c")
                .Replace("é", "e")
                .Replace("è", "e")
                .Replace("ê", "e")
                .Replace("ë", "e")
                .Replace("î", "i")
                .Replace("ï", "i")
                .Replace("ô", "o")
                .Replace("ù", "u")
                .Replace("û", "u")
                .Replace("ü", "u").Contains(searchString)));
            }

            if (rolID > 0)
            {
                user = user.Where(s=>s.UserRoles.Where(x=>x.RoleID == rolID).SingleOrDefault().Enable);
            }
            switch (sortOrder)
            {

                case "ID":
                    user = user.OrderBy(s => s.UserID);
                    break;
                case "ID_desc":
                    user = user.OrderByDescending(s => s.UserID);
                    break;
                case "Username":
                    user = user.OrderBy(s => s.Username);
                    break;
                case "Username_desc":
                    user = user.OrderByDescending(s => s.Username);
                    break;
                case "Fullname":
                    user = user.OrderBy(s => s.FullName);
                    break;
                case "Fullname_desc":
                    user = user.OrderByDescending(s => s.FullName);
                    break;
                case "Email":
                    user = user.OrderBy(s => s.Email);
                    break;
                case "Email_desc":
                    user = user.OrderByDescending(s => s.Email);
                    break;
                case "Enabled":
                    user = user.OrderBy(s => s.Enable);
                    break;
                case "Enabled_desc":
                    user = user.OrderByDescending(s => s.Enable);
                    break;
                default:
                    user = user.OrderByDescending(s => s.UserID);
                    break;
            }

            int pageSize = 20;
            return PaginatedList<User>.Create(user, pageNumber ?? 1, pageSize);

        }
        public User GetById(int id)
        {
            var p = _context.Users.Include(x=>x.UserRoles.Where(a=>a.Enable == true)).Where(x => x.UserID == id).SingleOrDefault();
           

            return p;
        }
        public User processLogin(string username, string password)
        {
            var user = _context.Users.Where(x=>x.Deleted == false).Include(x=>x.UserRoles).ThenInclude(x=>x.Role).SingleOrDefault(a => a.Username.Equals(username) && a.Enable == true);
            if (user != null)
            {
                if (BCrypt.Net.BCrypt.Verify(password, user.Password))
                {
                    return user;
                }
            }
            return null;
        }
        public User EnableOrDisable(int id)
        {
            var u = _context.Users.Where(x => x.UserID == id).SingleOrDefault();
            
            u.Enable = !u.Enable;
            
            _context.SaveChanges();
            
            return u;
        }
        public User InsertUser(User user)
        {
            try
            {
                user.DateAdded = DateTime.Now;
                user.Deleted = false;

                _context.Users.Add(user);
                _context.SaveChanges();
            }
            catch (Exception ex) 
            { 
                return null;
            }

            return user;
        }
        public void DeleteUser(int id)
        {
            User user = _context.Users.Where(x => x.UserID == id).SingleOrDefault();
            user.Deleted = true;
            user.DateDeleted = DateTime.Now;

            _context.SaveChanges();
        }

        public User UpdateUser(User user)
        {
            var p = _context.Users.Include("UserRoles").Where(x => x.UserID == user.UserID).SingleOrDefault();
            if (p != null)
            {
                p.Username = user.Username;
                if (user.Password != null)
                    p.Password = user.Password;
                p.FullName = user.FullName;
                p.Enable = user.Enable;
                p.Email = user.Email;
                p.DateDeleted = user.DateDeleted;
                p.Deleted = user.Deleted;
                
                _context.SaveChanges();
            }
            return p;

        }

        public int TotalUsersCount()
        {
            return _context.Users.Where(x => x.Deleted == false).Include("UserRoles").Include("UserRoles.Role").Count();
        }

        public int TotalFilteredCount(string searchString, int roleID)
        {

            var user = _context.Users.Where(x => x.Deleted == false).Include("UserRoles").Include("UserRoles.Role").AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
            {
                user = user.Where(s => (s.FullName.Contains(searchString) || s.Email.Contains(searchString) || s.Username.Contains(searchString)));
            }

            if (roleID > 0)
            {
                user = user.Where(s => s.UserRoles.Where(x => x.RoleID == roleID).SingleOrDefault().Enable);
            }
            return user.Count();

        }

        public bool CheckUserNameDisponibility(string name)
        {
            return _context.Users.Any(x => x.Username.ToLower() == name.ToLower());
        }

        public bool CheckEmailDisponibility(string email)
        {
            return _context.Users.Any(x => x.Email.ToLower() == email.ToLower());
        }

        public bool UpdatePwd(string password)
        {
            throw new NotImplementedException();
        }
    }
}

