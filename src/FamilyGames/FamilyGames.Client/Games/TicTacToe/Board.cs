namespace FamilyGames.Client.Games.TicTacToe;

public sealed class Board
{
	public const string O = "O";
	public const string X = "X";

	private readonly int[][] winCombinations;

	public Board()
	{
		Cells = new Cell[9]
		{
			Cell.Create(0), Cell.Create(1), Cell.Create(2),
			Cell.Create(3), Cell.Create(4), Cell.Create(5),
			Cell.Create(6), Cell.Create(7), Cell.Create(8)
		};

		winCombinations = new int[][]
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

	public Player CurrentPlayerTurn { get; private set; } = Player.X;
	public Cell[] Cells { get; }
	public bool HasConcluded => GameResult != MoveResult.None;
	public bool HasDraw => GameResult == MoveResult.Draw;
	public bool HasWinner => GameResult == MoveResult.WinX || GameResult == MoveResult.WinO;
	public MoveResult GameResult { get; private set; } = MoveResult.None;

	public static Board Create()
	{
		return new();
	}

	public void Move(PlayerMove move)
	{
		Cells[move.Slot].SetOwner(move.Player);
		SetNextPlayerTurn();

		foreach (var combination in winCombinations)
		{
			if (IsWinningCombination(combination))
			{
				SetWinningScenario(move, combination);
				return;
			}
		}

		GameResult = Cells.All(x => x.Owner != Player.None)
			? MoveResult.Draw
			: MoveResult.None;
	}

	private void SetWinningScenario(PlayerMove move, int[] combination)
	{
		Cells[combination[0]].SetWinner();
		Cells[combination[1]].SetWinner();
		Cells[combination[2]].SetWinner();
		GameResult = move.Player == Player.X ? MoveResult.WinX : MoveResult.WinO;
	}

	private bool IsWinningCombination(int[] combination)
	{
		return Cells[combination[0]].Owner != Player.None
			&& Cells[combination[0]].Owner == Cells[combination[1]].Owner
			&& Cells[combination[1]].Owner == Cells[combination[2]].Owner;
	}

	private void SetNextPlayerTurn()
		=> CurrentPlayerTurn = CurrentPlayerTurn == Player.X
			? Player.O
			: Player.X;
}
