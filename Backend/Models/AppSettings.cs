using System;

namespace camunda_challenge.Models
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
