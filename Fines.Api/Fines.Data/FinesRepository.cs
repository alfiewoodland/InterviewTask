using Fines.Core.Enums;
using Fines.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Fines.Data;

public class FinesRepository : IFinesRepository
{
    private readonly FinesDbContext _context;

    public FinesRepository(FinesDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<FinesEntity>> GetAllFinesAsync(
        FineType? fineType,
        DateTime? startDate,
        DateTime? endDate,
        string? driverName,
        string? vehicleRegNo)
    {
        IQueryable<FinesEntity> query = _context.Fines
        .Include(f => f.Vehicle);

        if (fineType.HasValue)
        {
            query = query.Where(f => f.FineType == fineType.Value);
        }

        if (startDate.HasValue)
        {
            query = query.Where(f => f.FineDate >= startDate.Value);
        }

        if (endDate.HasValue)
        {
            var endOfDay = endDate.Value.Date.AddDays(1).AddTicks(-1);
            query = query.Where(f => f.FineDate <= endOfDay);
        }

        if (!string.IsNullOrWhiteSpace(driverName))
        {
            query = query.Where(f =>
                f.VehicleDriverName.ToLower().Contains(driverName.ToLower()));
        }

        if (!string.IsNullOrWhiteSpace(vehicleRegNo))
        {
            query = query.Where(f =>
                f.Vehicle.RegistrationNumber.ToLower().Contains(vehicleRegNo.ToLower()));
        }

        return await query.ToListAsync();
    }
}
