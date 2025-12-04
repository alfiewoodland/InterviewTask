using Fines.Core.Dtos;
using Fines.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fines.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FinesController : ControllerBase
{
    private readonly IFinesService _finesService;

    public FinesController(IFinesService finesService)
    {
        _finesService = finesService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<FinesResponse>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<FinesResponse>>> GetFines()
    {
        var fines = await _finesService.GetFinesAsync();
        return Ok(fines);
    }
}