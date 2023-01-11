using lab12newtry.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab12newtry.Pages.Doctors;

public class List : PageModel
{
    private Lab12DbContext dbContext;
    public List<Models.Domain.Doctor> Doctors { get; set; }
    public List(Lab12DbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public void OnGet()
    {
        Doctors = dbContext.Doctors.ToList();
    }
}