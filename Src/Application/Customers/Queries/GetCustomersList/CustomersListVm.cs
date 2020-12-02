using FinRust.Application.Customers.Queries.Models;
using System.Collections.Generic;

namespace FinRust.Application.Customers.Queries.GetCustomersList
{
    public class CustomersListVm
    {
        public IList<CustomerLookupDto> Customers { get; set; }
    }
}
