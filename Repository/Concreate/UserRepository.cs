using Comman;
using DataEntity;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Concreate
{
    public class UserRepository : IUserRepository
    {
        private readonly BookYourSavaariDbContext _bookYourSavaariDbContext;

        public UserRepository(BookYourSavaariDbContext bookYourSavaariDbContext)
        {
            _bookYourSavaariDbContext = bookYourSavaariDbContext;
        }
        public bool AddEditUser(UserTbl user)
        {
            if (user.UserId > 0)
            {

                var p = _bookYourSavaariDbContext.UserTbls.Find(user.UserId);
                p.Name = user.Name;
               
                p.Gender = user.Gender;
                p.Age = user.Age;
                p.Email = user.Email;
                p.PhoneNumber = user.PhoneNumber;
                p.IssActive = user.IssActive;

            }
            else
            {
               _bookYourSavaariDbContext.UserTbls.Add(user);
            }

            return _bookYourSavaariDbContext.SaveChanges() > 0 ? true : false;
        }

		public UserTbl CheckLogin(string Email, string Password, out bool isSuc)
		{
			var user = _bookYourSavaariDbContext.UserTbls.FirstOrDefault(x => x.Email == Email);
			if (user != null)
			{
				var passwordhash = Helper.EncodePassword(Password, user.PasswordSult);

				if (passwordhash == user.PasswordHash)
				{
					isSuc = true;
					return user;
				}
				else
				{
					isSuc = false;
				}
			}
			else
			{
				isSuc = false;
			}

			return null;
		}

		public bool DeleteUser(int id)
        {
            var p = _bookYourSavaariDbContext.UserTbls.Find(id);
            _bookYourSavaariDbContext.Remove(p);

            return _bookYourSavaariDbContext.SaveChanges() > 0 ? true : false;

        }

        public UserTbl GetUser(int id)
        {
            var p = _bookYourSavaariDbContext.UserTbls.Find(id);

            return p;
        }

		public List<UserTbl> GetUsers()
		{

            //return _bookYourSavaariDbContext.UserTbls.Include(y => y.).ToList();

            return _bookYourSavaariDbContext.UserTbls.ToList();
		}



		
	}
}
