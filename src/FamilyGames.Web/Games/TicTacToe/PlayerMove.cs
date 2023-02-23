namespace FamilyGames.Web.Games.TicTacToe;

public sealed record PlayerMove
{
    public required Player Player { get; init; }
    public required int Slot { get; init; }
}
