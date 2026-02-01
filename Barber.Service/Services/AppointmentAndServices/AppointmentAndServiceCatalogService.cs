using AutoMapper;
using Barber.Domain.DTOs;
using Barber.Domain.Entities;
using Barber.Domain.Helper;
using Barber.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Barber.Service.Services.AppointmentAndServices
{
    public class AppointmentAndServiceCatalogService(ApplicationDbContext applicationDbContext, IMapper mapper):IAppointmentAndServiceCatalogService
    {
        public async Task<ResponseModel<AppointmentServiceDto>> AddServiceToAppointmentAsync(AppointmentServiceDto dto)
        {
            var entity = mapper.Map<AppointmentAndService>(dto);

            await applicationDbContext.AppointmentServices.AddAsync(entity);
            var result = await applicationDbContext.SaveChangesAsync();

            if (result < 1)
                return ResponseModel<AppointmentServiceDto>.Fail("Error with saving to database", HttpStatusCode.InternalServerError);

            var resultDto = mapper.Map<AppointmentServiceDto>(result);

            return ResponseModel<AppointmentServiceDto>.Success(resultDto);
        }

        public async Task<TableResponse<List<AppointmentServiceDto>>> GetAllAsync(TableOptions option)
        {
            List<AppointmentServiceDto> dtos = new();
            var entities = applicationDbContext.AppointmentServices.AsQueryable();
            var count = await entities.CountAsync();

            var appointmentAndServiceCatalogs= await entities
                .Skip(option.First)
                .Take(option.Rows)
                .ToListAsync();

            var resultDtos = mapper.Map<List<AppointmentServiceDto>>(appointmentAndServiceCatalogs);

            return new TableResponse<List<AppointmentServiceDto>>() { Total = count, Items = resultDtos };
        }

        public async Task<ResponseModel<List<AppointmentServiceDto>>> GetAllServicesByAppointmentIdAsync(Guid appointmentId)
        {
            var appointmentAndServiceCatalogs = await applicationDbContext.AppointmentServices.Where(asc => asc.AppointmentId == appointmentId).ToListAsync();

            if (appointmentAndServiceCatalogs is null)
                return ResponseModel<List<AppointmentServiceDto>>.Fail("Appointment & Service not found", HttpStatusCode.NotFound);

            var dtos = mapper.Map<List<AppointmentServiceDto>>(appointmentAndServiceCatalogs);

            return ResponseModel<List<AppointmentServiceDto>>.Success(dtos);
        }

        public async Task<ResponseModel<List<AppointmentServiceDto>>> GetAllAppointmentsByServiceIdAsync(Guid serviceId)
        {
            var appointmentAndServiceCatalogs = await applicationDbContext.AppointmentServices.Where(asc => asc.ServiceId == serviceId).ToListAsync();

            if (appointmentAndServiceCatalogs is null)
                return ResponseModel<List<AppointmentServiceDto>>.Fail("Appointment & Service not found", HttpStatusCode.NotFound);

            var dtos = mapper.Map<List<AppointmentServiceDto>>(appointmentAndServiceCatalogs);

            return ResponseModel<List<AppointmentServiceDto>>.Success(dtos);
        }

        public async Task<ResponseModel<AppointmentServiceDto>> UpdateServiceByAppointmentIdAsync(UpdateAppointmentServiceDto updateDto, Guid appointmentId)
        {
            var entity = await applicationDbContext.AppointmentServices.FirstOrDefaultAsync(asc => asc.AppointmentId == appointmentId);

            if (entity is null)
                return ResponseModel<AppointmentServiceDto>.Fail("Appointment & Service not found", HttpStatusCode.NotFound);

            mapper.Map(updateDto, entity);
            var result = await applicationDbContext.SaveChangesAsync();

            if (result < 1)
                return ResponseModel<AppointmentServiceDto>.Fail("Error with updating Appointment & Service", HttpStatusCode.InternalServerError);

            var dto = mapper.Map<AppointmentServiceDto>(entity);

            return ResponseModel<AppointmentServiceDto>.Success(dto);
        }

        public async Task<ResponseModel<bool>> RemoveServiceFromAppointmentAsync(Guid appointmentId, Guid serviceId)
        {
            var entity = await applicationDbContext.AppointmentServices.FirstOrDefaultAsync(asc => asc.AppointmentId == appointmentId && asc.ServiceId == serviceId);

            if (entity is null)
                return ResponseModel<bool>.Fail("Appointment & Service not found", HttpStatusCode.NotFound);

            applicationDbContext.AppointmentServices.Remove(entity);
            var result = await applicationDbContext.SaveChangesAsync();

            if (result < 1)
                return ResponseModel<bool>.Fail("Error with deleting Appointment & Service", HttpStatusCode.InternalServerError);

            return ResponseModel<bool>.Success(true);
        }
    }
}
