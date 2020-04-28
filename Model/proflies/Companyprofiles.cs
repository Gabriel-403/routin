using AutoMapper;
using routin.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace routin.Model.proflies
{
    public class Companyprofiles:Profile
    {
        public Companyprofiles()
        {
            CreateMap<Company, CompanyDto>().ForMember(dest=>dest.ExterName,
                opt=>opt.MapFrom(src=>src.Name));
        }
    }
}
