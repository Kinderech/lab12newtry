using lab12newtry.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab12newtry.Pages.Pations;

public class List : PageModel
{
    private Lab12DbContext dbContext;
    public List<Models.Domain.Pation> Pations { get; set; }
    public List(Lab12DbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public void OnGet()
    {
        Pations = dbContext.Pations.ToList();
    }
}