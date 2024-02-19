namespace FamilyGames.Client.Games.TicTacToe;

public sealed class Board
{
	public const string O = "O";
	public const string X = "X";

	private readonly int[][] winCombinations;

	public Board()
	{
        this.Cells =
        [
            Cell.Create(0), Cell.Create(1), Cell.Create(2),
			Cell.Create(3), Cell.Create(4), Cell.Create(5),
			Cell.Create(6), Cell.Create(7), Cell.Create(8)
		];

        this.winCombinations =
        [
            [0, 1, 2],
			[3, 4, 5],
			[6, 7, 8],
			[0, 3, 6],
			[1, 4, 7],
			[2, 5 ,8],
			[0 ,4 ,8],
			[2 ,4 ,6]
		 ];
	}

	public Player CurrentPlayerTurn { get; private set; } = Player.X;
	public Cell[] Cells { get; }
	public bool HasConcluded => this.GameResult != MoveResult.None;
	public bool HasDraw => this.GameResult == MoveResult.Draw;
	public bool HasWinner => this.GameResult == MoveResult.WinX || this.GameResult == MoveResult.WinO;
	public MoveResult GameResult { get; private set; } = MoveResult.None;

    public static Board Create() => new();

    public void Move(PlayerMove move)
	{
        this.Cells[move.Slot].SetOwner(move.Player);
        this.SetNextPlayerTurn();

		foreach (var combination in this.winCombinations)
		{
			if (this.IsWinningCombination(combination))
			{
                this.SetWinningScenario(move, combination);
				return;
			}
		}

        this.GameResult = this.Cells.All(x => x.Owner != Player.None)
			? MoveResult.Draw
			: MoveResult.None;
	}

	private void SetWinningScenario(PlayerMove move, int[] combination)
	{
		this.Cells[combination[0]].SetWinner();
		this.Cells[combination[1]].SetWinner();
		this.Cells[combination[2]].SetWinner();
        this.GameResult = move.Player == Player.X ? MoveResult.WinX : MoveResult.WinO;
	}

    private bool IsWinningCombination(int[] combination)
        => this.Cells[combination[0]].Owner != Player.None
            && this.Cells[combination[0]].Owner == this.Cells[combination[1]].Owner
            && this.Cells[combination[1]].Owner == this.Cells[combination[2]].Owner;

    private void SetNextPlayerTurn()
		=> this.CurrentPlayerTurn = this.CurrentPlayerTurn == Player.X
			? Player.O
			: Player.X;
}
