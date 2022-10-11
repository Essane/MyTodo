using MyTodo.shared;
using MyTodo.Shared.Dtos;
using MyTodo.Shared.Parameters;
using System.Threading.Tasks;

namespace MyTodo.Service
{
    public class ToDoService : BaseService<ToDoDto>, IToDoService
    {
        private readonly HttpRestClient client;

        public ToDoService(HttpRestClient client) : base(client, "ToDo")
        {
            this.client = client;
        }

        public async Task<ApiResponse<PagedList<ToDoDto>>> GetAllFilterAsync(ToDoParameter parameter)
        {
            BaseRequest request = new()
            {
                Method = RestSharp.Method.Get,
                Route = $"api/ToDo/GetAll?pageIndex={parameter.PageIndex}" +
                $"&pageSize={parameter.PageSize}" +
                $"&search={parameter.Search}" +
                $"&status={parameter.Status}"
            };
            return await client.ExecuteAsync<PagedList<ToDoDto>>(request);
        }

        public async Task<ApiResponse<SummaryDto>> SummaryAsync()
        {
            BaseRequest request = new()
            {
                Route = "api/ToDo/Summary"
            };
            return await client.ExecuteAsync<SummaryDto>(request);
        }
    }
}
