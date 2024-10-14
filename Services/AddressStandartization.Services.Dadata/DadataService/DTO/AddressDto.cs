using AutoMapper;

namespace AddressStandartization.Services.DadataService.DTO
{
    public class AddressDto
    {
        public string Result { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
    }
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<AddressResponseDto, AddressDto>();
        }
    }
}
