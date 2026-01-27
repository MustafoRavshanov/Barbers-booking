using System.Net;
using AutoMapper;
using Barber.Domain.DTOs;
using Barber.Domain.Entities;
using Barber.Domain.Helper;
using Barber.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Barber.Service.Services.ServiceCatalogs;

public class ServiceCatalogService(ApplicationDbContext applicationDbContext, IMapper mapper):IServiceCatalogService
{
    public async Task<ResponseModel<ServiceCatalogDto>> AddAsync(CreateServiceCatalogDto serviceDto)
    {
        var serviceCatalog = mapper.Map<ServicesCatalog>(serviceDto);
        await applicationDbContext.ServicesCatalog.AddAsync(serviceCatalog);
        await applicationDbContext.SaveChangesAsync();
        
        var dto = mapper.Map<ServiceCatalogDto>(serviceCatalog);
        return ResponseModel<ServiceCatalogDto>.Success(dto);
    }

    public async Task<TableResponse<List<ServiceCatalogDto>>> GetAllAsync(TableOptions options)
    {
        List<ServiceCatalogDto> serviceCatalogs = new();

        var entities = applicationDbContext.ServicesCatalog.AsQueryable();
        var count = await entities.CountAsync();
        
        var services = await entities
            .Skip(options.First)
            .Take(options.Rows)
            .ToListAsync();
        
        var dtos = mapper.Map<List<ServiceCatalogDto>>(services);

        return new TableResponse<List<ServiceCatalogDto>>() { Total = count, Items = dtos };
    }

    public async Task<ResponseModel<ServiceCatalogDto>> GetByIdAsync(Guid id)
    {
        var serviceCatalog = await applicationDbContext.ServicesCatalog.FindAsync(id);
        if (serviceCatalog is null)
            return ResponseModel<ServiceCatalogDto>.Fail("Service not found");
        
        var dto = mapper.Map<ServiceCatalogDto>(serviceCatalog);
        
        return ResponseModel<ServiceCatalogDto>.Success(dto);
    }

    public async Task<ResponseModel<ServiceCatalogDto>> UpdateAsync(UpdateServiceCatalogDto updateServiceCatalogDto, Guid id)
    {
        var serviceCatalog = await applicationDbContext.ServicesCatalog.FindAsync(id);
        
        if (serviceCatalog is null)
            return ResponseModel<ServiceCatalogDto>.Fail("Service not found", HttpStatusCode.NotFound);
        
        mapper.Map(updateServiceCatalogDto, serviceCatalog);
        var result = await applicationDbContext.SaveChangesAsync();
        
        if (result < 1)
            return ResponseModel<ServiceCatalogDto>.Fail("Error with saving to database", HttpStatusCode.InternalServerError);

        var dto = mapper.Map<ServiceCatalogDto>(serviceCatalog);
        
        return ResponseModel<ServiceCatalogDto>.Success(dto);
    }

    public async Task<ResponseModel<bool>> RemoveAsync(Guid id)
    {
        var serviceCatalog = await applicationDbContext.ServicesCatalog.FindAsync(id);
        
        if (serviceCatalog is null)
            return ResponseModel<bool>.Fail("Service not found", HttpStatusCode.NotFound);
        
        applicationDbContext.ServicesCatalog.Remove(serviceCatalog);
        var result= await applicationDbContext.SaveChangesAsync();
        if (result < 1)
            return ResponseModel<bool>.Fail("Error with saving to database", HttpStatusCode.InternalServerError);
        
        return ResponseModel<bool>.Success(true,"Service deleted successfully");
    }
}