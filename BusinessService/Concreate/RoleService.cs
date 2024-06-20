using AutoMapper;
using BusinessEntity;
using BusinessService.Interface;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessService.Concreate
{
    public class RoleService : IRoleService
    {


        private IRoleRepository _roleRepository;

        private readonly IMapper _mapper;


        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public List<RollViewModel> GetRolls()
        {
            var d = _roleRepository.GetRoles();
            return _mapper.Map<List<RollViewModel>>(d);
        }

    }
}
