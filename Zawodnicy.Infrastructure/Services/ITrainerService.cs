using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zawodnicy.Infrastructure.Commands;
using Zawodnicy.Infrastructure.DTO;

namespace Zawodnicy.Infrastructure.Services
{
    public interface ITrainerService
    {
        Task<IEnumerable<TrainerDTO>> BrowseAll();
        Task<IEnumerable<TrainerDTO>> BrowseAllByFilterAsync(string lastName);
        Task<TrainerDTO> GetAsync(int id);
        Task DelAsync(int id);
        Task UpdateAsync(int id, UpdateTrainer t);
        Task AddAsync(CreateTrainer t);
    }
}
