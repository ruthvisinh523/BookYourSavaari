using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntity;


namespace Repository.Interface
{
    public interface IUserRepository
    {
        bool AddEditUser(UserTbl user);

        bool DeleteUser(int id);

        UserTbl GetUser(int id);
        List<UserTbl> GetUsers();


		UserTbl CheckLogin(string Email, String Password, out bool isSuc);


	}
}
