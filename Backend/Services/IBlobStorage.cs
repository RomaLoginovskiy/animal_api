using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace animal_api.Services
{
    public interface IBlobStorage
    {
        Stream GetAnimalPictureStreamFromStorage(string fileName);

        Task SaveAnimalPictureStreamToStorage(string fileName, string filePath, Stream content);
    }
}