using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Department:Entity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Manager { get; set; }
        public string ContactNumber { get; set; }
        public string Remarks { get; set; }
        public long ParentId { get; set; }
        public long CreatedUserId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public int IsDeleted { get; set; }
        public virtual ICollection<User> Users { get; set; }//包含用户

    }
}
