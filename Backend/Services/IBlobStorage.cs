using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace camunda_challenge.Services
{
    public interface IBlobStorage
    {
        Stream GetAnimalPictureStreamFromStorage(string fileName);

        Task SaveAnimalPictureStreamToStorage(string fileName, string filePath, Stream content);
    }
}