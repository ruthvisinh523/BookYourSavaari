using DataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IRoleRepository
    {
        bool AddEditRoll(RoleTbl role);

        bool DeleteRoll(int id);

        List<RoleTbl> GetRoles();

        RoleTbl GetRoles(int id);
    }
}
