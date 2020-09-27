using Microsoft.AspNetCore.Http;
using OpenTelemetry.Trace;
using System.Diagnostics;

namespace TheMovie.Service.Trace
{
    public class TheMovieEnrichingProcessor : ActivityProcessor
    {
        public override void OnStart(Activity activity)
        {
            activity.SetTag("Start of execute", activity.DisplayName);

            // Retrieve the HttpRequest object.
            var httpRequest = activity.GetCustomProperty("OTel.AspNetCore.Request") as HttpRequest;
            if (httpRequest != null)
            {
                // Add more tags to the activity
                activity.SetTag("mycustomtag", httpRequest.Headers["myheader"]);
            }
        }

        public override void OnEnd(Activity activity)
        {
            activity.SetTag("End of execute", activity.DisplayName);

            // Retrieve the HttpResponse object.
            var httpResponse = activity.GetCustomProperty("otel.status_code") as HttpResponse;
            if (httpResponse != null)
            {
                var statusCode = httpResponse.StatusCode;
                bool success = statusCode < 400;
                // Add more tags to the activity or replace an existing tag.
                activity.SetTag("myCustomSuccess", success);
            }
        }
    }
}
