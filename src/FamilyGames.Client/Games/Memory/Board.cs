namespace FamilyGames.Client.Games.Memory;

public sealed class Board
{
    private readonly List<Card> cards;
    private readonly IDictionary<Player, int> scores;
    private Card? firstSelection;
    private Card? secondSelection;
    private bool matchFound = false;

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
    public bool IsPlayerOneTurn => this.CurrentPlayer == Player.One;
    public bool IsPlayerTwoTurn => this.CurrentPlayer == Player.Two;
    public bool IsContinue => this.BothSelectionsMade && this.matchFound;
    public bool IsTurnOver => this.BothSelectionsMade && !this.matchFound;
    public IReadOnlyDictionary<Player, int> Scores => this.scores.AsReadOnly();

    private bool BothSelectionsMade
        => this.firstSelection is not null
            && this.secondSelection is not null;

    public static Board Create(int numberOfPairs)
        => new(numberOfPairs);

    public void ContinueTurn()
        => this.ResetSelections();

    public void EndTurn()
    {
        this.CurrentPlayer = this.CurrentPlayer == Player.One
            ? Player.Two
            : Player.One;
        this.ResetSelections();
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
                this.matchFound = true;
            }
        }
    }

    private void ResetSelections()
    {
        this.matchFound = false;

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
