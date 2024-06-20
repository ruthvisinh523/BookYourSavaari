using BusinessService.Concreate;
using BusinessService.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessService
{


    public static class ServiceDependancy
    {
        public static void Registration(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUserService, UserService>();
            serviceCollection.AddScoped<IRoleService, RoleService>();
        }
    }

}
