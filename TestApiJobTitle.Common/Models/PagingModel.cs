namespace TestApiJobTitle.Common.Models;

public sealed class PagingModel
{
    public int Page { get; set; } = 0;
    public int PageSize { get; set; } = 10;

    public PagingModel()
    {
    }
}