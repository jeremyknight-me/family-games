namespace FamilyGames.Web.Games.TicTacToe;

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

    public void SetPlayer(Player player) 
        => this.Owner = player;

    public void SetWinner() 
        => this.IsWinner = true;
}
