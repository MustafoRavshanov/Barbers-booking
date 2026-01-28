using Barber.Domain.DTOs;
using Barber.Domain.Helper;
using Barber.Service.Services.Barber;
using Microsoft.AspNetCore.Mvc;

namespace Barber.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BarberController(IBarberService barberService):ControllerBase
{
    [HttpPost("create")]
    public async Task<ResponseModel<BarbersDto>> CreateAsync(CreateBarberDto barberDto) =>
        await barberService.AddAsync(barberDto);
    
    [HttpGet("getAll")]
    public async Task<TableResponse<List<BarbersDto>>> GetAllasync(TableOptions  options)=>
        await barberService.GetAllAsync(options);
    
    [HttpGet("getById {id}")]
    public async Task<ResponseModel<BarbersDto>> GetByIdAsync(Guid id) =>
        await barberService.GetByIdAsync(id);
    
    [HttpPut("update {id}")]
    public async Task<ResponseModel<BarbersDto>> UpdateAsync(UpdateBarberDto barberDto,Guid id) =>
        await barberService.UpdateAsync(barberDto,id);
}