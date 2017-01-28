using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Application.MenuApp.Dtos
{
    public class MenuDto
    {
        public long Id { get; set; }

        /// <summary>
        /// 父类ID
        /// </summary>
        public long ParentId { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public int SerialNumber { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        [Required(ErrorMessage="功能名称不能为空")]
        public string Name { get; set; }

        /// <summary>
        /// 菜单编号
        /// </summary>
        public string Code { set; get; }
        /// <summary>
        /// 菜单地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 类型： 0 导航菜单  1：操作按钮
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 菜单图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 菜单备注
        /// </summary>
        public string Remarks { get; set; }
    }
}
