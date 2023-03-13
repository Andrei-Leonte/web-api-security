using Microsoft.Azure.Functions.Worker.Http;
using System.Net;

namespace Security.Utils.Extensions
{
    public static class HttpRequestDataExtension
    {
        public static HttpResponseData CreateOkResult(this HttpRequestData httpRequestData)
        {
            return httpRequestData.CreateResponse(HttpStatusCode.OK);
        }

        public static HttpResponseData CreateInternalServerErrorResult(this HttpRequestData httpRequestData)
        {
            return httpRequestData.CreateResponse(HttpStatusCode.InternalServerError);
        }
    }
}
