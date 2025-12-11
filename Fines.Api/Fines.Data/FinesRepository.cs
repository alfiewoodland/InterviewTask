using Fines.Core.Enums;
using Fines.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Fines.Data;

public class FinesRepository(FinesDbContext context) : IFinesRepository
{
    public async Task<IEnumerable<FinesEntity>> GetAllFinesAsync()
    {
        return await context.Fines
            .Include(f => f.Vehicle)
            .ToListAsync();
    }

    public async Task<IEnumerable<FinesEntity>> GetFilteredFinesAsync(FineType? fineType, DateTime? fineDate, string? vehicleReg)
    {
        var fines = await context.Fines
            .Include(f => f.Vehicle)
            .Include(f => f.Customer)
            .ToListAsync();

        if (fineDate.HasValue)
            fines = fines.Where(f => f.FineDate == fineDate).ToList();
        
        if (!string.IsNullOrEmpty(vehicleReg))
            fines = fines.Where(f => f.Vehicle.RegistrationNumber.Contains(vehicleReg.Trim())).ToList();
        
        if (fineType.HasValue)
            fines = fines.Where(f => f.FineType == fineType.Value).ToList();

        return fines.ToList();
    }
}
