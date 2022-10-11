using MyTodo.shared;
using MyTodo.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTodo.Service
{
    public interface ILoginService
    {
        Task<ApiResponse<UserDto>> Login(UserDto user);

        Task<ApiResponse> Resgiter(UserDto user);
    }
}
