using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace animal_api.Services
{
    public class AnimalPicturesRestService : IAnimalPicturesApiService
    {
        public async Task<Stream> FetchAnimalPictureStreamFromApi(Enum type, int width, int height)
        {
            using HttpClient client = new HttpClient();
            
            // Use different APIs based on animal type
            string url = type.ToString().ToLower() switch
            {
                "dog" => $"https://place.dog/{width}/{height}",
                "duck" => "https://random-d.uk/api/random",
                "elephant" => $"https://picsum.photos/{width}/{height}",
                "bear" => $"https://placebear.com/{width}/{height}",
                _ => $"https://picsum.photos/{width}/{height}"
            };

            // For duck API, we need to get the JSON response first to get the actual image URL
            if (type.ToString().ToLower() == "duck")
            {
                var jsonResponse = await client.GetStringAsync(url);
                var duckData = JsonSerializer.Deserialize<DuckApiResponse>(jsonResponse);
                if (duckData?.url != null)
                {
                    return await client.GetStreamAsync(duckData.url);
                }
            }
            
            // For other APIs, get the image directly
            return await client.GetStreamAsync(url);
        }
        
        private class DuckApiResponse
        {
            public string? message { get; set; }
            public string? url { get; set; }
        }
    }
}