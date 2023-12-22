using FastEndpoints;

namespace FE.PoC.Api.Features.GetFoosByBar;

public class GetFoosByBarEndpoint : Endpoint<GetFoosByBarQuery, Foo>
{
    public override void Configure()
    {
        Get("/foos");
        Description(b => b
            .Produces<Foo>()
        );
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetFoosByBarQuery req, CancellationToken ct)
    {
        await SendAsync(new Foo(), 200, ct);
    }
}