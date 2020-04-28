using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using routin.Model;
using routin.Services;

namespace routin.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CompanyController : ControllerBase

    {
        private readonly ICompanyRepository _CompanyRepository;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyRepository companyRepository,IMapper mapper)
        {
            _CompanyRepository = companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));
            _mapper = mapper??throw new ArgumentException(nameof(mapper));
        }


        [HttpGet("{companyId}")]

        public async Task<IActionResult> GetCompanyies(Guid companyId)
        {
            var exist = await _CompanyRepository.CompanyExistsAsync(companyId);
            if (!exist)
            {
                return NotFound();
            };


            var companies = await _CompanyRepository.GetCompanyAsync(companyId);
            if (companyId == null) { return NotFound(); }
            return Ok(companies);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyDto>>> GetCompanyies()
        {

            var companies = await _CompanyRepository.GetCompaniesAsync();
            //var companydto = new List<CompanyDto>();
            //foreach (var company in companies)
            //{
            //    companydto.Add(new CompanyDto
            //    {
            //        Id = company.Id,
            //        ExterName = company.Name
            //    });              
            //} 
            var companydto = _mapper.Map<IEnumerable<CompanyDto>>(companies);
        return Ok(companydto);
        }
    }
}
