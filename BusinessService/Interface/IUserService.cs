using BusinessEntity;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessService.Interface
{
    public interface IUserService
    {
        public List<UserViewModel> GetUsers();

        
        UserViewModel GetUsers(int id);


        bool Registeration(UserViewModel userViewModel);

		UserViewModel CheckLogin(string username, string password, out bool isSuc);


	}
}
