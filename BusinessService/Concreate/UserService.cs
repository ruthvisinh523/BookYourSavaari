using AutoMapper;
using BusinessEntity;
using BusinessService.Interface;
using Comman;
using DataEntity;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessService.Concreate
{
    public class UserService: IUserService
    {
        private IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public List<UserViewModel> GetUsers()
        {
            var d = _userRepository.GetUsers();
            return _mapper.Map<List<UserViewModel>>(d);
        }

		
	

		public UserViewModel GetUsers(int id)
        {
            var d = _userRepository.GetUser(id);

            return _mapper.Map<UserViewModel>(d);
        }

		public bool Registeration(UserViewModel userViewModel)
		{
			var p = _mapper.Map<UserTbl>(userViewModel);
			var salt = Helper.GeneratePassword(7);



			p.PasswordSult = salt;
			p.PasswordHash = Helper.EncodePassword(userViewModel.Password, salt);
			//p.RoleId = 1;
			return _userRepository.AddEditUser(p);

		}

		public UserViewModel CheckLogin(string username, string password, out bool isSuc)
		{
			var p = _userRepository.CheckLogin(username, password, out isSuc);
			return _mapper.Map<UserViewModel>(p);
		}
	}
}
