namespace LibraryManagementSystem.Models.ViewModels;

public class ErrorViewModel
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    
    public string? ExceptionMessage { get; set; }
    
    public bool ShowExceptionMessage => !string.IsNullOrEmpty(ExceptionMessage);
    
    public int? StatusCode { get; set; }
}