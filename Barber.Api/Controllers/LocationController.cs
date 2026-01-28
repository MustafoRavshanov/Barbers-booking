using Barber.Domain.DTOs;
using Barber.Domain.Helper;
using Barber.Service.Services.Locations;
using Microsoft.AspNetCore.Mvc;

namespace Barber.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationController(ILocationService locationService) : ControllerBase
{
    [HttpPost("create")]
    public async Task<ResponseModel<LocationDto>> CreateAsync(CreateLocationDto locationDto) =>
        await locationService.AddAsync(locationDto);
    
    [HttpGet("getAll")]
    public async Task<TableResponse<List<LocationDto>>> GetAllAsync(TableOptions options) =>
        await locationService.GetAllAsync(options);
    
    [HttpGet("getById {id}")]
    public async Task<ResponseModel<LocationDto>> GetByIdAsync(Guid id) =>
        await locationService.GetByIdAsync(id);
    
    [HttpPut("update {id}")]
    public async Task<ResponseModel<LocationDto>> UpdateAsync(UpdateLocationDto locationDto, Guid id) =>
        await locationService.UpdateAsync(locationDto, id);
    
    [HttpDelete("delete {id}")]
    public async Task<ResponseModel<bool>> DeleteAsync(Guid id) =>
        await locationService.RemoveAsync(id);
}