using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zawodnicy.Infrastructure.Commands;
using Zawodnicy.Infrastructure.DTO;

namespace Zawodnicy.Infrastructure.Services
{
    public interface ISkiJumperService
    {
        Task<IEnumerable<SkiJumperDTO>> BrowseAll();
        Task<IEnumerable<SkiJumperDTO>> BrowseAllByFilterAsync(string country, string name);
        Task<IEnumerable<SkiJumperDTO>> BrowseAllByFilterAsync(string country);
        Task<SkiJumperDTO> GetAsync(int id);
        Task DelAsync(int id);
        Task UpdateAsync(int id, UpdateSkiJumper s);
        Task AddAsync(CreateSkiJumper s);
    }
}
