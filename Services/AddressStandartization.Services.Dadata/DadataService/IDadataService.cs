using AddressStandartization.Services.DadataService.DTO;

namespace AddressStandartization.Services.DadataService
{
    public interface IDadataService
    {
        Task<AddressResponseDto> StandardizeAddressAsync(string rawAddress);
    }

}
