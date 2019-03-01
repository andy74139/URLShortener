using System;
using System.Linq;

namespace URLShortener.Services
{
    public class RandomShrotenedUrlGeneratorService
    {
        private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private static readonly Random Random = new Random();

        public string GetRandomShortenedPath(int length)
        {
            return new string(Enumerable.Repeat(Chars, length)
                .Select(s => s[Random.Next(s.Length)]).ToArray());
        }
    }
}
