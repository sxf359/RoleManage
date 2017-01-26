using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.UserApp.Dtos
{
    public class UserDto
    {
        public long Id { get; set; }
        public string UserName { get; set; }

        //todo:
        public List<UserRoleDto> UserRoles { get; set; }
    }
}
