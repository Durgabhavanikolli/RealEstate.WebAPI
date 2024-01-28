using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RealEstate.Core.Model;
using RealEstate.DTO;
using RealEstate.DTO.RealEstate;

namespace RealEstate.Core.Services.Helpers
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<RealEstateDetail, RealestateDTO>();
            CreateMap<CreateRealestateDTO, RealEstateDetail>();
            CreateMap<RegisterDTO, User>();
            CreateMap<User, UserDTO>();
        }
    }
}
