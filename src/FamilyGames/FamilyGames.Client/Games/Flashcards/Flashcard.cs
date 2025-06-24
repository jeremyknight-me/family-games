namespace FamilyGames.Client.Games.Flashcards;

public sealed record Flashcard
{
    public required string Equation { get; init; }
    public required int Answer { get; init; }
}
