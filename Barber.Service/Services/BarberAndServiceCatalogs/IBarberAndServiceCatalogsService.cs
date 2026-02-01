using Barber.Domain.DTOs;
using Barber.Domain.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barber.Service.Services.BarberAndServiceCatalogs
{
    public interface IBarberAndServiceCatalogsService
    {
        Task<ResponseModel<BarberServiceCatalogDto>> AddServiceToBarberAsync(CreateBarberServiceCatalogDto dto);
        Task<TableResponse<List<BarberServiceCatalogDto>>> GetAllAsync(TableOptions options);
        Task<ResponseModel<List<BarberServiceCatalogDto>>> GetAllServicesByBarberIdAsync(Guid barberId);
        Task<ResponseModel<List<BarberServiceCatalogDto>>> GetAllBarbersByServiceIdAsync(Guid serviceId);
        Task<ResponseModel<BarberServiceCatalogDto>> UpdateServiceByBarberIdAsync(UpdateBarberServiceCatalogDto updateDto, Guid barberId);
        Task<ResponseModel<bool>> DeleteServiceFromBarberAsync(Guid barberId, Guid serviceId);
    }
}
