using System;

namespace animal_api.Models
{
    public class AppSettings
    {
        public const string SectionName = "AppSettings";

        /// <summary>
        /// The location where animal pictures are stored
        /// </summary>
        public string MediaLocation { get; set; } = string.Empty;
    }
}
