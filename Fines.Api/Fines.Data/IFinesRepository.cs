using Fines.Core.Enums;
using Fines.Data.Models;

public interface IFinesRepository
{
    Task<IEnumerable<FinesEntity>> GetAllFinesAsync(
        FineType? fineType,
        DateTime? startDate,
        DateTime? endDate,
        string? driverName,
        string? vehicleRegNo);
}