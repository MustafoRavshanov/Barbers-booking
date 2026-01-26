using AutoMapper;
using Barber.Domain.DTOs;
using Barber.Domain.Entities;
using Barber.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Barber.Service.Services.Barber;

public class BarberService(ApplicationDbContext applicationDbContext, IMapper mapper):IBarberService
{
    public async ValueTask<BarbersDto> AddBarberAsync(BarbersDto barberDto)
    {
        Barbers barber = mapper.Map<Barbers>(barberDto);
        await applicationDbContext.AddAsync(barber);
        await applicationDbContext.SaveChangesAsync();
        
        BarbersDto newBarberDto=mapper.Map<BarbersDto>(barber);
        return newBarberDto;
    }

    public IQueryable<BarbersDto> RetrieveAllBarbers()
    {
        List<BarbersDto> barbersDto = new();
        foreach (Barbers barber in applicationDbContext.Barbers)
        {
            barbersDto.Add(mapper.Map<BarbersDto>(barber));
        }
        
        return barbersDto.AsQueryable();
    }

    public async ValueTask<BarbersDto> RetrieveBarberById(Guid id)
    {
        Barbers? barber = await applicationDbContext.Barbers.FirstOrDefaultAsync(x=>x.Id == id);
        BarbersDto barberDto=mapper.Map<BarbersDto>(barber);
        return barberDto;
    }

    public async ValueTask<BarbersDto> ModifyBarberAsync(BarbersDto barberDto, Guid id)
    {
        Barbers? barber = await applicationDbContext.Barbers.FirstOrDefaultAsync(x=>x.Id == id);
        if (barber is null)
        {
            throw new Exception("Barber is not found");
        }
        
        Barbers updatedBarber = mapper.Map<Barbers>(barberDto);
        updatedBarber.Id = barber.Id;
        
        applicationDbContext.Barbers.Update(updatedBarber);
        await applicationDbContext.SaveChangesAsync();
        
        BarbersDto newBarberDto=mapper.Map<BarbersDto>(updatedBarber);
        return newBarberDto;
    }
}