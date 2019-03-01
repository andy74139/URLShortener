using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using URLShortener.Models;

namespace URLShortener.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ShortenedUrlContext context)
        {
            context.Database.EnsureCreated();

            InitDefaultData_ShortenedUrls(context);
            InitDefaultData_UrlUseCount(context);
        }

        private static void InitDefaultData_ShortenedUrls(ShortenedUrlContext context)
        {
            if (context.ShortenedUrls.Any())
                return;

            var shortenedUrls = new ShortenedUrl[]
            {
                new ShortenedUrl {ShortenedPath = "Tes1", TargetUrl = "http://www.google.com", LastUseTime = new DateTime(2019, 3, 1, 1, 2, 3)},
                new ShortenedUrl {ShortenedPath = "Tes2", TargetUrl = "http://www.apple.com", LastUseTime = new DateTime(2019, 2, 28, 9, 30, 0)},
                new ShortenedUrl {ShortenedPath = "Tes3", TargetUrl = "http://www.youtube.com", LastUseTime = new DateTime(2019, 2, 28, 19, 31, 12)},
            };

            foreach (var shortenedUrl in shortenedUrls)
            {
                context.ShortenedUrls.Add(shortenedUrl);
            }
            context.SaveChanges();
        }
        private static void InitDefaultData_UrlUseCount(ShortenedUrlContext context)
        {
            if (context.UrlUseCounts.Any())
                return;

            var urlUseCounts = new UrlUseCount[]
            {
            };

            foreach (var urlUseCount in urlUseCounts)
            {
                context.UrlUseCounts.Add(urlUseCount);
            }
            context.SaveChanges();
        }
    }
}
