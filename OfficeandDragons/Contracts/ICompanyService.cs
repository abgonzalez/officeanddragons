using OfficeandDragons.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OfficeandDragons.Contracts
{
    public interface ICompanyService
    {
        Task<Company> GetByIdAsync(int id);
        Company GetById(int id);

        Task<IEnumerable<Company>> GetAllForAdminAsync();
      

        Task<IEnumerable<Company>> GetAllForUserAsync(string userEmail);

        Task AddAsync(Company company);
        void Add(Company company);

        Task AddReportAsync(int companyId, string fileName);
        void AddReport(int companyId, string fileName);

        Task DeleteReportAsync(int companyId, string fileName);

        Task UpdateAsync(Company company);

        void Update(Company company);

        Task DeleteAsync(int id);
        Company Delete(int id);

        Task AddRangeAsync(IEnumerable<Company> companies);
        IEnumerable<Company> GetAll();
    }
}