using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace FE.PoC.Tests;
public class IntegrationHosting : WebApplicationFactory<Api.Program>
{
    public static IntegrationHosting Instance { get; private set; }
    public IntegrationHosting()
    {
        Instance = this;
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
 
    }
}

