using System;

namespace URLShortener.Models
{
    public class ShortenedUrl
    {
        public int Id { get; set; }
        public string ShortenedPath { get; set; }
        public string TargetUrl { get; set; }
        public DateTime LastUseTime { get; set; }
        public int UseCount { get; set; }
    }
}