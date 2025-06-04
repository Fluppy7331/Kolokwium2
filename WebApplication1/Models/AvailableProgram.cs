using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

[Table("Available_Program")]
public class AvailableProgram
{
    [Key]
    public int AvailableProgramId { get; set; }
    [ForeignKey(nameof(Models.WashingMachine))]
    public int WashingMachineId { get; set; }
    public WashingMachine WashingMachine { get; set; } = null!;
    
    [ForeignKey(nameof(Models.MyProgram))]
    public int ProgramId { get; set; }
    public MyProgram MyProgram { get; set; } = null!;
    
    [Column(TypeName = "numeric")]
    [Precision(10, 2)]
    public decimal Price { get; set; }
}