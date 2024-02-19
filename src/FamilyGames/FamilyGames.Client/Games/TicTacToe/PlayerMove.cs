namespace FamilyGames.Client.Games.TicTacToe;

public sealed record PlayerMove
{
	public required Player Player { get; init; }
	public required int Slot { get; init; }
}
