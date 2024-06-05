namespace Sales_Web_MVC.Models.ViewModels
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public string Message { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
