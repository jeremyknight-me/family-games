using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyGames.Shared.TicTacToe;

public abstract class BoardBase
{
    protected const string O = "O";
    protected const string X = "X";

    public BoardBase()
    {
        this.Slots = new string[9]
        {
            string.Empty, string.Empty, string.Empty,
            string.Empty, string.Empty, string.Empty,
            string.Empty, string.Empty, string.Empty
        };
    }

    public string[] Slots { get; }
}
