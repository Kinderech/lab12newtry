using lab12newtry.Data;
using lab12newtry.Models.Domain;
using lab12newtry.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab12newtry.Pages.Pations;

public class Add : PageModel
{

    private Lab12DbContext dbContext;
    public Add(Lab12DbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [BindProperty]
    public AddPationViewModel AddPationRequest { get; set; }


    public void OnPost()
    {
        //Convert ViewModel to DomainModel
        var pationDomainModel = new Pation
        {
            Name = AddPationRequest.Name,
            Doctor = AddPationRequest.Doctor,
            DateOfBirth = AddPationRequest.DateOfBirth
        };
        dbContext.Pations.Add(pationDomainModel);
        dbContext.SaveChanges();

    }
    
}