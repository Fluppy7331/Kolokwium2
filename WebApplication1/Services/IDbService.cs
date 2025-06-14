using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;

namespace WebApplication1.Services;

public interface IDbService
{
    Task<GetCustomerPurchaseDTO> GetPurchase(int id);
}