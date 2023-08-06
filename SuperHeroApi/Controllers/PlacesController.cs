using Microsoft.AspNetCore.Mvc;

namespace SuperHeroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {

        private static IPlaceRepository _placeRepository;

        public PlacesController(IPlaceRepository placeRepository)
        {
            _placeRepository = placeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPlaces()
        {
            var places = await _placeRepository.GetAllAsync();
            return Ok(places);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSinglePlace(int id)
        {
            var place = await _placeRepository.GetByIdAsync(id);

            if (place is null)
                return NotFound("Sorry, but this place doesn't exist");

            return Ok(place);
        }

        [HttpPost]
        public async Task<IActionResult> AddPlace(Place place)
        {
            var places = await _placeRepository.GetAllAsync();
            var placeExist = places.Where(p => p.City == place.City && p.Country == place.Country);

            if (placeExist is null)
                return NotFound("Sorry, but this place exist");

            _placeRepository.Insert(place);
            await _placeRepository.SaveChangesAsync();

            return Ok(place);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlace(int id, Place place)
        {
            var placeExist = await _placeRepository.GetByIdAsync(id);

            if (placeExist is null)
                return NotFound("Sorry, but this place doesn't exist");

            placeExist.City = place.City;
            placeExist.Country = place.Country;

            _placeRepository.Update(placeExist);
            await _placeRepository.SaveChangesAsync();

            return Ok(placeExist);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlace(int id)
        {
            var place = await _placeRepository.GetByIdAsync(id);

            if (place is null)
                return NotFound("Sorry, but this place doesn't exist");

            _placeRepository.Delete(place);
            await _placeRepository.SaveChangesAsync();

            return Ok(place);
        }
    }
}
