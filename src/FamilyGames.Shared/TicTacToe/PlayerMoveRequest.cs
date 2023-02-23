namespace FamilyGames.Shared.TicTacToe;

public sealed record PlayerMoveRequest
{
    public required Player Player { get; init; }
    public required int Slot { get; init; }
}
