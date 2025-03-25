using Bank.Application.Domain;
using Bank.UserService.Models;

namespace Bank.ExchangeService.Models;

public class Actuary
{
    public int Id { get; set; }
    
    public required Guid  UserId { get; set; }
    public required User  User { get; set; }
    
    public decimal? Limit { get; set; }
    
    public required decimal UsedLimit { get; set; }
    
    public required bool NeedApproval { get; set; }
    
    public required ActuaryType Type { get; set; }
    
    public required DateTime CreatedAt  { get; set; }
    public required DateTime ModifiedAt { get; set; }
    
}
