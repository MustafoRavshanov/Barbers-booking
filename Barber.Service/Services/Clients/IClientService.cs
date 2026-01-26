using Barber.Domain.DTOs;
using Barber.Domain.Entities;

namespace Barber.Service.Services.Clients;

public interface IClientService
{
    ValueTask<ClientDto> AddClientAsync(ClientDto clientDto);
    IQueryable<ClientDto> RetrieveAllClients();
    ValueTask<ClientDto> RetrieveClientByIdAsync(Guid id);
    ValueTask<ClientDto> ModifyClientAsync(ClientDto clientDto, Guid id);
}