using Microsoft.AspNetCore.Mvc;
using OfficeandDragons.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace OfficeandDragons.Tests.ControllerTests.CompanyControllerTests
{
    public class DeleteTests : CompanyControllerTestsBase
    {
        public DeleteTests() : base(new List<Company>() { })
        {
        }

        [Fact]
        public void Delete_UnknownCompanyId_ReturnsNotFoundResult()
        {
            var notFoundResult = ControllerUnderTest.Delete(100);
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }

        [Fact]
        public void Delete_ExistingCompanyId_ReturnsOkResult()
        {
            _service.Setup(s => s.GetByIdAsync(1)).Returns(() => Task.FromResult(new Company() { Id = 1, Name = "Company1" }));
            var OkResult = ControllerUnderTest.Delete(1);
            Assert.IsType<OkResult>(OkResult.Result);
        }
    }
}