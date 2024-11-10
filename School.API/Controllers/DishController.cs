using Microsoft.AspNetCore.Mvc;
using School.Bussiness.Services.Interfaces;
using School.DataBase.Models.BaseModels;
using School.DataBase.Models.DTO;

namespace School.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class DishController : ControllerBase
{
    private readonly IDiningRoomService _diningRoomService;
    
    public DishController(IDiningRoomService diningRoomService)
    {
        _diningRoomService = diningRoomService;
    }
    
    [HttpPost("add")]
    public async Task<DiningRoom> CreateDish([FromBody]DiningRoomDTO diningRoom)
    {
        return await _diningRoomService.CreateDish(diningRoom);
    }
    
    [HttpGet("all")]
    public async Task<List<DiningRoom>> GetDishs()
    {
        return await _diningRoomService.GetDishs();
    }
    
    [HttpGet("by/{id}")]
    public async Task<DiningRoom> GetDishById(int id)
    {
        return await _diningRoomService.GetDishByIdAsync(id);
    }
    
    [HttpPut("update/{id}")]
    public async Task UpdateDish(int id, [FromBody]DiningRoomDTO model)
    {
        await _diningRoomService.UpdateDishById(id, model);
    }
    
    [HttpDelete("delete/{id}")]
    public async Task DeleteDish(int id)
    {
        await _diningRoomService.DeleteDish(id);
    }

    
}