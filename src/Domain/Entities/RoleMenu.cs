using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class RoleMenu
    {
        public long RoleId { get; set; }
        public Role Role { get; set; }

        public long MenuId { get; set; }
        public Menu Menu { get; set; }
    }
}
