using AutoMapper;
using Entity.Models;
using Services.ORM.Dtos.CustomerDto;

namespace Services.ORM.Configuration.Mapper.CustomerMap
{
    public interface ICustomerMapper
    {
        IMapper CustomerConfiguration();
    }

    public class CustomerMapper : ICustomerMapper
    {
        public IMapper CustomerConfiguration()
        {
            return new MapperConfiguration(map =>
            {
                map.CreateMap<Customer, CustomerDto>().ReverseMap();
            })
            .CreateMapper();
        }
    }
}
