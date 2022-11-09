using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogCrud.Pages
{
    public class SessionModel : PageModel
    {
        public void OnGet()
        {
            ViewData["message"] = "Some message";
        }

        public void OnPost(string title)
        {
            Console.WriteLine(title);

            HttpContext.Response.Cookies.Append("title", title);

        }
    }
}
