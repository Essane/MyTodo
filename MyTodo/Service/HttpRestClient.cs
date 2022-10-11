using MyTodo.shared;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace MyTodo.Service
{
    public class HttpRestClient
    {
        protected readonly RestClient client;
        public HttpRestClient(string apiUrl)
        {
            client = new RestClient(apiUrl);
        }

        public async Task<ApiResponse> ExecuteAsync(BaseRequest baseRequest)
        {
            var request = new RestRequest(baseRequest.Route, baseRequest.Method);
            if (baseRequest.Parameter != null)
                request.AddStringBody(JsonConvert.SerializeObject(baseRequest.Parameter), baseRequest.ContentType);
            var response = await client.ExecuteAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<ApiResponse>(response.Content);
            else
                return new ApiResponse()
                {
                    Status = false,
                    Result = null,
                    Message = response.ErrorMessage
                };
        }

        public async Task<ApiResponse<T>> ExecuteAsync<T>(BaseRequest baseRequest)
        {
            var request = new RestRequest(baseRequest.Route, baseRequest.Method);
            if (baseRequest.Parameter != null)
                request.AddStringBody(JsonConvert.SerializeObject(baseRequest.Parameter),baseRequest.ContentType);
            var response = await client.ExecuteAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<ApiResponse<T>>(response.Content);
            else
                return new ApiResponse<T>()
                {
                    Status = false,
                    Message = response.ErrorMessage
                };
        }
    }
}
