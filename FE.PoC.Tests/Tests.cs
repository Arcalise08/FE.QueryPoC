using System.Text.Json;
using AutoFixture;
using FE.PoC.Api.Features.GetFoosByBar;

namespace FE.PoC.Tests;

public class Tests :
    IClassFixture<IntegrationHosting>
{

    private readonly IntegrationHosting TestFactory;
    private readonly Fixture Fixture;
    public Tests(IntegrationHosting testFactory)
    {
        TestFactory = testFactory;
        Fixture = new Fixture();
    }

    [Theory]
    //I'm unsure what case sensitivity should work so ill try all combinations
    [InlineData("?id=1&Paging.MaxItemsPerCall={0}&Paging.ContinuationToken={1}")]
    [InlineData("?id=1&Paging.maxItemsPerCall={0}&Paging.continuationToken={1}")]
    [InlineData("?id=1&paging.maxItemsPerCall={0}&paging.continuationToken={1}")]
    [InlineData("?id=1&paging.MaxItemsPerCall={0}&paging.ContinuationToken={1}")]
    public async Task GeneralIntegration(string queryStringFormat)
    {
        var client = TestFactory.CreateClient();
        var expectedMaxItems = Fixture.Create<int>();
        var expectedToken = Fixture.Create<string>();
        var queryString = string.Format(queryStringFormat, expectedMaxItems, expectedToken); 
        var response = await client.GetAsync($"/foos{queryString}");
        var result = JsonSerializer.Deserialize<GetFoosByBarQuery>(await response.Content.ReadAsStringAsync());
        Assert.NotNull(result);
        Assert.NotNull(result.Paging);
        Assert.Equal(expectedMaxItems, result.Paging.MaxItemsPerCall);
        Assert.Equal(expectedToken, result.Paging.ContinuationToken);
    }
}