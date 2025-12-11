using Fines.Core.Dtos;
using Fines.Core.Enums;
using Fines.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fines.Api;

[Route("api/[controller]/[action]")]
[ApiController]
public class FinesController(IFinesService finesService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<FinesResponse>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<FinesResponse>>> GetFines()
    {
        try 
        {
            var fines = await finesService.GetFinesAsync();
            return Ok(fines ?? Enumerable.Empty<FinesResponse>());
        } 
        catch (Exception ex) 
        {
            // I would add a logger here for better error msg
            return StatusCode(500, ex.Message);
        }
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<FinesResponse>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<FinesResponse>>> GetFilteredFines(FineType? fineType, DateTime? fineDate, string? vehicleReg)
    {
        try
        {
            var fines = await finesService.GetFilteredFinesAsync(fineType, fineDate, vehicleReg);
            return Ok(fines);
        }
        catch (Exception ex)
        {
            // I would add a logger here for better error msg
            return StatusCode(500, ex.Message);
        }
    }
}