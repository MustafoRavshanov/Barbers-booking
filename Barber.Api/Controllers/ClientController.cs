using Barber.Domain.DTOs;
using Barber.Domain.Helper;
using Barber.Service.Services.Clients;
using Microsoft.AspNetCore.Mvc;

namespace Barber.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController(IClientService clientService):ControllerBase
{
    [HttpPost("create")]
    public async Task<ResponseModel<ClientDto>> CreateAsync(CreateClientDto clientDto)=>
        await clientService.AddAsync(clientDto);
    
    [HttpGet("getAll")]
    public async Task<TableResponse<List<ClientDto>>> GetAllasync(TableOptions options)=>
        await clientService.GetAllAsync(options);
    
    [HttpGet("getById{id}")]
    public async Task<ResponseModel<ClientDto>> GetByIdAsync(Guid id)=>
        await clientService.GetByIdAsync(id);
    
    [HttpPut("update {id}")]
    public async Task<ResponseModel<ClientDto>> UpdateAsync(UpdateClientDto clientDto,Guid id)=>
        await clientService.UpdateAsync(clientDto,id);
}