using System.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DTOs;
using WebApplication1.Exceptions;

namespace WebApplication1.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
        
    }


    public async Task<GetCustomerPurchaseDTO> GetPurchase(int id)
    {
        var purchases = await _context.Customers.Select(e => new GetCustomerPurchaseDTO()
        {
            CustomerId = e.CustomerId,
            FirstName = e.FirstName,
            LastName = e.LastName,
            PhoneNumber = e.PhoneNumber,
            Purchases = e.PurchaseHistory.Select(ep => new GetPurchaseDTO()
            {
                Date = ep.PurchaseDate,
                Rating = ep.Rating,
                Price = ep.AvailableProgram.Price,
                WashingMachine = new GetWashingMachineDTO()
                {
                    Serial = ep.AvailableProgram.WashingMachine.SerialNumber,
                    MaxWeight = ep.AvailableProgram.WashingMachine.MaxWeight,
                },
                Program = new GetProgramDTO()
                {
                    Name = ep.AvailableProgram.MyProgram.Name,
                    Duration = ep.AvailableProgram.MyProgram.DurationMinutes
                }
                
            }).ToList()
        }).FirstOrDefaultAsync(e => e.CustomerId == id);
        
        if(purchases is null) throw new NotFoundException();

        return purchases;

    }
}