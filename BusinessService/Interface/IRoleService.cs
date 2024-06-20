using BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessService.Interface
{
    public interface IRoleService
    {
        List<RollViewModel> GetRolls();
    }
}
