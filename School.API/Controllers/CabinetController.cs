using Microsoft.AspNetCore.Mvc;
using School.Bussiness.Services.Interfaces;
using School.DataBase.Models.BaseModels;
using School.DataBase.Models.DTO;

namespace School.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CabinetController : ControllerBase
{
    private readonly ICabinetService _cabinetService;
    
    public CabinetController(ICabinetService cabinetService)
    {
        _cabinetService = cabinetService;
    }
    
    [HttpGet]
    public async Task<List<Cabinet>> GetAllCabinets()
    {
        return await _cabinetService.GetAllCabinets();
    }

    [HttpPost]
    public async Task<IActionResult> CreateCabinet(CabinetDto model)
    {
        await _cabinetService.CreateCabinet(model);
        return Ok();
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateCabinet(int id, CabinetDto model)
    {
        await _cabinetService.UpdateCabinet(id, model);
        return Ok();
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteCabinet(int id)
    {
        await _cabinetService.DeleteCabinet(id);
        return Ok();
    }
}