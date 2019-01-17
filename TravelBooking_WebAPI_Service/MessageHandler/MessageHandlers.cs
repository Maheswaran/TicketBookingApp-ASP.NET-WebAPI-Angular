using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace TravelBooking_WebAPI_Service
{
    public class MessageHandlerForGlobalRoute : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
           HttpResponseMessage response = await base.SendAsync(request, cancellationToken);
           response.Headers.Add("RequestTime", DateTime.Now.ToLongDateString());
           return response;
        }
    }
    public class MessageHandlerForUserController : DelegatingHandler
    {
        private static long count = 1;

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);
            response.Headers.Add("RequestCount", (count+=1).ToString());
            return response;
        }
    }
}