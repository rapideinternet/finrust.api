using AutoMapper;
using FinRust.Application.Common.Mappings;
using FinRust.Domain.Entities;

namespace FinRust.Application.Customers.Queries.Models
{
    public class CustomerLookupDto : IMapFrom<Customer>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Customer, CustomerLookupDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.CustomerId));
        }
    }
}
