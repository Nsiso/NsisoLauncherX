using System.Net;

namespace NsisoLauncherX.Core.Net;

public class RequestResult<TContent>(RequestStatus status)
{
    /// <summary>
    /// indicate the request is success or not.
    /// </summary>
    public bool IsSuccess => (Status == RequestStatus.Success);
 
    /// <summary>
    /// The request's status
    /// </summary>
    public RequestStatus Status { get; set; } = status;
    
    /// <summary>
    /// the request respond http status code
    /// </summary>
    public HttpStatusCode? HttpReturnStatusCode { get; set; }

    /// <summary>
    /// When the request is in error, this show the error message.
    /// </summary>
    public string? ErrorMessage { get; set; } = null;

    /// <summary>
    /// The exception when sending request or dealing with the data.
    /// </summary>
    public Exception? InnerException { get; set; } = null;

    /// <summary>
    /// The request url 
    /// </summary>
    public string? RequestUrl { get; set; } = null;
    
    /// <summary>
    /// The result content with assign T.
    /// </summary>
    public TContent? Content { get; set; }
    
    /// <summary>
    /// factory method for building a success request result instance
    /// </summary>
    /// <param name="response">Http client returned HttpResponseMessage instance</param>
    /// <param name="content">The request target object</param>
    /// <returns>Success RequestResult instance</returns>
    public static RequestResult<TContent> Success(HttpResponseMessage response, TContent? content)
    {
        return new RequestResult<TContent>(RequestStatus.Success)
        {
            HttpReturnStatusCode = response.StatusCode,
            RequestUrl = response.RequestMessage?.RequestUri?.AbsoluteUri,
            Content = content,
        };
    }
    
    /// <summary>
    /// factory method for building a error request result instance
    /// </summary>
    /// <param name="response">Http client returned HttpResponseMessage instance</param>
    /// <returns>Error RequestResult instance</returns>
    public static RequestResult<TContent> Error(HttpResponseMessage response)
    {
        return new RequestResult<TContent>(RequestStatus.HttpError)
        {
            HttpReturnStatusCode = response.StatusCode,
            RequestUrl = response.RequestMessage?.RequestUri?.AbsoluteUri,
            ErrorMessage = response.ReasonPhrase,
        };
    }
    
    /// <summary>
    /// factory method for building a exception request result instance
    /// </summary>
    /// <param name="exception">the caught exception</param>
    /// <param name="requestUri">Http client request uri(url) string</param>
    /// <param name="isCancellationRequested">Is any cancellation requested</param>
    /// <returns></returns>
    public static RequestResult<TContent> Exception(Exception exception, string requestUri, bool isCancellationRequested)
    {
        return exception switch
        {
            HttpRequestException httpRequestException => new RequestResult<TContent>(RequestStatus.HttpRequestException)
            {
                RequestUrl = requestUri,
                ErrorMessage = httpRequestException.Message,
                InnerException = httpRequestException,
            },
            TaskCanceledException taskCanceledException when isCancellationRequested => new RequestResult<TContent>(RequestStatus.Cancelled)
                {
                    RequestUrl = requestUri,
                    ErrorMessage = taskCanceledException.Message,
                    InnerException = taskCanceledException,
                },
            TaskCanceledException taskCanceledException => new RequestResult<TContent>(RequestStatus.Timeout)
            {
                RequestUrl = requestUri,
                ErrorMessage = taskCanceledException.Message,
                InnerException = taskCanceledException,
            },
            _ => new RequestResult<TContent>(RequestStatus.UnknownException)
            {
                RequestUrl = requestUri,
                ErrorMessage = exception.Message,
                InnerException = exception,
            }
        };
    }
}

public enum RequestStatus
{
    /// <summary>
    /// OK.
    /// </summary>
    Success,
    
    /// <summary>
    /// may raise by TaskCanceledException: The request failed due to timeout.
    /// </summary>
    Timeout,
    
    /// <summary>
    /// may raise by TaskCanceledException: due to manual trigger CancellationToken.
    /// </summary>
    Cancelled,
    
    /// <summary>
    /// Http status code return 400 (client) or 500 (server) error.
    /// </summary>
    HttpError,
    
    /// <summary>
    /// The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.
    /// </summary>
    HttpRequestException,
    
    /// <summary>
    /// Other unknown exception
    /// </summary>
    UnknownException
}