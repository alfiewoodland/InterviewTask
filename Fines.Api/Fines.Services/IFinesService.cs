using Fines.Core.Dtos;
using Fines.Core.Enums;

namespace Fines.Services;

public interface IFinesService
{
    Task<IEnumerable<FinesResponse>> GetFinesAsync();

    Task<IEnumerable<FinesResponse>> GetFilteredFinesAsync(FineType? fineType, DateTime? fineDate, string? vehicleReg);
}