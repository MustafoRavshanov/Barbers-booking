using Barber.Domain.DTOs;
using Barber.Domain.Helper;
using Barber.Service.Services.Barber;
using Microsoft.AspNetCore.Mvc;

namespace Barber.Controllers;

[ApiController]
[Route("api/barber")]
public class BarberController(IBarberService barberService) : ControllerBase
{
    [HttpPost("create")]
    public async Task<ResponseModel<FullBarberInformationDto>> CreateAsync(FullBarberInformationDto informationDto)
        => await barberService.AddAsync(informationDto);

    [HttpGet("get-all")]
    public async Task<TableResponse<List<BarbersDto>>> GetAllasync([FromQuery] TableOptions options) =>
        await barberService.GetAllAsync(options);

    [HttpGet("get-by-id/{id}")]
    public async Task<ResponseModel<BarbersDto>> GetByIdAsync([FromRoute] Guid id) =>
        await barberService.GetByIdAsync(id);

    [HttpPut("update/{id}")]
    public async Task<ResponseModel<BarbersDto>> UpdateAsync(UpdateBarberDto barberDto, Guid id) =>
        await barberService.UpdateAsync(barberDto, id);
}


