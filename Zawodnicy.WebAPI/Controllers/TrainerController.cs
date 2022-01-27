using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zawodnicy.Infrastructure.Commands;
using Zawodnicy.Infrastructure.DTO;
using Zawodnicy.Infrastructure.Services;

namespace Zawodnicy.WebAPI.Controllers
{
    [Route("[Controller]")]
    public class TrainerController : Controller
    {
        private readonly ITrainerService _trainerService;

        public TrainerController(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }

        [HttpGet]
        public async Task<IActionResult> BrowseAll()
        {
            var z = await _trainerService.BrowseAll();
            return Json(z);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> BrowseTrainers(string lastName)
        {
            IEnumerable<TrainerDTO> trainers = await _trainerService.BrowseAllByFilterAsync(lastName);
            return Json(trainers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrainer(int id)
        {
            var trainer = await _trainerService.GetAsync(id);
            return Json(trainer);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddSkiJumper([FromBody] CreateTrainer trainer)
        {
            await _trainerService.AddAsync(trainer);
            return Created("", trainer);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> EditSkyJumper([FromBody] UpdateTrainer trainer, int id)
        {
            await _trainerService.UpdateAsync(id, trainer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteSkiJumper(int id)
        {
            await _trainerService.DelAsync(id);
            return NoContent();
        }
    }
}
