namespace Kozmos.WebAPI.Data.ViewModels
{
    public class CustomerMessageGetVM
    {
        
        public string Title { get; set; }
        public string Text { get; set; }
        public bool IsResolved { get; set; }        
        public string ApplicationUserFullName { get; set; }
        public string ApplicationUserEmail { get; set; }
    }

    public class CustomerMessageAddVM
    {
       
        public string Title { get; set; }
        public string Text { get; set; }
       
    }
}
