using System;
using System.Formats.Asn1;
using System.Linq;
using System.Threading.Tasks;
using Domain.Aggregates.PassengerAggregate;
using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PassengerRepository : IPassengerRepository
{
    private readonly FlightsContext _context;
    
    public IUnitOfWork UnitOfWork
    {
        get { return _context; }
    }
    
    public PassengerRepository(FlightsContext context)
    {
        _context = context;
    }
    
    public async Task<Passenger> GetAsync(Guid id)
    {
        return await _context.Passengers.FirstOrDefaultAsync(p => p.Id == id);
    }

    public Passenger GetById(Guid id)
    {
        return _context.Passengers.FirstOrDefault(p => p.Id == id);
    }
    
    public Passenger GetByEmail(string email)
    {
        return _context.Passengers.FirstOrDefault(p => p.Email == email);
    }

    public Passenger Add(Passenger passenger)
    {
        return _context.Passengers.Add(passenger).Entity;
    }

    public void Update(Passenger passenger)
    {
        _context.Passengers.Update(passenger);
    }
}