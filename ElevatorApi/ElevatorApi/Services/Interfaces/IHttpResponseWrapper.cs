namespace ElevatorApi.Services.Interface
{
    public interface IHttpResponseWrapper
    {
        /// <summary>
        /// Get the current HttpResponse object
        /// </summary>
        /// <returns>The current HttpResponse object</returns>
        HttpResponse? GetCurrentResponse();
    }
}
