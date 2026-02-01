using Barber.Domain.DTOs;
using Barber.Domain.Helper;
using Barber.Service.Services.BarberAndServiceCatalogs;
using Microsoft.AspNetCore.Mvc;

namespace Barber.Controllers
{
    [ApiController]
    [Route("api/barber-service-catalog")]
    public class BarberAndServiceCatalogController(IBarberAndServiceCatalogsService barberAndServiceCatalogsService):ControllerBase
    {
        [HttpPost("add-service-to-barber")]
        public async Task<ResponseModel<BarberServiceCatalogDto>> PostAsync(CreateBarberServiceCatalogDto dto)
            => await barberAndServiceCatalogsService.AddServiceToBarberAsync(dto);

        [HttpPost("get-all-barber-services")]
        public async Task<TableResponse<List<BarberServiceCatalogDto>>> GetAllAsync([FromBody]TableOptions options)
            => await barberAndServiceCatalogsService.GetAllAsync(options);

        [HttpGet("get-all-services-by-barber-id/{barberId}")]
        public async Task<ResponseModel<List<BarberServiceCatalogDto>>> GetAllServicesByBarberIdAsync([FromQuery] Guid barberId)
            => await barberAndServiceCatalogsService.GetAllServicesByBarberIdAsync(barberId);

        [HttpGet("get-all-barbers-by-service-id/{serviceId}")]
        public async Task<ResponseModel<List<BarberServiceCatalogDto>>> GetAllBarbersByServiceIdAsync([FromQuery] Guid serviceId)
            => await barberAndServiceCatalogsService.GetAllBarbersByServiceIdAsync(serviceId);

        [HttpPut("update-by-barber-id/{barberId}")]
        public async Task<ResponseModel<BarberServiceCatalogDto>> UpdateServiceByBarberIdAsync(UpdateBarberServiceCatalogDto updateDto, [FromQuery] Guid barberId)
            => await barberAndServiceCatalogsService.UpdateServiceByBarberIdAsync(updateDto, barberId);

        [HttpDelete("delete-service-from-barber/{barberId}/{serviceId}")]
        public async Task<ResponseModel<bool>> DeleteServiceFromBarberAsync([FromQuery] Guid barberId, [FromQuery] Guid serviceId)
            => await barberAndServiceCatalogsService.DeleteServiceFromBarberAsync(barberId, serviceId);
    }
}