using camunda_challenge.Models;
using camunda_challenge.Repository;
using camunda_challenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace camunda_challenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IAnimalPicturesApiService _animalPicturesApiService;

        public AnimalController(IAnimalRepository animalRepository, IAnimalPicturesApiService animalPicturesApiService)
        {
            _animalRepository = animalRepository;
            _animalPicturesApiService = animalPicturesApiService;
        }
        /// <summary>
        /// Get animal picture by type
        /// </summary>
        /// <returns>Binary image data (JPEG format)</returns>
        [HttpGet("picture/")]
        public async Task<IActionResult> GetAnimalPicturesByType([FromQuery] String type, 
        [FromQuery] int width, [FromQuery] int height, CancellationToken cancellationToken = default)
        {
           
                string typeLower = type.ToLower();
                
                var imageStream = await _animalRepository
                .GetAnimalPictureByTypeAsync(Enum.Parse<Animals>(type.ToLower()), width, height, cancellationToken);

                if (imageStream == null)
                {
                    return NotFound("Animal picture not found");
                }

                // Return the image as binary data with appropriate content type
                return File(imageStream, "image/jpeg");

        }


        [HttpGet("last")]
        public async Task<IActionResult> GetLastInsertedAnimalPicture(CancellationToken cancellationToken = default)
        {
            var imageStream = await _animalRepository.GetLastInsertedAnimalPictureAsync(cancellationToken);
            return File(imageStream, "image/jpeg");
        }

    }
}