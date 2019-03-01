using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using URLShortener.Models;

namespace URLShortener.Data
{
    public class ShortenedUrlContext : DbContext
    {
        public ShortenedUrlContext(DbContextOptions<ShortenedUrlContext> options) : base(options)
        {
        }

        public DbSet<ShortenedUrl> ShortenedUrls { get; set; }
        public DbSet<UrlUseCount> UrlUseCounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShortenedUrl>().ToTable("ShortenedUrl");
            modelBuilder.Entity<UrlUseCount>().ToTable("UrlUseCount");
        }

        public async Task<IEnumerable<ShortenedUrl>> GetRecentShortenedUrls()
        {
            return await ShortenedUrls.OrderByDescending(url => url.LastUseTime).Take(10).ToListAsync();
        }

        public bool CreateShortenedUrl(string shortenedPath, string targetUrl)
        {
            if (ShortenedUrls.Any(u => u.ShortenedPath == shortenedPath))
                return false;

            ShortenedUrls.Add(new ShortenedUrl() { ShortenedPath = shortenedPath, TargetUrl = targetUrl });
            this.SaveChanges();
            return true;
        }


        public string GetTargetUrl(string shortenedPath)
        {
            var result = ShortenedUrls.FirstOrDefault(u => u.ShortenedPath == shortenedPath);
            if (result == null)
                return null;

            var today = GetToday();
            var urlUseCount = UrlUseCounts.FirstOrDefault(c => c.ShortenedUrlId == result.Id && c.Date == today);
            if (urlUseCount == null)
                UrlUseCounts.Add(new UrlUseCount {ShortenedUrlId = result.Id, Date = today, Count = 1});
            else
                urlUseCount.Count++;

            result.LastUseTime = GetNowTime();
            this.SaveChanges();

            return result.TargetUrl;
        }

        protected DateTime GetToday()
        {
            return DateTime.Now.Date;
        }

        protected DateTime GetNowTime()
        {
            return DateTime.Now;
        }
    }
}
