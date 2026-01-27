using Barber.Domain.DTOs;
using Barber.Domain.Entities;
using Barber.Domain.Helper;

namespace Barber.Service.Services.Clients;

public interface IClientService
{
    Task<ResponseModel<ClientDto>> AddAsync(CreateClientDto createClientDto);
    Task<TableResponse<List<ClientDto>>> GetAllAsync(TableOptions options);
    Task<ResponseModel<ClientDto>> GetByIdAsync(Guid id);
    Task<ResponseModel<ClientDto>> UpdateAsync(UpdateClientDto updateClientDto, Guid id);
}