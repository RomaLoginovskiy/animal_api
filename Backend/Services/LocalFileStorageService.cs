using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using camunda_challenge.Models;
using Microsoft.Extensions.Options;

namespace camunda_challenge.Services
{
    public class LocalFileStorageService : IBlobStorage
    {
        private readonly string _mediaLocation;

        public LocalFileStorageService(IOptions<AppSettings> appSettings){
            _mediaLocation = appSettings.Value.MediaLocation;
        }

        public Stream GetAnimalPictureStreamFromStorage(string fileName){
            var filePath = Path.Combine(_mediaLocation, fileName);
            return new FileStream(filePath, FileMode.Open, FileAccess.Read);
        }

        public async Task SaveAnimalPictureStreamToStorage(string fileName, string filePath, Stream content)
        {
            // Reset stream position to beginning before copying
            if (content.CanSeek)
            {
                content.Position = 0;
            }
            
            // Save file to disk
            using var fileStream = new FileStream(filePath, FileMode.Create);
            await content.CopyToAsync(fileStream);
        }
    }
}