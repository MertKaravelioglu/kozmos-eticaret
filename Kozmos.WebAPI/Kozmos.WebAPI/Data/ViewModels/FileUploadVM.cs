namespace Kozmos.WebAPI.Data.ViewModels
{
    public class FileUploadVM
    {
        public FileUploadVM(string message, bool success)
        {
            Message = message;
            Success = success;
        }

        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
