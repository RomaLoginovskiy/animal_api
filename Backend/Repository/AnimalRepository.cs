using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using camunda_challenge.Models;
using camunda_challenge.Services;
using camunda_challenge.Data;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

namespace camunda_challenge.Repository
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly string _mediaLocation;
        private readonly IAnimalPicturesApiService _animalPicturesApiService;
        private readonly IBlobStorage _blobStorage;
        private readonly AnimalDbContext _dbContext;

        public AnimalRepository(IOptions<AppSettings> appSettings, 
        IAnimalPicturesApiService animalPicturesApiService, 
        IBlobStorage blobStorage,
        AnimalDbContext dbContext)
        {
            _mediaLocation = appSettings.Value.MediaLocation;
            _animalPicturesApiService = animalPicturesApiService;
            _blobStorage = blobStorage;
            _dbContext = dbContext;
        }
        
        public async Task<Stream> GetAnimalPictureByTypeAsync(Animals type, int width, int height, CancellationToken cancellationToken)
        {
            
                    
            var animalPictureStream = await _animalPicturesApiService.FetchAnimalPictureStreamFromApi(type, 100, 100);

            var fileName = $"{Guid.NewGuid()}_{type}.jpg";

            var animalPicture = new AnimalPicture(){
                AnimalType = type,
                FileName = fileName,
                Format = "jpg",
                DateUploaded = DateTime.UtcNow,          
                FilePath = Path.Combine(_mediaLocation, fileName)
            };

            await SaveAnimalPictureAsync(animalPicture, animalPictureStream, cancellationToken);

            // Return a fresh stream from the saved file instead of the original stream
            return GetAnimaPictureStreamByFileName(fileName, cancellationToken);
        }

        private async Task<AnimalPicture> SaveAnimalPictureAsync(AnimalPicture animalPicture, Stream content, CancellationToken cancellationToken)
        {
            // Ensure media directory exists
            Directory.CreateDirectory(_mediaLocation);

            // Generate unique filename

            await _blobStorage.SaveAnimalPictureStreamToStorage(animalPicture.FileName, animalPicture.FilePath, content);

            // Save to database
            _dbContext.AnimalPictures.Add(animalPicture);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return animalPicture;
        }
        private  Stream GetAnimaPictureStreamByFileName(string fileName, CancellationToken cancellationToken)
        {
            var stream = _blobStorage.GetAnimalPictureStreamFromStorage(fileName);
            return stream;
        }

        public async Task<Stream> GetLastInsertedAnimalPictureAsync(CancellationToken cancellationToken){

            var animalPicture= await _dbContext.AnimalPictures.OrderByDescending(picture => picture.DateUploaded).FirstOrDefaultAsync();
            if (animalPicture == null)
            {
                return null;
            }
            var stream = _blobStorage.GetAnimalPictureStreamFromStorage(animalPicture.FileName);
            return stream;
        }
    }
}