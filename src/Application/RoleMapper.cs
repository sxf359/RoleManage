using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using Application.MenuApp.Dtos;

namespace Application
{
    /// <summary>
    /// Entity与Dto映射
    /// </summary>
    public class RoleMapper
    {
        public RoleMapper()
        {
        }
        public static void Initialize()
        {
            Mapper.Initialize(cgf =>
            {
                cgf.CreateMap<Menu, MenuDto>();
                cgf.CreateMap<MenuDto, Menu>();
            });
        }
    }
}
