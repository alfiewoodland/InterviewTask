using Fines.Core.Dtos;
using Fines.Core.Enums;
using Fines.Data;
using Fines.Data.Models;

namespace Fines.Services;

public class FinesService(IFinesRepository finesRepository) : IFinesService
{
    public async Task<IEnumerable<FinesResponse>> GetFinesAsync()
    {
        var fines = await finesRepository.GetAllFinesAsync();
        return fines.Select(MapToResponse);
    }

    public async Task<IEnumerable<FinesResponse>> GetFilteredFinesAsync(FineType? fineType, DateTime? fineDate, string? vehicleReg)
    {
        var fines = await finesRepository.GetFilteredFinesAsync(fineType, fineDate, vehicleReg);
        return fines.Select(MapToResponse);
    }

    private static FinesResponse MapToResponse(FinesEntity fine)
    {
        return new FinesResponse
        {
            Id = fine.Id,
            FineNo = fine.FineNo,
            FineDate = fine.FineDate,
            FineType = fine.FineType,
            VehicleRegNo = fine.Vehicle.RegistrationNumber,
            VehicleDriverName = fine.VehicleDriverName,
            CustomerName = $"{fine.Customer.FirstName} {fine.Customer.LastName}"
        };
    }
}
