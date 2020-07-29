using Microsoft.AspNetCore.Mvc;
using OfficeandDragons.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace OfficeandDragons.Tests.ControllerTests.CompanyControllerTests
{
    public class UpdateTests : CompanyControllerTestsBase
    {
        public UpdateTests() : base(new List<Company>())
        {
        }

        [Fact]
        public void Update_UnknownCompanyId_ReturnsNotFoundResult()
        {
            var notFoundResult = ControllerUnderTest.Patch(new Company() { Id = 1, Name = "Company1" });
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }

        [Fact]
        public void Update_ExistingCompanyId_ReturnsOkResult()
        {
            _service.Setup(s => s.GetByIdAsync(1)).Returns(() => Task.FromResult(new Company() { Id = 1, Name = "Company1" }));
            var OkResult = ControllerUnderTest.Patch(new Company() { Id = 1, Name = "Company1" });
            Assert.IsType<OkResult>(OkResult.Result);
        }
    }
}