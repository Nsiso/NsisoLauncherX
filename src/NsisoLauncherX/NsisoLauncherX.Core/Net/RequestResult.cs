using System.Net;

namespace NsisoLauncherX.Core.Net;

public class RequestResult<TContent>(RequestStatus status, HttpStatusCode? code, string? errorMessage, TContent? content)
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
    /// when request sending success and get a response, it has its own http code. (like 200, 404 etc.)
    /// </summary>
    public HttpStatusCode? HttpCode { get; set; } = code;

    /// <summary>
    /// When the request is in error, this show the error message.
    /// </summary>
    public string? ErrorMessage { get; set; } = errorMessage;

    /// <summary>
    /// The exception when sending request or dealing with the data.
    /// </summary>
    public Exception? InnerException { get; set; }
    
    /// <summary>
    /// The result content with assign T.
    /// </summary>
    public TContent? Content { get; set; } = content;

    public RequestResult(TaskCanceledException ex) : this(RequestStatus.Cancelled,null, ex.Message, default(TContent?))
    {
        this.InnerException = ex;
    }
    
    public RequestResult(Exception ex) : this(RequestStatus.InnerException, null, ex.Message, default(TContent?))
    {
        this.InnerException = ex;
    }
}

public enum RequestStatus
{
    Success,
    Timeout,
    Cancelled,
    Error,
    InnerException
}