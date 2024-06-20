using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class UserViewModel
    {
        public int UserId { get; set; }

        public string Name { get; set; } = null!;

		public string Password { get; set; } = null!;

		public string ConfirmPasword { get; set; } = null!;
		public string Email { get; set; } = null!;

        public string Gender { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;
        public string Age { get; set; } = null!;

        public bool IsActive { get; set; }
    }
}
