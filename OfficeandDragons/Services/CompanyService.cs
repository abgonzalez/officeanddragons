using Microsoft.EntityFrameworkCore;
using OfficeandDragons.Data;
using OfficeandDragons.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficeandDragons.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly OfficeandDragonsDbContext _dbContext;

        public CompanyService(OfficeandDragonsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Company company)
        {
             _dbContext.Companies.Add(company);
             _dbContext.SaveChanges();
        }

        public async Task AddAsync(Company company)
        {
            await _dbContext.Companies.AddAsync(company);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddReportAsync(int companyId, string fileName)
        {
            var companyToUpdate = await _dbContext.Companies.FindAsync(companyId);
            if (companyToUpdate.Reports == null)
            {
                companyToUpdate.Reports = new string[1] { fileName };
            }
            else
            {
                var reports = companyToUpdate.Reports.ToList();
                if (reports.Contains(fileName)) return;
                reports.Add(fileName);
                companyToUpdate.Reports = reports.ToArray();
            }

            await _dbContext.SaveChangesAsync();
        }
        public void AddReport(int companyId, string fileName)
        {
            var companyToUpdate =  _dbContext.Companies.Find(companyId);
            if (companyToUpdate.Reports == null)
            {
                companyToUpdate.Reports = new string[1] { fileName };
            }
            else
            {
                var reports = companyToUpdate.Reports.ToList();
                if (reports.Contains(fileName)) return;
                reports.Add(fileName);
                companyToUpdate.Reports = reports.ToArray();
            }

             _dbContext.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            var company = await _dbContext.Companies.FindAsync(id);
            _dbContext.Companies.Remove(company);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteReportAsync(int companyId, string fileName)
        {
            var companyToUpdate = await _dbContext.Companies.FindAsync(companyId);
            var reports = companyToUpdate.Reports.ToList();
            reports.Remove(fileName);
            companyToUpdate.Reports = reports.ToArray();
            await _dbContext.SaveChangesAsync();
        }
        public Company Delete(int id)
        {
            var company =  _dbContext.Companies.Find(id);
            _dbContext.Companies.Remove(company);
            _dbContext.SaveChangesAsync();
            return company;
        }

        public async Task<Company> GetByIdAsync(int id)
        {
            return await _dbContext.Companies.FindAsync(id);
        }
        public Company GetById(int id)
        {
            return  _dbContext.Companies.Find(id);
        }

        public IEnumerable<Company> GetAll()
        {
            var query = from r in _dbContext.Companies
                        orderby r.Id
                        select r;
            return query;
        }

        public async Task<IEnumerable<Company>> GetAllForAdminAsync()
        {
            return await _dbContext.Companies.AsNoTracking().Select(s => s).ToListAsync();
        }

        public async Task<IEnumerable<Company>> GetAllForUserAsync(string userEmail)
        {
            return await _dbContext.Companies.AsNoTracking().Where(c => c.UserEmail == userEmail).Select(s => s).ToListAsync();
        }

        public async Task UpdateAsync(Company company)
        {
            var companyToUpdate = await _dbContext.Companies.FindAsync(company.Id);
            companyToUpdate.Name = company.Name;
            companyToUpdate.Description = company.Description;
            await _dbContext.SaveChangesAsync();
        }


        public void Update(Company company)
        {
            var companyToUpdate =  _dbContext.Companies.Find(company.Id);
            companyToUpdate.Name = company.Name;
            companyToUpdate.Description = company.Description;
            companyToUpdate.Reports = company.Reports;
            //companyToUpdate.Tags = company.Tags;
            _dbContext.SaveChanges();
        }

        public void AddRange(IEnumerable<Company> companies)
        {
            _dbContext.Companies.AddRange(companies);
            _dbContext.SaveChanges();
        }
        public async Task AddRangeAsync(IEnumerable<Company> companies)
        {
            await _dbContext.Companies.AddRangeAsync(companies);
            await _dbContext.SaveChangesAsync();
        }
    }
}