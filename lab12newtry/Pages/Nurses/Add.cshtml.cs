using lab12newtry.Data;
using lab12newtry.Models.Domain;
using lab12newtry.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab12newtry.Pages.Nurses;

public class Add : PageModel
{

    private Lab12DbContext dbContext;
    public Add(Lab12DbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [BindProperty]
    public AddNurseViewModel ViewModel { get; set; }


    public void OnPost()
    {
        //Convert ViewModel to DomainModel
        var pationDomainModel = new Nurse()
        {
            Name = ViewModel.Name,
            DateOfBirth = ViewModel.DateOfBirth
        };
        dbContext.Nurses.Add(pationDomainModel);
        dbContext.SaveChanges();

    }
    
}