using Microsoft.AspNetCore.Mvc;
using School.Bussiness.Services.Interfaces;
using School.DataBase.Models.BaseModels;
using School.DataBase.Models.DTO;

namespace School.API.Controllers;

[ApiController]
[Route("api/[controller]")] // api/admin[]
public class AdminController : ControllerBase
{
    private readonly IAdminService _adminService;
    
    public AdminController(IAdminService adminService)
    {
        _adminService = adminService;
    }
    
    [HttpPost]
    public async Task CreateAdminAsync([FromBody] AdminDto model)
    {
        await _adminService.CreateAdminAsync(model);
    }
    
    [HttpDelete]
    public async Task DeleteAdminAsync([FromQuery] int id)
    {
        await _adminService.DeleteAdminAsync(id);
    }
}