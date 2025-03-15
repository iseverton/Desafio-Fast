using System.Net;

namespace WorkshopManager.Api.DTOs.ResponseDTOs;

public class ResponseDTO<T>
{
    public T? Data { get; set; }
    public List<ErrorDetail>? Errors { get; set; }
    public bool IsSucceeded { get; set; }
    public HttpStatusCode StatusCode { get; set; }

    public static ResponseDTO<T> Success(T data,HttpStatusCode httpStatusCode) 
    { 
        return new ResponseDTO<T>
        {
            Data = data,
            IsSucceeded = true,
            StatusCode = httpStatusCode
        };
    }
    public static ResponseDTO<T> Success( HttpStatusCode httpStatusCode)
    {
        return new ResponseDTO<T>
        {
            Data = default,
            IsSucceeded = true,
            StatusCode = httpStatusCode
        };
    }

    public static ResponseDTO<T> Fail(List<ErrorDetail> errors, HttpStatusCode httpStatusCode)
    {
        return new ResponseDTO<T>
        {
            Data = default,
            Errors = errors,
            StatusCode = httpStatusCode,
            IsSucceeded = false
        };
    }

    public static ResponseDTO<T> Fail(string error, HttpStatusCode httpStatusCode)
    {
        return new ResponseDTO<T>
        {
            Data = default,
            Errors = new List<ErrorDetail> { new ErrorDetail { Message = error } },
            StatusCode = httpStatusCode,
            IsSucceeded = false
        };
    }




}
