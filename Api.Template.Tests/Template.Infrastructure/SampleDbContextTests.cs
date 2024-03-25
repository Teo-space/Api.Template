using Api.Template.Domain.Basket;
using Api.Template.Infrastructure.EntityFrameworkCore.DbContexts;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace Api.Template.Tests.Template.Infrastructure;

internal class SampleDbContextTests
{
    private SampleDbContext dbContext;

    Guid ClientId = Guid.NewGuid();

    [SetUp]
    public void Setup()
    {
        var Options = new DbContextOptionsBuilder<SampleDbContext>()
            .UseSqlite("DataSource=file::memory:?cache=shared").Options;
            //.UseSqlite("DataSource=file.db").Options;

        dbContext = new SampleDbContext(Options);
        InitData();
    }

    private void InitData()
    {
        var basketPosition = new BasketPosition()
        {
            ClientId = ClientId,
            ProductTypeId = Guid.NewGuid(),
            ProductId = Guid.NewGuid(),
            ProductVariantId = Guid.NewGuid(),
            ProductVariantName = "Пицца офигенная",
            Quanity = 5
        };
        dbContext.BasketPositions.Add(basketPosition);
        dbContext.SaveChanges();
    }

    [TearDown]
    public void TearDown()
    {
        dbContext.Database.EnsureDeleted();
        dbContext.Dispose();
    }

    [Test]
    public void Test()
    {
        dbContext.BasketPositions.Count().Should().Be(1);
    }
}
