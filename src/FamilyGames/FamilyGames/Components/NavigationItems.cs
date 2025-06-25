namespace FamilyGames.Components;

public static class NavigationItemFactory
{
    public static NavigationItem[] MakeItems() =>
        [
            new() { Href = "tic-tac-toe", Icon = "bi-grid-3x3-gap-fill", Text = "Tic-Tac-Toe" },
            new() { Href = "connect-four", Icon = "bi-circle-square", Text = "Connect Four" },
            new() { Href = "memory", Icon = "bi-files", Text = "Memory" },
            new() { Href = "flashcards", Icon = "bi-lightbulb", Text = "Flashcards" }
        ];

    public sealed record NavigationItem
    {
        public required string Href { get; init; }
        public required string Icon { get; init; }
        public required string Text { get; init; }
    }
}
