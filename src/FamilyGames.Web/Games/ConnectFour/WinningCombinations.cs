namespace FamilyGames.Web.Games.ConnectFour;

public class WinningCombinations
{
    private WinningCombinations()
    {
		var combos = new List<int[]>();

		// Horizontal rows
		for (byte row = 0; row < 6; row++)
		{
			byte rowCol1 = (byte)(row * 7);
			byte rowColEnd = (byte)((row + 1) * 7 - 1);
			byte checkCol = rowCol1;
			while (checkCol <= rowColEnd - 3)
			{
				combos.Add(new int[] {
					checkCol,
					(byte)(checkCol + 1),
					(byte)(checkCol + 2),
					(byte)(checkCol + 3)
					});
				checkCol++;
			}
		}

		// Vertical Columns
		for (byte col = 0; col < 7; col++)
		{
			byte colRow1 = col;
			byte colRowEnd = (byte)(35 + col);
			byte checkRow = colRow1;
			while (checkRow <= 14 + col)
			{
				combos.Add(new int[] {
					checkRow,
					(byte)(checkRow + 7),
					(byte)(checkRow + 14),
					(byte)(checkRow + 21)
					});
				checkRow += 7;
			}
		}

		// forward slash diagonal "/"
		for (byte col = 0; col < 4; col++)
		{
			// starting column must be 0-3
			byte colRow1 = (byte)(21 + col);
			byte colRowEnd = (byte)(35 + col);
			byte checkPos = colRow1;
			while (checkPos <= colRowEnd)
			{
				combos.Add(new int[] {
					checkPos,
					(byte)(checkPos - 6),
					(byte)(checkPos - 12),
					(byte)(checkPos - 18)
					});
				checkPos += 7;
			}
		}

		// back slash diaganol "\"
		for (byte col = 0; col < 4; col++)
		{
			// starting column must be 0-3
			byte colRow1 = (byte)(0 + col);
			byte colRowEnd = (byte)(14 + col);
			byte checkPos = colRow1;
			while (checkPos <= colRowEnd)
			{
				combos.Add(new int[] {
					checkPos,
					(byte)(checkPos + 8),
					(byte)(checkPos + 16),
					(byte)(checkPos + 24)
					});
				checkPos += 7;
			}
		}

		this.Combinations = combos;
	}

	public List<int[]> Combinations { get; }

	public static WinningCombinations Create() 
		=> new();
}
