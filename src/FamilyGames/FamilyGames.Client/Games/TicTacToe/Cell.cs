namespace FamilyGames.Client.Games.TicTacToe;

public sealed class Cell
{
	public int Index { get; init; }
	public Player Owner { get; private set; }
	public bool IsWinner { get; private set; } = false;

	public static Cell Create(int index)
		=> new()
		{
			Index = index
		};

	public void SetOwner(Player owner)
		=> Owner = owner;

	public void SetWinner()
		=> IsWinner = true;
}
