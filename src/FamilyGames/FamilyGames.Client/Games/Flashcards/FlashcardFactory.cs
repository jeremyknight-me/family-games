namespace FamilyGames.Client.Games.Flashcards;

public static class FlashcardFactory
{
    public static Flashcard Create(FlashcardSettings settings)
    {
        var features = settings.SelectedFeatures.ToList();
        var feature = features[Random.Shared.Next(features.Count)];
        return feature switch
        {
            FlashcardFeatures.Addition => CreateAddition(settings),
            FlashcardFeatures.Subtraction => CreateSubtraction(settings),
            _ => throw new InvalidOperationException("Unknown feature selected.")
        };
    }

    private static Flashcard CreateAddition(FlashcardSettings settings)
    {
        var numbers = new int[settings.NumberOfTerms];
        for (var j = 0; j < settings.NumberOfTerms; j++)
        {
            numbers[j] = Random.Shared.Next(1, settings.MaxTermValue + 1); // Numbers between 1 and MaxTermValue
        }
        var equation = string.Join(" + ", numbers);
        var answer = numbers.Sum();
        return new Flashcard { Equation = equation, Answer = answer };
    }

    private static Flashcard CreateSubtraction(FlashcardSettings settings)
    {
        Flashcard? result = null;
        while (result == null)
        {
            var numbers = new int[settings.NumberOfTerms];
            for (var j = 0; j < settings.NumberOfTerms; j++)
            {
                numbers[j] = Random.Shared.Next(1, settings.MaxTermValue + 1);
            }
            var answer = numbers[0];
            for (var j = 1; j < numbers.Length; j++)
            {
                answer -= numbers[j];
                if (answer < 0)
                {
                    continue;
                }
            }
            if (answer >= 0)
            {
                var equation = string.Join(" - ", numbers);
                result = new Flashcard { Equation = equation, Answer = answer };
            }
        }
        return result;
    }
}
