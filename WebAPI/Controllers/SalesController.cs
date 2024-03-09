using Microsoft.AspNetCore.Mvc;
using OzonSales.Business.Abstractions;
using OzonSales.Types.Commands;

namespace OzonSales.WebAPI.Controllers;

[ApiController]
[Route("api/sales")]
public class SalesController : Controller
{
    private readonly ISalesService _sales;

    public SalesController(ISalesService sales)
    {
        _sales = sales;
    }

    [HttpGet("ads/{id}")]
    public async Task<IActionResult> GetAdsAsync(ulong id)
    {
        var command = new Command { Id = id };
        var result = await _sales.GetADSAsync(command);
        return result != null ? Ok(result) : BadRequest("ADS not calculated");
    }

    [HttpGet("prediction/{id}")]
    public async Task<IActionResult> GetPredictionAsync(ulong id, [FromQuery] uint days)
    {
        var command = new Command { Id = id, Days = days };
        var result = await _sales.GetPredictionAsync(command);
        return result != null ? Ok(result) : BadRequest("Prediction not calculated");
    }
    
    [HttpGet("demand/{id}")]
    public async Task<IActionResult> GetDemandAsync(ulong id, [FromQuery] uint days)
    {
        var command = new Command { Id = id, Days = days };
        var result = await _sales.GetDemandAsync(command);
        return result != null ? Ok(result) : BadRequest("Prediction not calculated");
    }
}