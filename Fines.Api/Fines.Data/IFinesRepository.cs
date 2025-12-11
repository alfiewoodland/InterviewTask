using Fines.Core.Enums;
using Fines.Data.Models;

namespace Fines.Data;

public interface IFinesRepository
{
    Task<IEnumerable<FinesEntity>> GetAllFinesAsync();
    
    Task<IEnumerable<FinesEntity>> GetFilteredFinesAsync(FineType? fineType, DateTime? fineDate, string? vehicleReg);

}