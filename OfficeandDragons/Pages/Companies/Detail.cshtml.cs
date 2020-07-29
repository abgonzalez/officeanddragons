using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OfficeandDragons.Data;
using OfficeandDragons.Contracts;


namespace OfficeandDragons.Pages.Companies
{
    public class DetailModel : PageModel
    {
        private readonly ICompanyService companyData;

        [TempData]
        public string Message { get; set; }

        public Company Company { get; set; }

        public DetailModel(ICompanyService companyData)
        {
            this.companyData = companyData;
        }

        public IActionResult OnGet(int companyId)
        {
            Company = companyData.GetById(companyId);
            if(Company == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}