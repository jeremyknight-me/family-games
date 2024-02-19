namespace FamilyGames.Client.Games.Memory;

public sealed class Board
{
    private readonly List<Card> cards;
    private readonly IDictionary<Player, int> scores;
    private Card? firstSelection;
    private Card? secondSelection;

    public Board(int numberOfPairs)
    {
        cards = BuildDeck(numberOfPairs);
        scores = new Dictionary<Player, int>
        {
            { Player.One, 0 },
            { Player.Two, 0 }
        };
    }

    public IReadOnlyList<Card> Cards => cards.AsReadOnly();
    public Player CurrentPlayer { get; private set; } = Player.One;
    public bool IsTurnOver => firstSelection is not null && secondSelection is not null;
    public IReadOnlyDictionary<Player, int> Scores => scores.AsReadOnly();

    public static Board Create(int numberOfPairs)
        => new(numberOfPairs);

    public void EndTurn()
    {
        CurrentPlayer = CurrentPlayer == Player.One
            ? Player.Two
            : Player.One;

        if (firstSelection is not null)
        {
            firstSelection.Unselect();
            firstSelection = null;
        }

        if (secondSelection is not null)
        {
            secondSelection.Unselect();
            secondSelection = null;
        }
    }

    public void Select(Card card)
    {
        if (card.IsSelected)
        {
            return;
        }

        card.Select();
        if (firstSelection is null)
        {
            firstSelection = card;
            return;
        }

        if (secondSelection is null)
        {
            secondSelection = card;
            if (firstSelection.Icon.Name == secondSelection.Icon.Name)
            {
                firstSelection.Match(CurrentPlayer);
                secondSelection.Match(CurrentPlayer);
                scores[CurrentPlayer]++;
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
