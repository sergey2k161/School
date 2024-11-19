using School.Bussiness.Services.Interfaces;
using School.DataBase.Models.BaseModels;
using School.DataBase.Models.DTO;
using School.DataBase.Repositories.Interfaces;

namespace School.Bussiness.Services.Logic;

public class CabinetService : ICabinetService
{
    private readonly ICabinetRepository _cabinetRepository;
    
    public CabinetService(ICabinetRepository cabinetRepository)
    {
        _cabinetRepository = cabinetRepository;
    }
    
    public async Task CreateCabinet(CabinetDto model)
    {
        var cabinet = new Cabinet
        {
            Name = model.Name
        };
        await _cabinetRepository.CreateCabinet(cabinet);
    }

    public async Task UpdateCabinet(int id, CabinetDto model)
    {
        await _cabinetRepository.UpdateCabinet(id, model);
    }

    public async Task DeleteCabinet(int id)
    {
        await _cabinetRepository.DeleteCabinet(id);
    }

    public async Task<List<Cabinet>> GetAllCabinets()
    {
        return await _cabinetRepository.GetAllCabinets();
    }
}