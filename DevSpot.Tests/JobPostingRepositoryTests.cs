using DevSpot.Data;
using DevSpot.Models;
using DevSpot.Repositories;
using Microsoft.EntityFrameworkCore;
using NuGet.ContentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSpot.Tests
{
    public class JobPostingRepositoryTests
    {
        private readonly DbContextOptions<ApplicationDbContext> _options;
        public JobPostingRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
        }
        private ApplicationDbContext CreateDbContext() => new ApplicationDbContext(_options);

        [Fact]
        public async Task AddAsync_SouldAddJobPosting()
        {
            var db = CreateDbContext();

            var repo = new JobPostingRepository(db);

            var jobPosting = new JobPosting
            {
                Title = "Test Job",
                Description = "Test Description",
                PostedDate = DateTime.UtcNow,
                Company = "Test Company",
                Lacation = "Test Location",
                UserId = "TestUserId"
            };
            await repo.AddAsync(jobPosting);

            var result = db.JobPostings.SingleOrDefault(x => x.Title == "Test Job");
            
            Assert.NotNull(result);
            Assert.Equal("Test Job", result.Title);
            Assert.Equal("Test Description", result.Description);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnJobPosting()
        {
            var db = CreateDbContext();

            var repo = new JobPostingRepository(db);

            var jobPosting = new JobPosting
            {
                Title = "Test Job",
                Description = "Test Description",
                PostedDate = DateTime.UtcNow,
                Company = "Test Company",
                Lacation = "Test Location",
                UserId = "TestUserId"
            };
            await db.JobPostings.AddAsync(jobPosting);
            await db.SaveChangesAsync();

            var result = await repo.GetByIdAsync(jobPosting.Id);

            Assert.NotNull(result);
            Assert.Equal("Test Job", result.Title);
        }
        [Fact]
        public async Task GetByIdAsync_ShouldThrowKeyNotFoundException()
        {
            var db = CreateDbContext();
            var repo = new JobPostingRepository(db);
            await Assert.ThrowsAsync<KeyNotFoundException>(async () => await repo.GetByIdAsync(999));
        }
        [Fact]
        public async Task GetAllAsync_ShouldReturnAllJobPostings()
        {
            var db = CreateDbContext();

            var repo = new JobPostingRepository(db);

            var jobPosting = new JobPosting
            {
                Title = "Test Job",
                Description = "Test Description",
                PostedDate = DateTime.UtcNow,
                Company = "Test Company",
                Lacation = "Test Location",
                UserId = "TestUserId"
            };

            var jobPosting2 = new JobPosting
            {
                Title = "Test Job 2",
                Description = "Test Description",
                PostedDate = DateTime.UtcNow,
                Company = "Test Company",
                Lacation = "Test Location",
                UserId = "TestUserId"
            };
            await db.JobPostings.AddRangeAsync(jobPosting, jobPosting2);
            await db.SaveChangesAsync();
            var result = await repo.GetAllAsync();
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }
        [Fact]
        public async Task UpateAsync_ShouldUpdateJobPosting()
        {
            var db = CreateDbContext();

            var repo = new JobPostingRepository(db);

            var jobPosting = new JobPosting
            {
                Title = "Test Job",
                Description = "Test Description",
                PostedDate = DateTime.UtcNow,
                Company = "Test Company",
                Lacation = "Test Location",
                UserId = "TestUserId"
            };

            await db.JobPostings.AddAsync(jobPosting);
            await db.SaveChangesAsync();

            jobPosting.Title = "Updated Job";
            await repo.UpdateAsync(jobPosting);

            var result = db.JobPostings.Find(jobPosting.Id);

            Assert.NotNull(result);
            Assert.Equal("Updated Job", result.Title);
        }

        [Fact]
        public async Task DeleteAsync_ShouldDeleteJobPosting()
        {
            var db = CreateDbContext();

            var repo = new JobPostingRepository(db);

            var jobPosting = new JobPosting
            {
                Title = "Test Job",
                Description = "Test Description",
                PostedDate = DateTime.UtcNow,
                Company = "Test Company",
                Lacation = "Test Location",
                UserId = "TestUserId"
            };
            await db.JobPostings.AddAsync(jobPosting);
            await db.SaveChangesAsync();

            await repo.DeleteAsync(jobPosting.Id);

            var result = db.JobPostings.Find(jobPosting.Id);

            Assert.Null(result);
        }
    }
}
