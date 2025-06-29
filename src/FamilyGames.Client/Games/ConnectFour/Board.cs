namespace FamilyGames.Client.Games.ConnectFour;

public sealed class Board
{
	private readonly WinningScenarios winScenarios;

	private Board()
	{
        this.winScenarios = WinningScenarios.Create();
	}

	public byte[] Cells { get; private set; } = new byte[42];
	public string? CurrentMessage => this.WinnerMessage == string.Empty
		? $"Player {this.PlayerTurn}'s Turn"
		: string.Empty;
	public int CurrentTurn => this.Cells.Count(x => x != 0);
	public string? ErrorMessage { get; private set; }
	public bool HasCurrentMessage => !string.IsNullOrWhiteSpace(this.CurrentMessage);
	public bool HasErrorMessage => !string.IsNullOrWhiteSpace(this.ErrorMessage);
	public bool HasWinnerMessage => !string.IsNullOrWhiteSpace(this.WinnerMessage);
	public string[] PlayerMoves { get; private set; } = new string[42];
	public byte PlayerTurn => (byte)(this.PlayerMoves.Count(x => !string.IsNullOrEmpty(x)) % 2 + 1);
	public string? WinnerMessage { get; private set; }

	public static Board Create() => new();

	public void PlayPiece(byte column)
	{
        this.ErrorMessage = string.Empty;
		try
		{
			// Check for a current win
			if (this.CheckForWin() != 0)
			{
				throw new ArgumentException("Game is over");
			}

			// Check the column
			if (this.Cells[column] != 0)
			{
				throw new ArgumentException("Column is full");
			}

			// Drop the piece in
			var landingSpot = column;
			for (var i = column; i < 42; i += 7)
			{
				if (this.Cells[landingSpot + 7] != 0)
				{
					break;
				}

				landingSpot = i;
			}

            this.Cells[landingSpot] = this.PlayerTurn;
			var landingRow = this.ConvertLandingSpotToRow(landingSpot);
			var cssClass = $"player{this.PlayerTurn} col{column} drop{landingRow}";
            this.PlayerMoves[this.CurrentTurn - 1] = cssClass;
		}
		catch (ArgumentException ex)
		{
            this.ErrorMessage = ex.Message;
		}

        this.WinnerMessage = this.CheckForWin() switch
		{
			MoveResult.WinPlayer1 => "Player 1 Wins!",
			MoveResult.WinPlayer2 => "Player 2 Wins!",
			MoveResult.Draw => "It's a draw!",
			_ => ""
		};
	}

	public void Reset()
	{
        this.Cells = new byte[42];
        this.WinnerMessage = string.Empty;
        this.ErrorMessage = string.Empty;
        this.PlayerMoves = new string[42];
	}

	private MoveResult CheckForWin()
	{
		// Exit immediately if less than 7 pieces are played
		if (this.Cells.Count(x => x != 0) < 7)
		{
			return MoveResult.None;
		}

		foreach (var scenario in this.winScenarios.Scenarios)
		{
			if (this.Cells[scenario[0]] == 0)
			{
				continue;
			}

			if (this.Cells[scenario[0]] == this.Cells[scenario[1]]
				&& this.Cells[scenario[1]] == this.Cells[scenario[2]]
				&& this.Cells[scenario[2]] == this.Cells[scenario[3]])
			{
				return (MoveResult)this.Cells[scenario[0]];
			}
		}

		return this.Cells.Count(x => x != 0) == 42
			? MoveResult.Draw
			: MoveResult.None;
	}

	private byte ConvertLandingSpotToRow(byte landingSpot)
		=> (byte)(Math.Floor(landingSpot / (decimal)7) + 1);
}
