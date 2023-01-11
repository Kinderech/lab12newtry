using lab12newtry.Data;
using lab12newtry.Models.Domain;
using lab12newtry.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab12newtry.Pages.Doctors;

public class Add : PageModel
{

    private Lab12DbContext dbContext;
    public Add(Lab12DbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [BindProperty]
    public AddDoctorViewModel ViewModel { get; set; }


    public void OnPost()
    {
        //Convert ViewModel to DomainModel
        var pationDomainModel = new Doctor()
        {
            Name = ViewModel.Name,
            DateOfBirth = ViewModel.DateOfBirth
        };
        dbContext.Doctors.Add(pationDomainModel);
        dbContext.SaveChanges();

    }
    
}