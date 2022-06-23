using System.Collections.Generic;

namespace Kozmos.WebAPI.Data.Model
{
    public class CustomerMessage
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public bool IsResolved { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
        public string? ApplicationUserId { get; set; }
    }
}
