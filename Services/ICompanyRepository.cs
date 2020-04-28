using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using routin.entities;

namespace routin.Services
{
    public interface ICompanyRepository
    {
        
        Task<Company> GetCompanyAsync(Guid companyId);
        Task<IEnumerable<Company>> GetCompaniesAsync(IEnumerable<Guid> companyIds);
        void AddCompany(Company company);
        void UpdateCompany(Company company);
        void DeleteCompany(Company company);
        Task<bool> CompanyExistsAsync(Guid companyId);

        
        Task<Employee> GetEmployeeAsync(Guid companyId, Guid employeeId);
        Task <IEnumerable<Company>> GetCompaniesAsync();
        void AddEmployee(Guid companyId, Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(Employee employee);

        
        Task<bool> SaveAsync();
    }
}
