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
    }
}
