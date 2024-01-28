using RealEstate.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Core.Services.Interface
{
    public interface IUserService
    {
        string RegisterUser(RegisterDTO request);
        ResponseDTO<UserDTO> Authenticate(string email, string password);
    }
}
