using System.Collections.Generic;
using System.Threading.Tasks;
using WinePicker.Shared.Models;

namespace WinePicker.Shared.Interfaces
{
    public interface IWineRepo
    {
        Task<List<WineModel>> GetAllWines();
    }
}