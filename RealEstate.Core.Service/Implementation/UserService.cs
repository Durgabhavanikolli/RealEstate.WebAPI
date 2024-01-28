using AutoMapper;
using Azure;
using NPOI.SS.Formula.Functions;
using RealEstate.Core.Model;
using RealEstate.Core.Services.Helpers;
using RealEstate.DTO;
using RealEstate.DTO.RealEstate;
using RealEstate.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Core.Services.Interface
{

    public class UserService : IUserService
    {
        private readonly RealEstateDBContext _dbContext;
        private readonly IMapper _mapper;

        public UserService(RealEstateDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public ResponseDTO<UserDTO> Authenticate(string email, string password)
        {
            string message = "";
            var user = _dbContext.Users.FirstOrDefault(x => x.Email == email && x.IsActive==true);
            if (user == null)
            {
                message = "Not found : Please enter valid username";
                return new ResponseDTO<UserDTO>(false, message,null);
            }
            if (!PasswordHasher.VerifyPassword(password, user.Password))
            {               
                message = "Please enter valid password";
                return new ResponseDTO<UserDTO>(false, message, null);
            }
            var result = _mapper.Map<User, UserDTO>(user);
            return new ResponseDTO<UserDTO>(true, message, result);
        }
        public string RegisterUser(RegisterDTO request)
        {

            var register = _mapper.Map<RegisterDTO, User>(request);
            register.Password = PasswordHasher.HashPassword(request.Password);
            var result = _dbContext.Users.Add(register);
            try
            {
                _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                return null;
            }
            return "Register successful";
        }


    }
}
