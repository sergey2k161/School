using Microsoft.AspNetCore.Mvc;
using School.Bussiness.Services.Interfaces;
using School.DataBase.Models.BaseModels;
using School.DataBase.Repositories.Interfaces;

namespace School.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DisciplineController : ControllerBase
{
    private readonly IDisciplineService _disciplineService;

    public DisciplineController(IDisciplineService disciplineService)
    {
        _disciplineService = disciplineService;
    }
    
    [HttpGet]
    public async Task<List<Discipline>> GetAllDisciplines()
    {
        return await _disciplineService.GetAllDisciplines();
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateDiscipline([FromBody]DisciplineDto model)
    {
        await _disciplineService.CreateDiscipline(model);
        return Ok();
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateDiscipline(int id, [FromBody]DisciplineDto model)
    {
        await _disciplineService.UpdateDiscipline(id, model);
        return Ok();
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteDiscipline(int id)
    {
        await _disciplineService.DeleteDiscipline(id);
        return Ok();
    }
}