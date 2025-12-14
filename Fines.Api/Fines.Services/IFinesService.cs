using Fines.Core.Dtos;
using Fines.Core.Enums;

public interface IFinesService
{
    Task<IEnumerable<FinesResponse>> GetFinesAsync(
        FineType? fineType,
        DateTime? startDate,
        DateTime? endDate,
        string? driverName,
        string? vehicleRegNo);
}
