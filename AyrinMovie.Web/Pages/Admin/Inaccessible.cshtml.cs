using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AyrinMovie.Web.Pages.Admin
{
    [Authorize]
    public class InaccessibleModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
