using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using Clinic.Domain.Model;

namespace Clinic.DAL.Concrete
{
    public class UserRepository : EFGenericRepository<ClinicDbContext, User>
    {
        public UserRepository(ClinicDbContext context) : base(context)
        {
        }

        public bool CheckMenuAccess(Guid menuGuid, int userId)
        {
            return _context.UserMenus.Include(um => um.Menu).Any(um => um.UserId == userId && um.Menu.Guid == menuGuid);
        }
        public bool CheckAccessRight(Guid accessRightGuid, int userId)
        {
            return _context.UserAccessRights.Include(um => um.AccessRight).Any(uar => uar.UserId == userId && uar.AccessRight.Guid == accessRightGuid);
        }

        public User LogIn(string login,string password)
        {
            var pwdhash = GetHash(password);
            return _context.Users.First(u => u.Login == login && u.PasswordHash.SequenceEqual(pwdhash));
        }

        public bool Register(User user,string password)
        {
            if (_context.Users.Any(u => u.Login == user.Login))
                return false;
            user.PasswordHash = GetHash(password);
            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }
        private byte[] GetHash(string password)
        {
            var md5 = System.Security.Cryptography.MD5.Create();
            return md5.ComputeHash(Encoding.ASCII.GetBytes(password));
        }

        public List<string> GetMenuNames(int userId)
        {
           return _context.UserMenus.Include(um => um.Menu).Where(um => um.UserId == userId).Select(um => um.Menu.Name).ToList();
        }
        //public User GetUserWithMenuAndAccessRights(int id)
        //{
        //    var menus =  _context.UserMenus.AsNoTracking().Include(u => u.Menu).Where(um=>um.UserId==id).ToList();
        //    var rights = _context.UserAccessRights.AsNoTracking().Include(u => u.AccessRight).Where(ua=>ua.UserId==id).ToList();
        //    var user = _context.Users.AsNoTracking().First(u=>u.Id==id);
        //    user.UserAccessRight = rights;
        //    user.UserMenus = menus;
        //}
    }
}

