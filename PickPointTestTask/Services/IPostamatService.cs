using System.Collections.Generic;
using System.Threading.Tasks;
using PickPointTestTask.Models.Entities;
using PickPointTestTask.Models.ViewModels;

namespace PickPointTestTask.Services
{
    public interface IPostamatService
    {
        Task<List<PostamatViewModel>> GetAllPostamats();
        Task<PostamatEntity> GetByNumber(string number);
    }
}