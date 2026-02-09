using System;
using Xunit;
using Microsoft.EntityFrameworkCore;
using MinhaApi.Data;

namespace MinhaApi.Tests.Data
{
    public class AppDbContextTests
    {
        [Fact]
        public void PodeCriarInstancia()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using var context = new AppDbContext(options);
            Assert.NotNull(context);
        }
    }
}