namespace FamilyGames.Web.Games.Memory;

public sealed class Card
{
    public required Icon Icon { get; init; }
    public bool IsFlipped => this.IsMatched || this.IsSelected;
    public bool IsMatched => this.Owner != Player.None;
    public bool IsSelected { get; private set; } = false;
    public Player Owner { get; private set; } = Player.None;

    public static Card Create(Icon icon) 
        => new() { Icon = icon };

    public void Select()
    {
        if (!this.IsSelected)
        {
            this.IsSelected = true;
        }
    }

    public void Match(Player owner)
    {
        this.Owner = owner;
        this.IsSelected = false;
    }

    public void Unselect() 
        => this.IsSelected = false;
}
