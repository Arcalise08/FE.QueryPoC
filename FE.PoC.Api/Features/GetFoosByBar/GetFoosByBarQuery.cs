using FastEndpoints;

namespace FE.PoC.Api.Features.GetFoosByBar;

public class GetFoosByBarQuery
{
    public string Id { get; set; }
    [FromQueryParams]
    public Paging Paging { get; set; }
}