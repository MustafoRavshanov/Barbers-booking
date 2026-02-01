using Barber.Domain.DTOs;
using Barber.Domain.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barber.Service.Services.AppointmentAndServices
{
    public interface IAppointmentAndServiceCatalogService
    {
        Task<ResponseModel<AppointmentServiceDto>> AddServiceToAppointmentAsync(AppointmentServiceDto dto);
        Task<TableResponse<List<AppointmentServiceDto>>> GetAllAsync(TableOptions option);
        Task<ResponseModel<List<AppointmentServiceDto>>> GetAllServicesByAppointmentIdAsync(Guid appointmentId);
        Task<ResponseModel<List<AppointmentServiceDto>>> GetAllAppointmentsByServiceIdAsync(Guid serviceId);
        Task<ResponseModel<AppointmentServiceDto>> UpdateServiceByAppointmentIdAsync(UpdateAppointmentServiceDto updateDto, Guid appointmentId);
        Task<ResponseModel<bool>> RemoveServiceFromAppointmentAsync(Guid appointmentId, Guid serviceId);
    }
}
