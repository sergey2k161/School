using School.DataBase.Models.BaseModels;
using School.DataBase.Models.DTO;

namespace School.DataBase.Repositories.Interfaces;

public interface ICabinetRepository
{
    Task CreateCabinet(Cabinet cabinet);
    
    Task UpdateCabinet(int id, CabinetDto cabinet);
    
    Task DeleteCabinet(int id);

    Task<List<Cabinet>> GetAllCabinets();
}