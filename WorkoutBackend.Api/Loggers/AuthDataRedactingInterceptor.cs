using Microsoft.AspNetCore.HttpLogging;

namespace WorkoutBackend.Api.Loggers;

/// <summary>
/// Used to redact the body for authentication requests in order to protect
/// User login/auth data from being logged.
/// </summary>
public class AuthDataRedactingInterceptor : IHttpLoggingInterceptor
{
    public ValueTask OnRequestAsync(HttpLoggingInterceptorContext logContext)
    {
        var request = logContext.HttpContext.Request;

        if (request.Path.StartsWithSegments("/api/authentication"))
        {
            if(logContext.TryDisable(HttpLoggingFields.RequestBody))
            {
                RedactRequestBody(logContext);
            }
        }
        return ValueTask.CompletedTask;
    }

    public ValueTask OnResponseAsync(HttpLoggingInterceptorContext logContext)
    {
        return ValueTask.CompletedTask;
    }

    private static void RedactRequestBody(HttpLoggingInterceptorContext logContext)
    {
        logContext.AddParameter(nameof(logContext.HttpContext.Request.Body), "[Redacted Body]");
    }
}
