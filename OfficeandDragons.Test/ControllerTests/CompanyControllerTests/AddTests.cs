using Microsoft.AspNetCore.Mvc;
using Moq;
using OfficeandDragons.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace OfficeandDragons.Tests.ControllerTests.CompanyControllerTests
{
    public class AddTests : CompanyControllerTestsBase
    {
        public AddTests() : base(new List<Company>())
        {
        }

        [Fact]
        public async Task Add_CompanyWithoutName_ReturnsBadRequest()
        {
            var nameMissingItem = new Company()
            {
                Description = "Description 1"
            };
            ControllerUnderTest.ModelState.AddModelError("Name", "Required");

            var badResponse = await ControllerUnderTest.Post(nameMissingItem);

            Assert.IsType<BadRequestObjectResult>(badResponse.Result);
        }

        [Fact]
        public async Task Add_ValidCompany_ReturnedResponseHasCreatedItem()
        {
            var company = new Company()
            {
                Name = "Company 1",
                Description = "Description 1"
            };

            var createdResponse = await ControllerUnderTest.Post(company);
            var companyDto = (createdResponse.Result as CreatedAtActionResult).Value as Company;

            Assert.IsType<Company>(companyDto);
            Assert.Equal("Company 1", companyDto.Name);
            Assert.Equal("Description 1", companyDto.Description);
        }

        [Fact]
        public async Task Add_ValidCompany_ReturnsCreatedResponse()
        {

            var company = new Company()
            {
                Name = "Company 3",
                Description = "Description 1"
            };

            var createdResponse = await ControllerUnderTest.Post(company);

            Assert.IsType<CreatedAtActionResult>(createdResponse.Result);
        }

        [Fact]
        public async Task AddRange_CompanyWithoutName_ReturnsBadRequest()
        {
            var nameMissingItem = new Company()
            {
                Description = "Description 1"
            };
            ControllerUnderTest.ModelState.AddModelError("Name", "Required");

            var badResponse = await ControllerUnderTest.AddRange(new[] { nameMissingItem });

            Assert.IsType<BadRequestObjectResult>(badResponse);
        }

        [Fact]
        public async Task AddRange_ValidCompanies_ReturnsOkOkResult()
        {
            var nameMissingItem = new Company()
            {
                Description = "Description 1"
            };

            var createdResponse = await ControllerUnderTest.AddRange(new[] { nameMissingItem });

            Assert.IsType<OkResult>(createdResponse);
        }
    }
}