using Barber.Domain.DTOs;
using Barber.Domain.Helper;
using Barber.Service.Services.ServiceCatalogs;
using Microsoft.AspNetCore.Mvc;

namespace Barber.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServiceCatalogController(IServiceCatalogService  catalogService) : ControllerBase
{
    [HttpPost("create")]
    public async Task<ResponseModel<ServiceCatalogDto>> CreateAsync(CreateServiceCatalogDto serviceDto) =>
        await catalogService.AddAsync(serviceDto);
    
    [HttpGet("getAll")]
    public async Task<TableResponse<List<ServiceCatalogDto>>> GetAllAsync(TableOptions options) =>
        await catalogService.GetAllAsync(options);
    
    [HttpGet("getById {id}")]
    public async Task<ResponseModel<ServiceCatalogDto>> GetByIdAsync(Guid id) =>
        await catalogService.GetByIdAsync(id);
    
    [HttpPut("update {id}")]
    public async Task<ResponseModel<ServiceCatalogDto>> UpdateAsync(UpdateServiceCatalogDto serviceDto, Guid id) =>
        await catalogService.UpdateAsync(serviceDto, id);
    
    [HttpDelete("delete {id}")]
    public async Task<ResponseModel<bool>> DeleteAsync(Guid id) =>
        await catalogService.RemoveAsync(id);
}