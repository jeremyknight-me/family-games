namespace FamilyGames.Client.Games.Memory;

public sealed class Card
{
    public required Icon Icon { get; init; }
    public bool IsFlipped => IsMatched || IsSelected;
    public bool IsMatched => Owner != Player.None;
    public bool IsSelected { get; private set; } = false;
    public Player Owner { get; private set; } = Player.None;

    public static Card Create(Icon icon)
        => new() { Icon = icon };

    public void Select()
    {
        if (!IsSelected)
        {
            IsSelected = true;
        }
    }

    public void Match(Player owner)
    {
        Owner = owner;
        IsSelected = false;
    }

    public void Unselect()
        => IsSelected = false;
}
