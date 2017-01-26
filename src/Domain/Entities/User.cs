using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User:Entity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string EMail { get; set; }
        public string MobileNumber { get; set; }
        public string Remarks { get; set; }
        public Guid CreatedUserId { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime LastLoginTime { get; set; }
        public int LoginTimes { get; set; }
        public long DepartmentId { get; set; }
        public int IsDeleted { get; set; }
        public virtual Department Department { get; set; }//所属部门实体
        public virtual ICollection<UserRole> UserRoles { get; set; }//角色集合

    }
}
