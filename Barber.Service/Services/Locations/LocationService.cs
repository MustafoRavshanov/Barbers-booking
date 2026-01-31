using System.Net;
using AutoMapper;
using Barber.Domain.DTOs;
using Barber.Domain.Entities;
using Barber.Domain.Helper;
using Barber.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Barber.Service.Services.Locations;

public class LocationService(ApplicationDbContext applicationDbContext, IMapper mapper):ILocationService
{
    public async Task<ResponseModel<LocationDto>> AddAsync(CreateLocationDto createLocationDto)
    {
        var location=mapper.Map<Location>(createLocationDto);
        
        await applicationDbContext.Locations.AddAsync(location);
        var result = await applicationDbContext.SaveChangesAsync();

        if(result < 1)
            return ResponseModel<LocationDto>.Fail("Error with saving to database", HttpStatusCode.InternalServerError);

        var dto= mapper.Map<LocationDto>(location);
        
        return ResponseModel<LocationDto>.Success(dto);
    }

    public async Task<TableResponse<List<LocationDto>>> GetAllAsync(TableOptions options)
    {
        List<LocationDto> locationDtos=new();
        
        var entities = applicationDbContext.Locations.AsQueryable();
        var count=await entities.CountAsync();
        var locations=await entities
            .Skip(options.First)
            .Take(options.Rows)
            .ToListAsync();
        
        var dtos = mapper.Map<List<LocationDto>>(locations);

        return new TableResponse<List<LocationDto>>() { Total = count, Items = dtos };
    }

    public async Task<ResponseModel<LocationDto>> GetByIdAsync(Guid id)
    {
        var location=await applicationDbContext.Locations.FindAsync(id);
        
        if (location is null)
            return ResponseModel<LocationDto>.Fail("Location not found", HttpStatusCode.NotFound);

        var dto = mapper.Map<LocationDto>(location);
        
        return ResponseModel<LocationDto>.Success(dto);
    }

    public async Task<ResponseModel<LocationDto>> UpdateAsync(UpdateLocationDto updateLocationDto, Guid id)
    {
        var location=await applicationDbContext.Locations.FindAsync(id);
        
        if (location is null)
            return ResponseModel<LocationDto>.Fail("Location not found", HttpStatusCode.NotFound);
        
        mapper.Map(updateLocationDto, location);
        var result = await applicationDbContext.SaveChangesAsync();
        
        if (result < 1)
            return ResponseModel<LocationDto>.Fail("Error with saving to database", HttpStatusCode.InternalServerError);
        
        var dto= mapper.Map<LocationDto>(location);
        
        return ResponseModel<LocationDto>.Success(dto);
    }

    public async Task<ResponseModel<bool>> RemoveAsync(Guid id)
    {
        var location=await applicationDbContext.Locations.FindAsync(id);
        
        if (location is null)
            return ResponseModel<bool>.Fail("Location not found", HttpStatusCode.NotFound);
        
        applicationDbContext.Locations.Remove(location);
        var result= await applicationDbContext.SaveChangesAsync();
        
        if (result < 1)
            return ResponseModel<bool>.Fail("Error with saving to database", HttpStatusCode.InternalServerError);
        
        return ResponseModel<bool>.Success(true,"Location deleted successfully");
    }
}