using AutoMapper;
using BusinessEntity;
using DataEntity;
using System.Runtime;

namespace BookYourSavaari.Mapping
{
    public class AutoMapparRegistrestion:Profile
    {
        public AutoMapparRegistrestion()
        {

            CreateMap<UserViewModel, UserTbl>().ReverseMap();
            CreateMap<RollViewModel, RoleTbl>().ReverseMap();
        }
    }
}
