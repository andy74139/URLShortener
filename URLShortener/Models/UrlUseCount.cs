using System;

namespace URLShortener.Models
{
    public class UrlUseCount
    {
        public int Id { get; set; }
        public int ShortenedUrlId { get; set; }
        public DateTime Date { get; set; }
        public int Count { get; set; }
    }
}