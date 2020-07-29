using Moq;
using OfficeandDragons.Contracts;
using OfficeandDragons.Controllers;
using OfficeandDragons.Data;
using System.Collections.Generic;

namespace OfficeandDragons.Tests.ControllerTests.CompanyControllerTests
{
    public abstract class CompanyControllerTestsBase
    {
        protected readonly List<Company> Companies;
        protected readonly Mock<ICompanyService> _service;
           protected readonly CompanyController ControllerUnderTest;

        protected CompanyControllerTestsBase(List<Company> companies)
        {
            Companies = companies;
            _service = new Mock<ICompanyService>();
            _service.Setup(svc => svc.GetAllForAdminAsync())
                .ReturnsAsync(Companies);
              ControllerUnderTest = new CompanyController(_service.Object);
        }
    }
}