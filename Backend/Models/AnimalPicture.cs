using System;
using System.ComponentModel.DataAnnotations;

namespace animal_api.Models
{
    public class AnimalPicture
    {
        [Key]
        public int Id { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string Format { get; set; } = string.Empty;
        public DateTime DateUploaded { get; set; }
        public Animals? AnimalType { get; set; }
        public string? FilePath { get; set; }
    }
}
