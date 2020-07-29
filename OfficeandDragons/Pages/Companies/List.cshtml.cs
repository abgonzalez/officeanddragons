using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OfficeandDragons.Data;
using OfficeandDragons.Contracts;

namespace OfficeandDragons.Pages.Companies
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly ICompanyService companyData;
        private readonly ILogger<ListModel> logger;

        public IEnumerable<Company> Companies { get; set; }


        public ListModel(IConfiguration config,
                         ICompanyService companyData,
                         ILogger<ListModel> logger)
        {
            this.config = config;
            this.companyData = companyData;
            this.logger = logger;
        }


        public void OnGet()
        {
            logger.LogError("Executing ListModel");
            Companies = companyData.GetAll();
        }
    }
}
