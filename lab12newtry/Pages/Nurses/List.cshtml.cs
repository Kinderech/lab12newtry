using lab12newtry.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab12newtry.Pages.Nurses;

public class List : PageModel
{
    private Lab12DbContext dbContext;
    public List<Models.Domain.Nurse> Nurses { get; set; }
    public List(Lab12DbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public void OnGet()
    {
        Nurses = dbContext.Nurses.ToList();
    }
}