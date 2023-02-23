using FamilyGames.Shared.TicTacToe;

namespace FamilyGames.Server.Games.TicTacToe;

public sealed class ServerBoard : BoardBase
{
    private readonly int[][] winCombinations;

    public ServerBoard() 
        : base()
    {
        this.winCombinations = new int[][]
        {
            new int[] { 0, 1, 2 },
            new int[] { 3, 4, 5 },
            new int[] { 6, 7, 8 },
            new int[] { 0, 3, 6 },
            new int[] { 1, 4, 7 },
            new int[] { 2, 5 ,8 },
            new int[] { 0 ,4 ,8 },
            new int[] { 2 ,4 ,6 }
         };
    }

    public PlayerMoveResponse Move(PlayerMoveRequest moveRequest)
    {
        this.Slots[moveRequest.Slot] = moveRequest.Player == Player.X ? X : O;
        return new PlayerMoveResponse
        {
            Player = moveRequest.Player,
            Slot = moveRequest.Slot,
            Result = this.GetMoveResult()
        };
    }

    private MoveResult GetMoveResult()
    {
        foreach (var combination in this.winCombinations)
        {
            if (this.Slots[combination[0]] != string.Empty
                && this.Slots[combination[0]] == this.Slots[combination[1]]
                && this.Slots[combination[1]] == this.Slots[combination[2]])
            {
                return this.Slots[combination[0]] == X
                    ? MoveResult.WinX
                    : MoveResult.WinO;
            }
        }

        if (this.Slots.All(x => x != string.Empty))
        {
            return MoveResult.Draw;
        }

        return MoveResult.None;
    }
}
