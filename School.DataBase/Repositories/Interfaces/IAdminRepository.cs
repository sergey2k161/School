using School.DataBase.Models.BaseModels;

namespace School.DataBase.Repositories.Interfaces;

public interface IAdminRepository
{
    Task CreateAdmin(Admin admin);
    
    Task RemoveAdmin(int id);
}