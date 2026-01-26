using AutoMapper;
using Barber.Domain.DTOs;
using Barber.Domain.Entities;
using Barber.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Barber.Service.Services.Clients;

public class ClientService(ApplicationDbContext applicationDbContext,IMapper mapper): IClientService
{
    public async ValueTask<ClientDto> AddClientAsync(ClientDto clientDto)
    {
        Client client=mapper.Map<Client>(clientDto);
        await applicationDbContext.Clients.AddAsync(client);
        await applicationDbContext.SaveChangesAsync();
        ClientDto savedClientDto=mapper.Map<ClientDto>(client);
        return savedClientDto;
    }

    public IQueryable<ClientDto> RetrieveAllClients()
    {
        List<ClientDto> clientsDto = new();
        foreach (var client in applicationDbContext.Clients)
        {
            clientsDto.Add(mapper.Map<ClientDto>(client));
        }
        return clientsDto.AsQueryable();
        
    }

    public async ValueTask<ClientDto> RetrieveClientByIdAsync(Guid id)
    {
        Client? client =await applicationDbContext.Clients.FirstOrDefaultAsync(x=>x.Id==id);
        ClientDto clientDto=mapper.Map<ClientDto>(client);
        return clientDto;
    }

    public async ValueTask<ClientDto> ModifyClientAsync(ClientDto clientDto, Guid id)
    {
        Client? client=await applicationDbContext.Clients.FirstOrDefaultAsync(x=>x.Id==id);
        if (client is null)
        {
            throw new Exception("Client not found");
        }

        Client newClient= mapper.Map<Client>(clientDto);
        newClient.Id = id;
        
        applicationDbContext.Update(newClient);
        await applicationDbContext.SaveChangesAsync();
        
        ClientDto updatedClientDto=mapper.Map<ClientDto>(client);
        return updatedClientDto;
    }
}