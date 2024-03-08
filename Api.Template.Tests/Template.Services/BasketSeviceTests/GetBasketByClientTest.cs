using Api.Template.Domain.Basket;
using Api.Template.Infrastructure.EntityFrameworkCore.DbContexts;
using Api.Template.Services.Interfaces;
using Api.Template.Services.Services;
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
            //.UseSqlServer($@"Data Source=(LocalDb)\MSSQLLocalDB; Database=DbContext_{Guid.NewGuid()}").Options;
            .UseSqlServer($@"Data Source=(LocalDb)\MSSQLLocalDB; Initial Catalog=DbContext_{Guid.NewGuid()}").Options;

        dbContext = new SampleDbContext(Options);
        dbContext.Database.EnsureDeleted();
        dbContext.Database.EnsureCreated();

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
