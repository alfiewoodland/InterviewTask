using Fines.Core.Dtos;
using Fines.Core.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Fines.Api;

/// <summary>
/// Provides endpoints to retrieve fines.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class FinesController : ControllerBase
{
    private readonly IFinesService _finesService;

    public FinesController(IFinesService finesService)
    {
        _finesService = finesService;
    }

    /// <summary>
    /// Returns fines optionally filtered by fine type, date range, driver name, and vehicle registration.
    /// </summary>
    /// <param name="fineType">Optional fine type filter.</param>
    /// <param name="startDate">Optional start date (inclusive).</param>
    /// <param name="endDate">Optional end date (inclusive).</param>
    /// <param name="driverName">Optional driver name substring (case-insensitive).</param>
    /// <param name="vehicleRegNo">Optional vehicle registration substring (case-insensitive).</param>
    /// <returns>Filtered list of fines.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<FinesResponse>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<FinesResponse>>> GetFines(
        [FromQuery] FineType? fineType,
        [FromQuery] DateTime? startDate,
        [FromQuery] DateTime? endDate,
        [FromQuery] string? driverName,
        [FromQuery] string? vehicleRegNo)
    {
        if (startDate.HasValue && endDate.HasValue && startDate > endDate)
        {
            return BadRequest("startDate cannot be after endDate");
        }

        var fines = await _finesService.GetFinesAsync(
            fineType,
            startDate,
            endDate,
            driverName,
            vehicleRegNo);

        return Ok(fines);
    }
}
