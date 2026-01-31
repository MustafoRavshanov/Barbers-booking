using System.Net;
using AutoMapper;
using Barber.Domain.DTOs;
using Barber.Domain.Entities;
using Barber.Domain.Helper;
using Barber.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Barber.Service.Services.Appointments;

public class AppointmentService(ApplicationDbContext applicationDbContext, IMapper mapper):IAppointmentService
{
    public async Task<ResponseModel<AppointmentDto>> AddAsync(CreateAppointmentDto appointmentDto)
    {
        var appointment = mapper.Map<Appointment>(appointmentDto);
        await applicationDbContext.Appointments.AddAsync(appointment);
        var result = await applicationDbContext.SaveChangesAsync();

        if (result < 1)
            return ResponseModel<AppointmentDto>.Fail("Error with saving to database",HttpStatusCode.InternalServerError);

        var dto = mapper.Map<AppointmentDto>(appointment);
        
        return ResponseModel<AppointmentDto>.Success(dto);
    }

    public async Task<TableResponse<List<AppointmentDto>>> GetAllAsync(TableOptions options)
    {
        List<AppointmentDto> appointmentDtos = new();

        var entities = applicationDbContext.Appointments.AsQueryable();
        var count = await entities.CountAsync();
        
        var appointments = await entities
            .Skip(options.First)
            .Take(options.Rows)
            .ToListAsync();
        
        var dtos = mapper.Map<List<AppointmentDto>>(appointments);

        return new TableResponse<List<AppointmentDto>>() { Total = count, Items = dtos };
    }

    public async Task<ResponseModel<AppointmentDto>> GetByIdAsync(Guid id)
    {
        var appointment = await applicationDbContext.Appointments.FindAsync(id);
        
        if (appointment is null)
            return ResponseModel<AppointmentDto>.Fail("Appointment not found",HttpStatusCode.NotFound);
        
        var dto = mapper.Map<AppointmentDto>(appointment);
        
        return ResponseModel<AppointmentDto>.Success(dto);
    }

    public async Task<ResponseModel<AppointmentDto>> UpdateAsync(UpdateAppointmentDto appointmentDto, Guid id)
    {
        var appointment = await applicationDbContext.Appointments.FindAsync(id);
        
        if (appointment is null)
            return ResponseModel<AppointmentDto>.Fail("Appointment not found",HttpStatusCode.NotFound);
        
        applicationDbContext.Appointments.Update(appointment);
        var result = await applicationDbContext.SaveChangesAsync();
        
        if (result < 1)
            return ResponseModel<AppointmentDto>.Fail("Error with saving to database",HttpStatusCode.InternalServerError);
        
        var dto = mapper.Map<AppointmentDto>(appointmentDto);
        
        return ResponseModel<AppointmentDto>.Success(dto);
    }

    public async Task<ResponseModel<bool>> RemoveAsync(Guid id)
    {
        var appointment = await applicationDbContext.Appointments.FindAsync(id);
        
        if (appointment is null)
            return ResponseModel<bool>.Fail("Appointment not found",HttpStatusCode.NotFound);
        
        applicationDbContext.Appointments.Remove(appointment);
        var result = await applicationDbContext.SaveChangesAsync();
        
        if (result < 1)
            return ResponseModel<bool>.Fail("Error with saving to database",HttpStatusCode.InternalServerError);
        
        return ResponseModel<bool>.Success(true);
    }
}