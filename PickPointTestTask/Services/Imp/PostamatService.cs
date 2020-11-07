using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PickPointTestTask.Models.Entities;
using PickPointTestTask.Models.ViewModels;

namespace PickPointTestTask.Services.Imp
{
    public class PostamatService : IPostamatService
    {
        private readonly AppDbContext _context;

        public PostamatService(AppDbContext context)
        {
            _context = context;
        }

        public Task<List<PostamatViewModel>> GetAllPostamats()
            => _context.Postamats.Select(entity => (PostamatViewModel) entity).ToListAsync();

        public Task<PostamatEntity> GetByNumber(string number) => _context.Postamats.FirstOrDefaultAsync(entity => entity.Number == number);
    }
}