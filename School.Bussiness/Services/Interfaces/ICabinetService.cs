using School.DataBase.Models.BaseModels;
using School.DataBase.Models.DTO;

namespace School.Bussiness.Services.Interfaces;

public interface ICabinetService
{
    Task CreateCabinet(CabinetDto model);
    
    Task UpdateCabinet(int id, CabinetDto model);
    
    Task DeleteCabinet(int id);
    
    Task<List<Cabinet>> GetAllCabinets();
}