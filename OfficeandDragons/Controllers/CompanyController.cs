using Microsoft.AspNetCore.Mvc;
using OfficeandDragons.Contracts;
using OfficeandDragons.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace OfficeandDragons.Controllers
{
    [Route("api/OfficeandDragons/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> Get(int id)
        {
            var company = await _companyService.GetByIdAsync(id);

            if (company == null) return NotFound();
            return Ok();
        }

        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<Company>>> GetAll()
        {
            IEnumerable<Company> companies;
           companies = await _companyService.GetAllForAdminAsync();

            return Ok(companies.ToList());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existingItem = await _companyService.GetByIdAsync(id);

            if (existingItem == null) return NotFound();

            await _companyService.DeleteAsync(id);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Company>> Post(Company company)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _companyService.AddAsync(company);
            return CreatedAtAction(nameof(Get), new { id = company.Id },company);
        }

        [HttpPost("addrange")]
        public async Task<IActionResult> AddRange(Company[] companies)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _companyService.AddRangeAsync(companies);
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Ok();
        }

        [HttpPatch]
        public async Task<IActionResult> Patch(Company company)
        {
            var companyToUpdate = await _companyService.GetByIdAsync(company.Id);
            if (companyToUpdate == null) return NotFound();
            await _companyService.UpdateAsync(company);
            return Ok();
        }
    }
}