using Api.Template.Domain.Basket;
using Api.Template.Infrastructure.EntityFrameworkCore.DbContexts;
using Api.Template.Interfaces.Services;
using Api.Template.Services;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace Api.Template.Tests.Template.Services.BasketSeviceTests;

public class GetBasketByClientTest
{
    private SampleDbContext dbContext;
    IBasketSevice basketSevice;

    [SetUp]
    public void Setup()
    {
        var Options = new DbContextOptionsBuilder<SampleDbContext>()
            .UseSqlite("DataSource=file::memory:?cache=shared").Options;
            //.UseSqlite("DataSource=file.db").Options;

        dbContext = new SampleDbContext(Options);

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
        basketSevice = new BasketSevice(dbContext);
    }

    [TearDown] 
    public void TearDown()
    {
        dbContext.Database.EnsureDeleted();
        dbContext.Dispose();
    }


    Guid ClientId = Guid.NewGuid();

    [Test]
    public async Task GetPositionsOkTest()
    {
        var result = await basketSevice.GetBasketByClient(ClientId);
        result.Should().NotBeNull();
        result.Positions.Should().HaveCount(1);
    }
}
