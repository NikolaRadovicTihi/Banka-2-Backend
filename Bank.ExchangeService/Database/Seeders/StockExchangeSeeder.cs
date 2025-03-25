using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Bank.ExchangeService.Database.Seeders;

using StockExchangeModel = Models.StockExchange;

public static class StockExchangeSeeder
{
    public static async Task SeedStockExchanges(this DatabaseContext context)
    {
        if (context.StockExchanges.Any())
            return;

        var exchanges = ReadExchangesFromCsv();
        await context.StockExchanges.AddRangeAsync(exchanges);
        await context.SaveChangesAsync();
    }

    private static List<StockExchangeModel> ReadExchangesFromCsv()
    {
        var exchanges = new List<StockExchangeModel>();
        var now = DateTime.UtcNow;
        
        string baseDirectory    = AppContext.BaseDirectory;
        string projectDirectory = Directory.GetParent(baseDirectory)!.Parent!.Parent!.Parent!.FullName;
        string filePath         = Path.Combine(projectDirectory, "Database", "Seeders", "resources", "exchanges.csv");

        string[] lines = File.ReadAllLines(filePath);
        
        // Skip the header row
        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            
            // Handle CSV fields properly (especially those with commas inside quotes)
            string[] fields = ParseCsvLine(line);
            
            if (fields.Length >= 8)
            {
                var exchange = new StockExchangeModel
                {
                    Id = Guid.NewGuid(),
                    Name = fields[0],
                    Acronym = fields[1],
                    CreatedAt = now,
                    ModifiedAt = now
                };
                

                exchanges.Add(exchange);
            }
        }
        
        return exchanges;
    }

    // Helper method to parse CSV lines correctly, handling quoted fields
    private static string[] ParseCsvLine(string line)
    {
        List<string> result = new List<string>();
        bool inQuotes = false;
        string field = "";
        
        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];
            
            if (c == '"')
            {
                inQuotes = !inQuotes;
            }
            else if (c == ',' && !inQuotes)
            {
                result.Add(field);
                field = "";
            }
            else
            {
                field += c;
            }
        }
        result.Add(field);
        
        return result.ToArray();
    }
}