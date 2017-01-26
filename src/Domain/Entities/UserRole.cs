using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserRole
    {
        public long UserId { get; set; }
        public User user { get; set; }

        public long RoleId { get; set; }
        public Role Role { get; set; }
    }
}
