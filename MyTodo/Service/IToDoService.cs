using MyTodo.shared;
using MyTodo.Shared.Dtos;
using MyTodo.Shared.Parameters;
using System.Threading.Tasks;

namespace MyTodo.Service
{
    public interface IToDoService : IBaseService<ToDoDto>
    {
        Task<ApiResponse<PagedList<ToDoDto>>> GetAllFilterAsync(ToDoParameter parameter);

        Task<ApiResponse<SummaryDto>> SummaryAsync();
    }
}
