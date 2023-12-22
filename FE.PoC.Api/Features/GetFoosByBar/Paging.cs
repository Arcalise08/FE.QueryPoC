namespace FE.PoC.Api.Features.GetFoosByBar;

public record Paging
{
    public int MaxItemsPerCall { get; set; } = 100;
    public string? ContinuationToken { get; set; } = null;
}