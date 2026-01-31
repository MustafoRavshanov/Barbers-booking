using AutoMapper;
using Barber.Domain.DTOs;
using Barber.Domain.Entities;
using Barber.Domain.Helper;
using Barber.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Barber.Service.Services.BarberAndServiceCatalogs
{
    public class BarberAndServiceCatalogService(ApplicationDbContext applicationDbContext,IMapper mapper):IBarberAndServiceCatalogsService
    {
        public async Task<ResponseModel<BarberServiceCatalogDto>> AddServiceToBarberAsync(CreateBarberServiceCatalogDto dto)
        {
            var entity = mapper.Map<BarberServiceCatalog>(dto);
            await applicationDbContext.BarberServiceCatalogs.AddAsync(entity);
            var result = await applicationDbContext.SaveChangesAsync();

            if (result < 1)
                return ResponseModel<BarberServiceCatalogDto>.Fail("Error with saving to database", HttpStatusCode.InternalServerError);

            var responseDto = mapper.Map<BarberServiceCatalogDto>(entity);

            return ResponseModel<BarberServiceCatalogDto>.Success(responseDto);
        }

        public async Task<TableResponse<List<BarberServiceCatalogDto>>> GetAllAsync(TableOptions options)
        {
            List<BarberServiceCatalogDto> dtos = new(); 
            var entities = applicationDbContext.BarberServiceCatalogs.AsQueryable();
            var count = await entities.CountAsync();

            var barberServiceCatalogs = await entities
                .Skip(options.First)
                .Take(options.Rows)
                .ToListAsync();

            var resultDtos = mapper.Map<List<BarberServiceCatalogDto>>(barberServiceCatalogs);

            return new TableResponse<List<BarberServiceCatalogDto>>() { Total = count, Items = resultDtos };
        }

        public async Task<ResponseModel<List<BarberServiceCatalogDto>>> GetAllServicesByBarberIdAsync(Guid barberId)
        {
            var barberServiceCatalogs = await applicationDbContext.BarberServiceCatalogs.Where(bsc => bsc.BarberId == barberId).ToListAsync();
           
            if (barberServiceCatalogs is null)
                return ResponseModel<List<BarberServiceCatalogDto>>.Fail("Barber & Service not found", HttpStatusCode.NotFound);

            var dtos = mapper.Map<List<BarberServiceCatalogDto>>(barberServiceCatalogs);

            return ResponseModel<List<BarberServiceCatalogDto>>.Success(dtos);
        }

        public async Task<ResponseModel<List<BarberServiceCatalogDto>>> GetAllBarbersByServiceIdAsync(Guid serviceId)
        {
            var barberServiceCatalogs = await applicationDbContext.BarberServiceCatalogs.Where(bsc => bsc.ServiceId == serviceId).ToListAsync();

            if (barberServiceCatalogs is null)
                return ResponseModel<List<BarberServiceCatalogDto>>.Fail("Barber & Service not found", HttpStatusCode.NotFound);

            var dtos = mapper.Map<List<BarberServiceCatalogDto>>(barberServiceCatalogs);

            return ResponseModel<List<BarberServiceCatalogDto>>.Success(dtos);
        }
        public async Task<ResponseModel<BarberServiceCatalogDto>> UpdateServiceByBarberIdAsync(UpdateBarberServiceCatalogDto updateDto, Guid barberId)
        {
            var barberServiceCatalog = await applicationDbContext.BarberServiceCatalogs.FirstOrDefaultAsync(bsc => bsc.BarberId == barberId);

            if (barberServiceCatalog is null)
                return ResponseModel<BarberServiceCatalogDto>.Fail("Barber & Service not found", HttpStatusCode.NotFound);

            mapper.Map(updateDto, barberServiceCatalog);
            var result = await applicationDbContext.SaveChangesAsync();

            if (result < 1)
                return ResponseModel<BarberServiceCatalogDto>.Fail("Error with saving to database", HttpStatusCode.InternalServerError);

            var dto = mapper.Map<BarberServiceCatalogDto>(barberServiceCatalog);

            return ResponseModel<BarberServiceCatalogDto>.Success(dto);
        }

        public async Task<ResponseModel<bool>> DeleteServiceFromBarberAsync(Guid barberId, Guid serviceId)
        {
            var barberServiceCatalog = await applicationDbContext.BarberServiceCatalogs.FirstOrDefaultAsync(bsc => bsc.BarberId == barberId && bsc.ServiceId == serviceId);
            
            if (barberServiceCatalog is null)
                return ResponseModel<bool>.Fail("Barber & Service not found", HttpStatusCode.NotFound);

            applicationDbContext.BarberServiceCatalogs.Remove(barberServiceCatalog);
            var result = await applicationDbContext.SaveChangesAsync();

            if (result < 1)
                return ResponseModel<bool>.Fail("Error with saving to database", HttpStatusCode.InternalServerError);

            return ResponseModel<bool>.Success(true, "Barber & Server deleted succesfully");
        }
    }
}
