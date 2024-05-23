using Shared_Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Shared_Library.Model.ServiceResponses;

namespace Shared_Library.Service.Auth
{
    public interface IUserAccount
    {
        Task<GeneralResponse> CreateAccount(UserDTO userDTO);
        Task<LoginResponse> LoginAccount(LoginDTO loginDTO);
    }
}
