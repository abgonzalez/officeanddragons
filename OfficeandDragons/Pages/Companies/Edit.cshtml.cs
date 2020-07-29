using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OfficeandDragons.Data;
using OfficeandDragons.Contracts;

namespace OfficeandDragons.Pages.Companies
{
    public class EditModel : PageModel
    {
        private readonly ICompanyService companyData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Company Company { get; set; }

        public EditModel(ICompanyService CompanyData,
                         IHtmlHelper htmlHelper)
        {
            this.companyData = CompanyData;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? CompanyId)
        {
             if (CompanyId.HasValue)
            {
                Company = companyData.GetById(CompanyId.Value);
            }
            else
            {
                Company = new Company();
            }
            if(Company == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {               
            if(!ModelState.IsValid)
            {
                return Page();                
            }

            if (Company.Id > 0)
            {
                companyData.Update(Company);
            }
            else
            {
                companyData.Add(Company);
            }
      
            return RedirectToPage("./Detail", new { CompanyId = Company.Id });
        }
    }
}