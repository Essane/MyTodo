using MyTodo.shared;
using MyTodo.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTodo.Service
{
    public class LoginService : ILoginService
    {
        private readonly HttpRestClient client;
        private readonly string serviceName = "Login";

        public LoginService(HttpRestClient client)
        {
            this.client = client;
        }

        public async Task<ApiResponse<UserDto>> Login(UserDto user)
        {
            BaseRequest request = new()
            {
                Method = RestSharp.Method.Post,
                Route = $"api/{serviceName}/Login",
                Parameter = user
            };
            return await client.ExecuteAsync<UserDto>(request);
        }

        public async Task<ApiResponse> Resgiter(UserDto user)
        {
            BaseRequest request = new()
            {
                Method = RestSharp.Method.Post,
                Route = $"api/{serviceName}/Resgiter",
                Parameter = user
            };
            return await client.ExecuteAsync(request);
        }
    }
}
