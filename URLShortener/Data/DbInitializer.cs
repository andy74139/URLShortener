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
                new ShortenedUrl {ShortenedPath = "Test", TargetUrl = "http://www.google.com"},
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
