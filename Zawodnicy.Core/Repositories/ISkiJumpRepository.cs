using System.Collections.Generic;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;

namespace Zawodnicy.Core.Repositories
{
    public interface ISkiJumpRepository
    {
        Task<IEnumerable<SkiJump>> BrowseAllAsync();
        Task<SkiJump> GetAsync(int id);
        Task DelAsync(SkiJump s);
        Task UpdateAsync(SkiJump s);
        Task AddAsync(SkiJump s);
    }
}
