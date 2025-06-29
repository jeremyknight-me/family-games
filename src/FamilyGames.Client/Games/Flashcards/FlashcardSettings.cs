namespace FamilyGames.Client.Games.Flashcards;

public sealed class FlashcardSettings
{
    private int numberOfTerms = 2;

    public HashSet<string> SelectedFeatures { get; } = [FlashcardFeatures.Addition];
    public int MinimumTerms { get; set; } = 2;
    public int MaximumTerms { get; set; } = 5;
    public int MaxTermValue { get; set; } = 10;

    public int NumberOfTerms
    {
        get => this.numberOfTerms;
        set
        {
            if (value < this.MinimumTerms || value > this.MaximumTerms)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(this.NumberOfTerms),
                    $"Value must be between {this.MinimumTerms} and {this.MaximumTerms}.");
            }

            this.numberOfTerms = value;
        }
    }

    public bool CanStartGame => this.SelectedFeatures.Count > 0 && this.numberOfTerms != 0;

    public bool IsAdditionSelected
    {
        get => this.SelectedFeatures.Contains(FlashcardFeatures.Addition);
        set
        {
            if (value)
            {
                this.SelectedFeatures.Add(FlashcardFeatures.Addition);
            }
            else
            {
                this.SelectedFeatures.Remove(FlashcardFeatures.Addition);
            }
        }
    }

    public bool IsSubtractionSelected
    {
        get => this.SelectedFeatures.Contains(FlashcardFeatures.Subtraction);
        set
        {
            if (value)
            {
                this.SelectedFeatures.Add(FlashcardFeatures.Subtraction);
            }
            else
            {
                this.SelectedFeatures.Remove(FlashcardFeatures.Subtraction);
            }
        }
    }
}
