using Barber.Domain.DTOs;
using Barber.Domain.Helper;
using Barber.Service.Services.WorkingHours;
using Microsoft.AspNetCore.Mvc;

namespace Barber.Controllers;

[ApiController]
[Route("api/working-hour")]
public class WorkingHourController(IWorkingHourService workingHourService) : ControllerBase
{
    [HttpPost("create")]
    public async Task<ResponseModel<WorkingHourDto>> CreateAsync(CreateWorkingHourDto dto) =>
        await workingHourService.AddAsync(dto); 
    
    [HttpGet("get-all")]
    public async Task<TableResponse<List<WorkingHourDto>>> GetAllAsync([FromQuery] TableOptions options) =>
        await workingHourService.GetAllAsync(options);
    
    [HttpGet("get-by-id/{id}")]
    public async Task<ResponseModel<WorkingHourDto>> GetByIdAsync(Guid id) =>
        await workingHourService.GetByIdAsync(id);
    
    [HttpPut("update/{id}")]
    public async Task<ResponseModel<WorkingHourDto>> UpdateAsync(UpdateWorkingHourDto dto, Guid id) =>
        await workingHourService.UpdateAsync(dto, id);
    
    [HttpDelete("delete/{id}")]
    public async Task<ResponseModel<bool>> DeleteAsync(Guid id) =>
        await workingHourService.RemoveAsync(id);
}