using Barber.Domain.DTOs;
using Barber.Domain.Helper;
using Barber.Service.Services.Appointments;
using Microsoft.AspNetCore.Mvc;

namespace Barber.Controllers;

[ApiController]
[Route("api/appointment")]
public class AppointmentController(IAppointmentService appointmentService) : ControllerBase
{
    [HttpPost("create")]
    public async Task<ResponseModel<AppointmentDto>> CreateAsync(CreateAppointmentDto dto)=>
        await appointmentService.AddAsync(dto);
    
    [HttpGet("get-all")]
    public async Task<TableResponse<List<AppointmentDto>>> GetAllAsync([FromQuery] TableOptions  options)=>
        await appointmentService.GetAllAsync(options);
    
    [HttpGet("get-by-id/{id}")]
    public async Task<ResponseModel<AppointmentDto>> GetByIdAsync(Guid id)=>
        await appointmentService.GetByIdAsync(id);

    [HttpPut("update/{id}")]
    public async Task<ResponseModel<AppointmentDto>> UpdateAsync(UpdateAppointmentDto dto, Guid id) =>
        await appointmentService.UpdateAsync(dto, id);

    [HttpDelete("delete/{id}")]
    public async Task<ResponseModel<bool>> DeleteAsync(Guid id) =>
        await appointmentService.RemoveAsync(id);
}