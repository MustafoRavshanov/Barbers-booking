using System.Net;
using AutoMapper;
using Barber.Domain.DTOs;
using Barber.Domain.Entities;
using Barber.Domain.Helper;
using Barber.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Barber.Service.Services.WorkingHours;

public class WorkingHourService(ApplicationDbContext applicationDbContext, IMapper mapper):IWorkingHourService
{
    public async Task<ResponseModel<WorkingHourDto>> AddAsync(CreateWorkingHourDto createWorkingHourDto)
    {
        var workingHour = mapper.Map<WorkingHour>(createWorkingHourDto);
        await applicationDbContext.WorkingHours.AddAsync(workingHour);
        await applicationDbContext.SaveChangesAsync();
        
        var dto= mapper.Map<WorkingHourDto>(workingHour);
        
        return ResponseModel<WorkingHourDto>.Success(dto);
    }

    public async Task<TableResponse<List<WorkingHourDto>>> GetAllAsync(TableOptions options)
    {
        List<WorkingHourDto> workingHourDtos = new();
        var entities = applicationDbContext.WorkingHours.AsQueryable();
        var count= await entities.CountAsync();
        
        var workingHours = await entities
            .Skip(options.First)
            .Take(options.Rows)
            .ToListAsync();
        
        var dtos = mapper.Map<List<WorkingHourDto>>(workingHours);

        return new TableResponse<List<WorkingHourDto>>() { Total = count, Items = dtos };
    }

    public async Task<ResponseModel<WorkingHourDto>> GetByIdAsync(Guid id)
    {
        var workingHour = await applicationDbContext.WorkingHours.FindAsync(id);
        
        if (workingHour is null)
            return ResponseModel<WorkingHourDto>.Fail("Working hour not found",HttpStatusCode.NotFound);
        
        var dto = mapper.Map<WorkingHourDto>(workingHour);
        
        return ResponseModel<WorkingHourDto>.Success(dto);
    }

    public async Task<ResponseModel<WorkingHourDto>> UpdateAsync(UpdateWorkingHourDto updateWorkingHourDto, Guid id)
    {
        var workingHour = await applicationDbContext.WorkingHours.FindAsync(id);
        
        if (workingHour is null)
            return ResponseModel<WorkingHourDto>.Fail("Working hour not found", HttpStatusCode.NotFound);
        
        mapper.Map(updateWorkingHourDto, workingHour);
        var result = await applicationDbContext.SaveChangesAsync();
        
        if (result < 1)
            return ResponseModel<WorkingHourDto>.Fail("Error with saving to database", HttpStatusCode.InternalServerError);
        
        var dto = mapper.Map<WorkingHourDto>(workingHour);
        
        return ResponseModel<WorkingHourDto>.Success(dto);
    }

    public async Task<ResponseModel<bool>> RemoveAsync(Guid id)
    {
        var workingHour = await applicationDbContext.WorkingHours.FindAsync(id);
        
        if (workingHour is null)
            return ResponseModel<bool>.Fail("Working hour not found", HttpStatusCode.NotFound);
        
        applicationDbContext.WorkingHours.Remove(workingHour);
        var result = await applicationDbContext.SaveChangesAsync();
        
        if (result < 1)
            return ResponseModel<bool>.Fail("Error with saving to database", HttpStatusCode.InternalServerError);
        
        return ResponseModel<bool>.Success(true,"Working hour deleted successfully");
    }
}