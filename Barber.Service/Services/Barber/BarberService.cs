using System.Net;
using AutoMapper;
using Barber.Domain.DTOs;
using Barber.Domain.Entities;
using Barber.Domain.Helper;
using Barber.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Barber.Service.Services.Barber;

public class BarberService(ApplicationDbContext applicationDbContext, IMapper mapper):IBarberService
{
    public async Task<ResponseModel<BarbersDto>> AddAsync(CreateBarberDto createBarberDto)
    {
        var barber = mapper.Map<Barbers>(createBarberDto);
        
        await applicationDbContext.AddAsync(barber);
        await applicationDbContext.SaveChangesAsync();

        var dto= mapper.Map<BarbersDto>(barber);
        return ResponseModel<BarbersDto>.Success(dto);
    }

    public async Task<TableResponse<List<BarbersDto>>> GetAllAsync(TableOptions options)
    {
        List<BarbersDto> barbersDto = new();
        
        var entities =  applicationDbContext.Barbers
            .AsQueryable();
        
        var count = await entities.CountAsync();
        
        var barbers = await entities
            .Skip(options.First)
            .Take(options.Rows)
            .ToListAsync();
        
        var dtos = mapper.Map<List<BarbersDto>>(barbers);
        
        return new TableResponse<List<BarbersDto>>(){Total = count,Items = dtos};
    }

    public async Task<ResponseModel<BarbersDto>> GetByIdAsync(Guid id)
    {
        var barber = await applicationDbContext.Barbers.FindAsync(id);
        if (barber is null)
            return ResponseModel<BarbersDto>.Fail("Barber not found", HttpStatusCode.NotFound);

        var dto= mapper.Map<BarbersDto>(barber);
        return ResponseModel<BarbersDto>.Success(dto);
    }

    public async Task<ResponseModel<BarbersDto>> UpdateAsync(UpdateBarberDto updateBarberDto, Guid id)
    {
        var barber = await applicationDbContext.Barbers.FindAsync(id);
       
        if(barber is null)
            return ResponseModel<BarbersDto>.Fail("Barber not found",HttpStatusCode.NotFound);
        
        mapper.Map(updateBarberDto, barber);
        var result=await applicationDbContext.SaveChangesAsync();
        if(result < 1)
            return ResponseModel<BarbersDto>.Fail("Error with save to database",HttpStatusCode.InternalServerError);
        
        var dto= mapper.Map<BarbersDto>(barber);
        return ResponseModel<BarbersDto>.Success(dto);
    }
}