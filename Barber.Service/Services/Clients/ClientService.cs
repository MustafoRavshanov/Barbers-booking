using System.Net;
using AutoMapper;
using Barber.Domain.DTOs;
using Barber.Domain.Entities;
using Barber.Domain.Helper;
using Barber.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Barber.Service.Services.Clients;

public class ClientService(ApplicationDbContext applicationDbContext,IMapper mapper):IClientService
{
    public async Task<ResponseModel<ClientDto>> AddAsync(CreateClientDto createClientDto)
    {
        var client=mapper.Map<Client>(createClientDto);
        
        await applicationDbContext.Clients.AddAsync(client);
        await applicationDbContext.SaveChangesAsync();
        
        var dto= mapper.Map<ClientDto>(client);
        
        return ResponseModel<ClientDto>.Success(dto);
    }

    public async Task<TableResponse<List<ClientDto>>> GetAllAsync(TableOptions options)
    {
        Console.WriteLine($"First: {options.First}, Rows: {options.Rows}");
        List<ClientDto> clientsDto = new();
        
        var entities = applicationDbContext.Clients.AsQueryable();
        
        var count = await entities.CountAsync();
        
        var clients= await entities
            .Skip(options.First)
            .Take(options.Rows)
            .ToListAsync();
        
        var dtos = mapper.Map<List<ClientDto>>(clients);
        
        return new TableResponse<List<ClientDto>>(){Total = count,Items = dtos};
    }

    public async Task<ResponseModel<ClientDto>> GetByIdAsync(Guid id)
    {
        var client =await applicationDbContext.Clients.FindAsync(id);
        
        if (client is null)
            return ResponseModel<ClientDto>.Fail("Client not found");
        
        var dto= mapper.Map<ClientDto>(client);
        
        return ResponseModel<ClientDto>.Success(dto);
    }

    public async Task<ResponseModel<ClientDto>> UpdateAsync(UpdateClientDto updateClientDto, Guid id)
    {
        var client=await applicationDbContext.Clients.FindAsync(id);
        
        if (client is null)
            return ResponseModel<ClientDto>.Fail("Client not found");
        
        mapper.Map(updateClientDto, client);
        var result=await applicationDbContext.SaveChangesAsync();
        
        if (result < 1)
            return ResponseModel<ClientDto>.Fail("Error with saving to database", HttpStatusCode.InternalServerError);
        
        var dto= mapper.Map<ClientDto>(client);
        
        return ResponseModel<ClientDto>.Success(dto);
    }
}