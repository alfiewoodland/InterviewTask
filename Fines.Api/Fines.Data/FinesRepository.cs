using Fines.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Fines.Data;

public interface IFinesRepository
{
    Task<IEnumerable<FinesEntity>> GetAllFinesAsync();
}

public class FinesRepository : IFinesRepository
{
    private readonly FinesDbContext _context;

    public FinesRepository(FinesDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<FinesEntity>> GetAllFinesAsync()
    {
        return await _context.Fines.ToListAsync();
    }
}
