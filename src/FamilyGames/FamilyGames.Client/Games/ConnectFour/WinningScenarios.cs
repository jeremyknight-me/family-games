namespace FamilyGames.Client.Games.ConnectFour;

public class WinningScenarios
{
	private WinningScenarios()
	{
		var scenarios = new List<byte[]>();
		scenarios.AddRange(this.GetHorizontalScenarios());
		scenarios.AddRange(this.GetVerticalScenarios());
		scenarios.AddRange(this.GetDiagonalForwardSlashScenarios());
		scenarios.AddRange(this.GetDiagonalBackSlashScenarios());
		this.Scenarios = scenarios.ToArray();
	}

	public byte[][] Scenarios { get; }

	public static WinningScenarios Create() => new();

	private IEnumerable<byte[]> GetHorizontalScenarios()
	{
		for (byte row = 0; row < 6; row++)
		{
			var rowCol1 = (byte)(row * 7);
			var rowColEnd = (byte)((row + 1) * (7 - 1));
			var checkCol = rowCol1;
			while (checkCol <= rowColEnd - 3)
			{
				byte[] scenario = [
					checkCol,
					(byte)(checkCol + 1),
					(byte)(checkCol + 2),
					(byte)(checkCol + 3)
				];
				checkCol++;
				yield return scenario;
			}
		}
	}

	private IEnumerable<byte[]> GetVerticalScenarios()
	{
		for (byte col = 0; col < 7; col++)
		{
			var colRow1 = col;
			var checkRow = colRow1;
			while (checkRow <= 14 + col)
			{
                byte[] scenario = [
					checkRow,
					(byte)(checkRow + 7),
					(byte)(checkRow + 14),
					(byte)(checkRow + 21)
				];
				checkRow += 7;
				yield return scenario;
			}
		}
	}

	private IEnumerable<byte[]> GetDiagonalForwardSlashScenarios()
	{
		for (byte col = 0; col < 4; col++)
		{
			// starting column must be 0-3
			var colRow1 = (byte)(21 + col);
			var colRowEnd = (byte)(35 + col);
			var checkPos = colRow1;
			while (checkPos <= colRowEnd)
			{
                byte[] scenario = [
					checkPos,
					(byte)(checkPos - 6),
					(byte)(checkPos - 12),
					(byte)(checkPos - 18)
				];
				checkPos += 7;
				yield return scenario;
			}
		}
	}

	private IEnumerable<byte[]> GetDiagonalBackSlashScenarios()
	{
		for (byte col = 0; col < 4; col++)
		{
			// starting column must be 0-3
			var colRow1 = (byte)(0 + col);
			var colRowEnd = (byte)(14 + col);
			var checkPos = colRow1;
			while (checkPos <= colRowEnd)
			{
                byte[] scenario = [
					checkPos,
					(byte)(checkPos + 8),
					(byte)(checkPos + 16),
					(byte)(checkPos + 24)
				];
				checkPos += 7;
				yield return scenario;
			}
		}
	}
}
