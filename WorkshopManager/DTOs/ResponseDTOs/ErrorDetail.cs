namespace WorkshopManager.Api.DTOs.ResponseDTOs;

public class ErrorDetail
{
    public string Message { get; set; }
    public string? Code { get; set; }
    public string? Target { get; set; }
}
