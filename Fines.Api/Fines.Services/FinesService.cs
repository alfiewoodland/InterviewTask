using Fines.Core.Dtos;
using Fines.Core.Enums;
using Fines.Data.Models;

namespace Fines.Services;

public class FinesService : IFinesService
{
    private readonly IFinesRepository _finesRepository;

    public FinesService(IFinesRepository finesRepository)
    {
        _finesRepository = finesRepository;
    }

    public async Task<IEnumerable<FinesResponse>> GetFinesAsync(
        FineType? fineType,
        DateTime? startDate,
        DateTime? endDate,
        string? driverName,
        string? vehicleRegNo)
    {
        var fines = await _finesRepository.GetAllFinesAsync(
            fineType,
            startDate,
            endDate,
            driverName,
            vehicleRegNo);

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
            VehicleDriverName = fine.VehicleDriverName
        };
    }
}
