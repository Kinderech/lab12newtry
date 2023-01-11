using lab12newtry.Data;
using lab12newtry.Models.Domain;
using lab12newtry.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab12newtry.Pages.Nurses;

public class Edit : PageModel
{
    private readonly Lab12DbContext dbContext;
    [BindProperty]
    public EditNurseViewModel ViewModel { get; set; }
    
    public Edit(Lab12DbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public void OnGet(Guid id)
    {
        var nurse = dbContext.Nurses.Find(id);
        if (nurse != null)
        {
            //Convert Domain Model to View Model
            ViewModel = new EditNurseViewModel()
            {
                Id = nurse.Id,
                Name = nurse.Name,
                DateOfBirth = nurse.DateOfBirth,
            };
        }
    }
    
    public void OnPostUpdate(Guid id)
    {
        if (ViewModel != null && id != null)
        {
            var existingNurse = dbContext.Nurses.Find(id);
            if (existingNurse != null)
            {
                existingNurse.Name = ViewModel.Name;
                existingNurse.DateOfBirth = ViewModel.DateOfBirth;
                dbContext.Update(existingNurse);
                dbContext.SaveChanges();
            }
        }
    }

    public void OnPostDelete(Guid id)
    {
        if (id != null)
        {
            var existingNurse = dbContext.Nurses.Find(id);
            if (existingNurse != null)
            {
                dbContext.Remove(existingNurse);
                dbContext.SaveChanges();
            }
        }

    }
}