namespace FamilyGames.Client.Games.ConnectFour;

public sealed class Board
{
	private readonly WinningScenarios winScenarios;

	private Board()
	{
		winScenarios = WinningScenarios.Create();
	}

	public byte[] Cells { get; private set; } = new byte[42];
	public string? CurrentMessage => WinnerMessage == string.Empty
		? $"Player {PlayerTurn}'s Turn"
		: string.Empty;
	public int CurrentTurn => Cells.Count(x => x != 0);
	public string? ErrorMessage { get; private set; }
	public bool HasCurrentMessage => !string.IsNullOrWhiteSpace(CurrentMessage);
	public bool HasErrorMessage => !string.IsNullOrWhiteSpace(ErrorMessage);
	public bool HasWinnerMessage => !string.IsNullOrWhiteSpace(WinnerMessage);
	public string[] PlayerMoves { get; private set; } = new string[42];
	public byte PlayerTurn => (byte)(PlayerMoves.Count(x => !string.IsNullOrEmpty(x)) % 2 + 1);
	public string? WinnerMessage { get; private set; }

	public static Board Create() => new();

	public void PlayPiece(byte column)
	{
		ErrorMessage = string.Empty;
		try
		{
			// Check for a current win
			if (CheckForWin() != 0)
			{
				throw new ArgumentException("Game is over");
			}

			// Check the column
			if (Cells[column] != 0)
			{
				throw new ArgumentException("Column is full");
			}

			// Drop the piece in
			var landingSpot = column;
			for (var i = column; i < 42; i += 7)
			{
				if (Cells[landingSpot + 7] != 0)
				{
					break;
				}

				landingSpot = i;
			}

			Cells[landingSpot] = PlayerTurn;
			var landingRow = ConvertLandingSpotToRow(landingSpot);
			var cssClass = $"player{PlayerTurn} col{column} drop{landingRow}";
			PlayerMoves[CurrentTurn - 1] = cssClass;
		}
		catch (ArgumentException ex)
		{
			ErrorMessage = ex.Message;
		}

		WinnerMessage = CheckForWin() switch
		{
			MoveResult.WinPlayer1 => "Player 1 Wins!",
			MoveResult.WinPlayer2 => "Player 2 Wins!",
			MoveResult.Draw => "It's a draw!",
			_ => ""
		};
	}

	public void Reset()
	{
		Cells = new byte[42];
		WinnerMessage = string.Empty;
		ErrorMessage = string.Empty;
		PlayerMoves = new string[42];
	}

	private MoveResult CheckForWin()
	{
		// Exit immediately if less than 7 pieces are played
		if (Cells.Count(x => x != 0) < 7)
		{
			return MoveResult.None;
		}

		foreach (var scenario in winScenarios.Scenarios)
		{
			if (Cells[scenario[0]] == 0)
			{
				continue;
			}

			if (Cells[scenario[0]] == Cells[scenario[1]]
				&& Cells[scenario[1]] == Cells[scenario[2]]
				&& Cells[scenario[2]] == Cells[scenario[3]])
			{
				return (MoveResult)Cells[scenario[0]];
			}
		}

		return Cells.Count(x => x != 0) == 42
			? MoveResult.Draw
			: MoveResult.None;
	}

	private byte ConvertLandingSpotToRow(byte landingSpot)
		=> (byte)(Math.Floor(landingSpot / (decimal)7) + 1);
}
