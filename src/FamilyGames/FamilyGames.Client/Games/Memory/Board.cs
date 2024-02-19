namespace FamilyGames.Client.Games.Memory;

public sealed class Board
{
    private readonly List<Card> cards;
    private readonly IDictionary<Player, int> scores;
    private Card? firstSelection;
    private Card? secondSelection;

    public Board(int numberOfPairs)
    {
        this.cards = this.BuildDeck(numberOfPairs);
        this.scores = new Dictionary<Player, int>
        {
            { Player.One, 0 },
            { Player.Two, 0 }
        };
    }

    public IReadOnlyList<Card> Cards => this.cards.AsReadOnly();
    public Player CurrentPlayer { get; private set; } = Player.One;
    public bool IsTurnOver => this.firstSelection is not null && this.secondSelection is not null;
    public IReadOnlyDictionary<Player, int> Scores => this.scores.AsReadOnly();

    public static Board Create(int numberOfPairs)
        => new(numberOfPairs);

    public void EndTurn()
    {
        this.CurrentPlayer = this.CurrentPlayer == Player.One
            ? Player.Two
            : Player.One;

        if (this.firstSelection is not null)
        {
            this.firstSelection.Unselect();
            this.firstSelection = null;
        }

        if (this.secondSelection is not null)
        {
            this.secondSelection.Unselect();
            this.secondSelection = null;
        }
    }

    public void Select(Card card)
    {
        if (card.IsSelected)
        {
            return;
        }

        card.Select();
        if (this.firstSelection is null)
        {
            this.firstSelection = card;
            return;
        }

        if (this.secondSelection is null)
        {
            this.secondSelection = card;
            if (this.firstSelection.Icon.Name == this.secondSelection.Icon.Name)
            {
                this.firstSelection.Match(this.CurrentPlayer);
                this.secondSelection.Match(this.CurrentPlayer);
                this.scores[this.CurrentPlayer]++;
            }
        }
    }

    private List<Card> BuildDeck(int numberOfPairs)
    {
        var iconCollection = new IconCollection();
        var icons = iconCollection.GetIcons(numberOfPairs);
        var unshuffledCards = new List<Card>();
        foreach (var icon in icons)
        {
            var duplicate = icon with { };
            unshuffledCards.Add(Card.Create(icon));
            unshuffledCards.Add(Card.Create(duplicate));
        }

        return unshuffledCards
            .OrderBy(x => Random.Shared.Next())
            .ToList();
    }
}
