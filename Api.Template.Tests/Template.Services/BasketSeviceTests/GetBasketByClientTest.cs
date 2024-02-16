using Api.Template.Domain.Basket;
using Api.Template.Infrastructure.EntityFrameworkCore.DbContexts;
using Api.Template.Services.Interfaces;
using Api.Template.Services.Services;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace Api.Template.Tests.Template.Services.BasketSeviceTests;

public class GetBasketByClientTest
{
    SampleDbContext dbContext;
    IBasketSevice basketSevice;

    [SetUp]
    public void Setup()
    {
        var Options = new DbContextOptionsBuilder<SampleDbContext>().UseInMemoryDatabase($"DbContext_{Guid.NewGuid()}").Options;
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

    Guid ClientId = Guid.NewGuid();

    [Test]
    public async Task GetPositionsOkTest()
    {
        var result = await basketSevice.GetBasketByClient(ClientId);
        result.Should().NotBeNull();
        result.Positions.Should().HaveCount(1);
    }
}
