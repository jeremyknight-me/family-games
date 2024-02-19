namespace FamilyGames.Client.Games.ConnectFour;

public class WinningScenarios
{
	private WinningScenarios()
	{
		var scenarios = new List<byte[]>();
		scenarios.AddRange(GetHorizontalScenarios());
		scenarios.AddRange(GetVerticalScenarios());
		scenarios.AddRange(GetDiagonalForwardSlashScenarios());
		scenarios.AddRange(GetDiagonalBackSlashScenarios());
		Scenarios = scenarios.ToArray();
	}

	public byte[][] Scenarios { get; }

	public static WinningScenarios Create() => new();

	private IEnumerable<byte[]> GetHorizontalScenarios()
	{
		for (byte row = 0; row < 6; row++)
		{
			byte rowCol1 = (byte)(row * 7);
			byte rowColEnd = (byte)((row + 1) * 7 - 1);
			byte checkCol = rowCol1;
			while (checkCol <= rowColEnd - 3)
			{
				var scenario = new byte[] {
					checkCol,
					(byte)(checkCol + 1),
					(byte)(checkCol + 2),
					(byte)(checkCol + 3)
					};
				checkCol++;
				yield return scenario;
			}
		}
	}

	private IEnumerable<byte[]> GetVerticalScenarios()
	{
		for (byte col = 0; col < 7; col++)
		{
			byte colRow1 = col;
			byte colRowEnd = (byte)(35 + col);
			byte checkRow = colRow1;
			while (checkRow <= 14 + col)
			{
				var scenario = new byte[] {
					checkRow,
					(byte)(checkRow + 7),
					(byte)(checkRow + 14),
					(byte)(checkRow + 21)
					};
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
			byte colRow1 = (byte)(21 + col);
			byte colRowEnd = (byte)(35 + col);
			byte checkPos = colRow1;
			while (checkPos <= colRowEnd)
			{
				var scenario = new byte[] {
					checkPos,
					(byte)(checkPos - 6),
					(byte)(checkPos - 12),
					(byte)(checkPos - 18)
					};
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
			byte colRow1 = (byte)(0 + col);
			byte colRowEnd = (byte)(14 + col);
			byte checkPos = colRow1;
			while (checkPos <= colRowEnd)
			{
				var scenario = new byte[] {
					checkPos,
					(byte)(checkPos + 8),
					(byte)(checkPos + 16),
					(byte)(checkPos + 24)
					};
				checkPos += 7;
				yield return scenario;
			}
		}
	}
}
