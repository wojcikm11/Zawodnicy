using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;
using Zawodnicy.Core.Repositories;
using Zawodnicy.Infrastructure.Commands;
using Zawodnicy.Infrastructure.DTO;

namespace Zawodnicy.Infrastructure.Services
{
    public class TrainerService : ITrainerService
    {
        private readonly ITrainerRepository _trainerRepository;

        public TrainerService(ITrainerRepository trainerRepository)
        {
            _trainerRepository = trainerRepository;
        }

        public async Task AddAsync(CreateTrainer t)
        {
            await _trainerRepository.AddAsync(Map(t));
        }

        public async Task<IEnumerable<TrainerDTO>> BrowseAll()
        {
            var trainers = await _trainerRepository.BrowseAllAsync();
            return trainers.Select(x => Map(x));
        }

        public async Task<IEnumerable<TrainerDTO>> BrowseAllByFilterAsync(string lastName)
        {
            var trainers = await _trainerRepository.BrowseAllByFilterAsync(lastName);
            return trainers.Select(x => Map(x));
        }

        public async Task DelAsync(int id)
        {
            var trainer = _trainerRepository.GetAsync(id).Result;
            await _trainerRepository.DelAsync(trainer);
        }

        public async Task<TrainerDTO> GetAsync(int id)
        {
            return await Task.FromResult(Map(_trainerRepository.GetAsync(id).Result));
        }

        public async Task UpdateAsync(int id, UpdateTrainer t)
        {
            await _trainerRepository.UpdateAsync(Map(t, id));
        }

        private TrainerDTO Map(Trainer t)
        {
            return new TrainerDTO()
            {
                Id = t.Id,
                FirstName = t.FirstName,
                LastName = t.LastName,
                BirthDate = t.BirthDate
            };
        }

        private Trainer Map(CreateTrainer t)
        {
            return new Trainer()
            {
                FirstName = t.FirstName,
                LastName = t.LastName,
                BirthDate = t.BirthDate
            };
        }

        private Trainer Map(UpdateTrainer t, int id)
        {
            return new Trainer()
            {
                Id = id,
                FirstName = t.FirstName,
                LastName = t.LastName,
                BirthDate = t.BirthDate
            };
        }
    }
}
