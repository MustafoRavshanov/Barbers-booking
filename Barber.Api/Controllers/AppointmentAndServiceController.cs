using Barber.Domain.DTOs;
using Barber.Domain.Helper;
using Barber.Service.Services.AppointmentAndServices;
using Microsoft.AspNetCore.Mvc;

namespace Barber.Controllers
{
    [ApiController]
    [Route("api/appointment-service")]
    public class AppointmentAndServiceController(IAppointmentAndServiceCatalogService appointmentAndServiceCatalogService):ControllerBase
    {
        [HttpPost("add-service-to-appointment")]
        public async Task<ResponseModel<AppointmentServiceDto>> PostAsync(AppointmentServiceDto dto)
            => await appointmentAndServiceCatalogService.AddServiceToAppointmentAsync(dto);

        [HttpPost("get-all-appointment-services")]
        public async Task<TableResponse<List<AppointmentServiceDto>>> GetAllAsync([FromBody] TableOptions options)
            => await appointmentAndServiceCatalogService.GetAllAsync(options);

        [HttpGet("get-all-services-by-appointment-id/{appointmentId}")]
        public async Task<ResponseModel<List<AppointmentServiceDto>>> GetAllServicesByBarberIdAsync([FromQuery] Guid appointmentId)
            => await appointmentAndServiceCatalogService.GetAllServicesByAppointmentIdAsync(appointmentId);

        [HttpGet("get-all-appointments-by-service-id/{serviceId}")]
        public async Task<ResponseModel<List<AppointmentServiceDto>>> GetAllBarbersByServiceIdAsync([FromQuery] Guid serviceId)
            => await appointmentAndServiceCatalogService.GetAllAppointmentsByServiceIdAsync(serviceId);

        [HttpPut("update-by-appointment-id/{appointmentId}")]
        public async Task<ResponseModel<AppointmentServiceDto>> UpdateServiceByBarberIdAsync(UpdateAppointmentServiceDto updateDto, [FromQuery] Guid appointmentId)
            => await appointmentAndServiceCatalogService.UpdateServiceByAppointmentIdAsync(updateDto, appointmentId);

        [HttpDelete("delete-service-from-appointment/{appointmentId}/{serviceId}")]
        public async Task<ResponseModel<bool>> DeleteServiceFromBarberAsync([FromQuery] Guid appointmentId, [FromQuery] Guid serviceId)
            => await appointmentAndServiceCatalogService.RemoveServiceFromAppointmentAsync(appointmentId, serviceId);
    }
}
