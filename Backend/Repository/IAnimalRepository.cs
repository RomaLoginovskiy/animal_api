using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using camunda_challenge.Models;

namespace camunda_challenge.Repository
{
    public interface IAnimalRepository
    {
        Task<Stream> GetAnimalPictureByTypeAsync(Animals type, int width, int height, CancellationToken cancellationToken);

        Task<Stream> GetLastInsertedAnimalPictureAsync(CancellationToken cancellationToken);
    
    }
}