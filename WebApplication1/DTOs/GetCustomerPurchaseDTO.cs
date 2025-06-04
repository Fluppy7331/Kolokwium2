namespace WebApplication1.DTOs;

public class GetCustomerPurchaseDTO
{
    public int CustomerId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public ICollection<GetPurchaseDTO> Purchases = null!;
}

public class GetPurchaseDTO
{
    public DateTime Date  { get; set; }
    public int? Rating { get; set; }
    public decimal Price { get; set; }
    
    public GetWashingMachineDTO WashingMachine { get; set; } = null!;
    public GetProgramDTO Program { get; set; } = null!;
}

public class GetWashingMachineDTO
{
    public string Serial { get; set; } = null!;
    public decimal MaxWeight { get; set; }
}
public class GetProgramDTO
{
    public string Name { get; set; } = null!;
    public int Duration { get; set; }
}