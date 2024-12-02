using School.DataBase.Models.BaseModels;
using School.DataBase.Models.DTO;

namespace School.Bussiness.Services.Interfaces;

public interface IAdminService
{
    Task CreateAdminAsync(AdminDto model);
    
    Task DeleteAdminAsync(int id);
}