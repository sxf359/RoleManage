using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Menu:Entity
    {
        public long ParentId { get; set; }
        public int SerialNumber { get; set; }//序号
        public string Name { get; set; }
        public string Code { get; set; }
        public string Url { get; set; }
        public int Type { get; set; }//类型：0导航菜单   1操作按钮
        public string Icon { get; set; }
        public string Remarks { get; set; }
    }
}
