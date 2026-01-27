using Barber.Domain.DTOs;
using Barber.Domain.Helper;

namespace Barber.Service.Services.ServiceCatalogs;

public interface IServiceCatalogService
{
    Task<ResponseModel<ServiceCatalogDto>> AddAsync(CreateServiceCatalogDto serviceDto);
    Task<TableResponse<List<ServiceCatalogDto>>> GetAllAsync(TableOptions options);
    Task<ResponseModel<ServiceCatalogDto>> GetByIdAsync(Guid id);
    Task<ResponseModel<ServiceCatalogDto>> UpdateAsync(UpdateServiceCatalogDto updateServiceCatalogDto, Guid id);
    Task<ResponseModel<bool>> RemoveAsync(Guid id);
}