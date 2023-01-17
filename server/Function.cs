using Google.Cloud.Functions.Framework;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Benchmarking.Server;

public class Function : IHttpFunction
{
    /// <summary>
    /// Delay an HTTP Response
    /// </summary>
    /// <param name="context">The HTTP context, containing the request and the response.</param>
    public async Task HandleAsync(HttpContext context)
    {
        var delay = Convert.ToInt32(context.Request.Query["delay_mls"]);
        await Task.Delay(delay);
        context.Response.StatusCode = StatusCodes.Status200OK;
        await Task.CompletedTask;
    }
}
