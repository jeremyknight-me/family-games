namespace FamilyGames.Client.Games.Memory;

public sealed record Icon
{
    public required string Name { get; init; }
    public required string CssClass { get; init; }

    public static Icon Create(string name, string cssClass)
        => new() { Name = name, CssClass = cssClass };
}
