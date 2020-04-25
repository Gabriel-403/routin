using System;
using System.Collections.Generic;

namespace routin.entities
{
    public class Company
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public string Name { get; set; }
        public string Introduction { get; set; }
        public ICollection<Employee> Employees {get;set;}
    }
}