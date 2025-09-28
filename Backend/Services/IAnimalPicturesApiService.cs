using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace animal_api.Services
{
    public interface IAnimalPicturesApiService
    {
        Task<Stream> FetchAnimalPictureStreamFromApi(Enum type, int width, int height);
    }
}