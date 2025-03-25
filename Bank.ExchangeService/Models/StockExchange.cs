namespace Bank.ExchangeService.Models;

public class StockExchange
{
    public required Guid     Id         { get; set; }
    public required string   Name       { get; set; }
    public required string   Acronym    { get; set; }
    public required DateTime CreatedAt  { get; set; }
    public required DateTime ModifiedAt { get; set; }
}
