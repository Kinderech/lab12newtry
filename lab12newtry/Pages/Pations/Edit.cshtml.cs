using lab12newtry.Data;
using lab12newtry.Models.Domain;
using lab12newtry.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab12newtry.Pages.Pations;

public class Edit : PageModel
{
    private readonly Lab12DbContext dbContext;
    [BindProperty]
    public EditPationViewModel EditPationViewModel { get; set; }
    
    public Edit(Lab12DbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public void OnGet(Guid id)
    {
        var pation = dbContext.Pations.Find(id);
        if (pation != null)
        {
            //Convert Domain Model to View Model
            EditPationViewModel = new EditPationViewModel()
            {
                Id = pation.Id,
                Name = pation.Name,
                DateOfBirth = pation.DateOfBirth,
                Doctor = pation.Doctor
            };
        }
    }
    
    public void OnPostUpdate(Guid id)
    {
        if (EditPationViewModel != null && id != null)
        {
            var existingPation = dbContext.Pations.Find(id);
            if (existingPation != null)
            {
                existingPation.Name = EditPationViewModel.Name;
                existingPation.Doctor = EditPationViewModel.Doctor;
                existingPation.DateOfBirth = EditPationViewModel.DateOfBirth;
                dbContext.Update(existingPation);
                dbContext.SaveChanges();
            }
        }
    }

    public void OnPostDelete(Guid id)
    {
        if (id != null)
        {
            var existingPation = dbContext.Pations.Find(id);
            if (existingPation != null)
            {
                dbContext.Remove(existingPation);
                dbContext.SaveChanges();
            }
        }
    }
}