using RealEstate.DTO;
using RealEstate.DTO.RealEstate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Core.Services.Interface
{

    public interface IRealEstateService
    {
        IEnumerable<RealestateDTO> GetAllRealEstates(); // we can add pagination for list
        ResponseDTO<RealestateDTO> GetRealEstateById(int id);
        ResponseDTO<RealestateDTO> CreateRealEstate(CreateRealestateDTO request);
        ResponseDTO<RealestateDTO> UpdateRealEstate(int id, UpdateRealestateDTO request);
        ResponseDTO<RealestateDTO> DeleteRealEstate(int id);
    }
}
