using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroApi.Repository;

namespace SuperHeroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {

        private static ISuperHeroRepository _superHeroRepository;
        public SuperHeroController(ISuperHeroRepository superHeroRepository)
        {
            _superHeroRepository = superHeroRepository;            
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHeroes()
        {
            var superHeroes = _superHeroRepository.GetSuperHeroesAndPlace();

            return Ok(superHeroes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleHero(int id)
        {
            var superHero = await _superHeroRepository.GetByIdAsync(id);

            if (superHero is null)
                return NotFound("Sorry, but this hero doesn't exist");

            return Ok(superHero);
        }

        [HttpPost]
        public async Task<IActionResult> AddHero(SuperHero hero)
        {
            var superHeroes = await _superHeroRepository.GetAllAsync();
            var superHero = superHeroes.Where(super => super.Name == hero.Name);

            if (superHero is null)
                return NotFound("Sorry, but this hero exist");

            _superHeroRepository.Insert(hero);
            await _superHeroRepository.SaveChangesAsync();

            return Ok(hero);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHero(int id, SuperHero request)
        {
            var superHero = await _superHeroRepository.GetByIdAsync(id);

            if (superHero is null)
                return NotFound("Sorry, but this hero doesn't exist");

            superHero.Name = request.Name;
            superHero.FirstName = request.FirstName;
            superHero.LastName = request.LastName;
            superHero.Place = request.Place;

            _superHeroRepository.Update(superHero);
            await _superHeroRepository.SaveChangesAsync();

            return Ok(superHero);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHero(int id)
        {
            var superHero = await _superHeroRepository.GetByIdAsync(id);

            if (superHero is null)
                return NotFound("Sorry, but this hero doesn't exist");

            _superHeroRepository.Delete(superHero);
            await _superHeroRepository.SaveChangesAsync();

            return Ok(superHero);
        }
    }
}
