using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Exceptions;
using WebApplication1.Services;


namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly IDbService _dbService;

    public CustomersController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("{id}/purchases")]
    public async Task<IActionResult> GetPurchase(int id)
    {
        try
        {
            var purchases = await _dbService.GetPurchase(id);
            return Ok(purchases);
        }
        catch (NotFoundException e)
        {
            return NotFound();
        }

        

    }

    
    
}