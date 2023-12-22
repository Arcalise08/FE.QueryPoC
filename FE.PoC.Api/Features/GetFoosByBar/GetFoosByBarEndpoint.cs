using FastEndpoints;

namespace FE.PoC.Api.Features.GetFoosByBar;

public class GetFoosByBarEndpoint : Endpoint<GetFoosByBarQuery, GetFoosByBarQuery>
{
    public override void Configure()
    {
        Get("/foos");
        Description(b => b
            .Produces<GetFoosByBarQuery>()
        );
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetFoosByBarQuery req, CancellationToken ct)
    {
        await SendAsync(req, 200, ct);
    }
}