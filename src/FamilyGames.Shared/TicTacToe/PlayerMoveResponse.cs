namespace FamilyGames.Shared.TicTacToe;

public sealed record PlayerMoveResponse
{
    public required Player Player { get; init; }
    public required int Slot { get; init; }
    public required MoveResult Result { get; init; }
}