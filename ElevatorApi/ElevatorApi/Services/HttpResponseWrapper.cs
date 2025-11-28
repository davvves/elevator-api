using ElevatorApi.Services.Interface;

namespace ElevatorApi.Services
{
    public class HttpResponseWrapper(IHttpContextAccessor httpContextAccessor) : IHttpResponseWrapper
    {
        private readonly IHttpContextAccessor httpContextAccessor = httpContextAccessor;

        /// <summary>
        /// Get the current HttpResponse object
        /// </summary>
        /// <returns>The current HttpResponse object</returns>
        public HttpResponse? GetCurrentResponse()
        {
            return httpContextAccessor?.HttpContext?.Response;
        }
    }
}
