using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using Clinic.Domain.Model;

namespace Clinic.DAL
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
    }
}
