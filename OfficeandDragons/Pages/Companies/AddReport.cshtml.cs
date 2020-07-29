using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OfficeandDragons.Contracts;
using OfficeandDragons.Data;

namespace OfficeandDragons.Pages.Companies
{
    public class AddReportModel : PageModel
    {
        private readonly ICompanyService companyData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Company Company { get; set; }
        public AddReportModel(ICompanyService CompanyData,
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
            if (Company == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
        public IActionResult OnPost(List<IFormFile>  files)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            List<string> updatedReports = new List<string>();
            for ( int i=0; i<files.Count(); i++)
            {
                var fileName = files[i].FileName;
                //  Company.Reports.Append<string>(s.ToString());
            //    Company.Reports = new string[0] { s };
                if (updatedReports.Contains(fileName)) continue;
                updatedReports.Add(fileName);
            }
            Company.Reports = updatedReports.ToArray();
            //if (Company.Reports == null)
            //{
            //   // Company.Reports = new string[1] { fileName };
            //    for (int i = 0; i < files.Count(); i++)
            //    {
            //        var s = files[i].FileName;
            //        //  Company.Reports.Append<string>(s.ToString());
            //        Company.Reports = new string[i+1] { s };
            //    }
            //}
            //else
            //{
            //    var reports = Company.Reports.ToList();
            //    if (reports.Contains(fileName)) return;
            //    reports.Add(fileName);
            //    Company.Reports = reports.ToArray();
            //}

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
