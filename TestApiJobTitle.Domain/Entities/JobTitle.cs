namespace TestApiJobTitle.Domain.Entities;

public sealed class JobTitle
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
}