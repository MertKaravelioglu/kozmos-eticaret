using Kozmos.WebAPI.Data.Model;

namespace Kozmos.WebAPI.Data.ViewModels
{
    public class ResponseViewModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public TokenInfo TokenInfo { get; set; }
    }
}
