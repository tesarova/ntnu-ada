namespace MyFirstWebApp.Pages
{
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Extensions.Logging;

    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private const string InitialMessage = "Initial message";

        public string Message
        {
            get;
            set;
        }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            Message = InitialMessage;
        }

        public void OnGet()
        {
        }

        public void OnPostDelete()
        {
            Message = null;
        }

        public void OnPostClick()
        {
            Message = "Clicked";
        }

        public void OnPostEdit(string newMessage)
        {
            Message = newMessage;
        }
    }
}