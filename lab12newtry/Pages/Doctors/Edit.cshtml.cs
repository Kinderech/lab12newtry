using lab12newtry.Data;
using lab12newtry.Models.Domain;
using lab12newtry.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab12newtry.Pages.Doctors;

public class Edit : PageModel
{
    private readonly Lab12DbContext dbContext;
    [BindProperty]
    public EditDoctorViewModel ViewModel { get; set; }
    
    public Edit(Lab12DbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public void OnGet(Guid id)
    {
        var pation = dbContext.Doctors.Find(id);
        if (pation != null)
        {
            //Convert Domain Model to View Model
            ViewModel = new EditDoctorViewModel()
            {
                Id = pation.Id,
                Name = pation.Name,
                DateOfBirth = pation.DateOfBirth,
            };
        }
    }
    
    public void OnPostUpdate(Guid id)
    {
        if (ViewModel != null && id != null)
        {
            var existingDoctor = dbContext.Doctors.Find(id);
            if (existingDoctor != null)
            {
                existingDoctor.Name = ViewModel.Name;
                existingDoctor.DateOfBirth = ViewModel.DateOfBirth;
                dbContext.Update(existingDoctor);
                dbContext.SaveChanges();
            }
        }
    }
    public void OnPostDelete(Guid id)
    {
        if (id != null)
        {
            var existingDoctor = dbContext.Doctors.Find(id);
            if (existingDoctor != null)
            {
                dbContext.Remove(existingDoctor);
                dbContext.SaveChanges();
            }
        }

    }
}