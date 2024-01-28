using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RealEstate.Core.Model;
using RealEstate.Core.Services.Interface;
using RealEstate.DTO;
using RealEstate.DTO.RealEstate;
using RealEstate.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Core.Services.Implementation
{
    public class RealEstateService :  IRealEstateService
    {
        private readonly RealEstateDBContext _dbContext;
        private readonly IMapper _mapper;
        public RealEstateService(RealEstateDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public IEnumerable<RealestateDTO> GetAllRealEstates()
        {
            var realEstateList = _dbContext.RealEstateDetails.Where(x=>x.IsActive==true).ToList();
            if (realEstateList == null)
            {
                return null;
            }
            var realEstateDTO = _mapper.Map<IEnumerable<RealEstateDetail>, IEnumerable<RealestateDTO>>(realEstateList);
            return realEstateDTO;
        }

        public  ResponseDTO<RealestateDTO> GetRealEstateById(int id)
        {
            var realEstateDetails = _dbContext.RealEstateDetails.FirstOrDefault(x=>x.Id==id);
            if (realEstateDetails == null)
            {
                return new ResponseDTO<RealestateDTO>(false,"NotFound: Please share the valid id",null);
            }
            var realEstateDTO = _mapper.Map<RealEstateDetail, RealestateDTO>(realEstateDetails);
            return new ResponseDTO<RealestateDTO>(true, "Get RealEstate by Id", realEstateDTO);
        }

        public ResponseDTO<RealestateDTO> CreateRealEstate(CreateRealestateDTO request)
        {
            var realEstate = _mapper.Map<CreateRealestateDTO, RealEstateDetail>(request);
            var result =  _dbContext.RealEstateDetails.Add(realEstate);
            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                return new ResponseDTO<RealestateDTO>(false, ex.Message, null);
            }
            var realEstateDTO = _mapper.Map<RealEstateDetail, RealestateDTO>(result.Entity);
            return new ResponseDTO<RealestateDTO>(true, "Created RealEstate successful!", realEstateDTO);
        }

        public ResponseDTO<RealestateDTO> UpdateRealEstate(int id, UpdateRealestateDTO request)
        {
            var existingRealEstate = _dbContext.RealEstateDetails.FirstOrDefault(r => r.Id == id);

            if (existingRealEstate != null)
            {
                existingRealEstate.Name = request.Name;
                existingRealEstate.Location = request.Location;
                existingRealEstate.City = request.City;
                existingRealEstate.NoProjectsCompleted = request.NoProjectsCompleted;
                //_dbContext.Entry(existingRealEstate).CurrentValues.SetValues(request);
                var result = _dbContext.RealEstateDetails.Update(existingRealEstate);

                try
                {
                    _dbContext.SaveChanges();
                }
                catch (Exception ex)
                {

                    return new ResponseDTO<RealestateDTO>(false, ex.Message, null);
                }
                var realEstateDTO = _mapper.Map<RealEstateDetail, RealestateDTO>(result.Entity);
                return new ResponseDTO<RealestateDTO>(true, "Updated RealEstate successful!", realEstateDTO);
            }
            else
            {
                return new ResponseDTO<RealestateDTO>(false, "Please enter valid Id", null);
            }
            
        }

        public ResponseDTO<RealestateDTO> DeleteRealEstate(int id)
        {
            var existingRealEstate = _dbContext.RealEstateDetails.FirstOrDefault(r => r.Id == id);

            if (existingRealEstate != null)
            {
                existingRealEstate.IsActive = false;
                _dbContext.RealEstateDetails.Update(existingRealEstate);
                try
                {
                    _dbContext.SaveChanges();
                    return new ResponseDTO<RealestateDTO>(true, "Deleted RealEstate successful!", null);
                }
                catch (Exception ex)
                {

                    return new ResponseDTO<RealestateDTO>(false, ex.Message, null);
                }
            }

            return new ResponseDTO<RealestateDTO>(false, "Please enter valid Id", null);
        }
    }

}
