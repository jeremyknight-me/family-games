namespace FamilyGames.Client.Games.Flashcards;

public static class FlashcardFactory
{
    public static Flashcard Create(HashSet<string> selectedFeatures, int numberCount)
    {
        var features = selectedFeatures.ToList();
        var feature = features[Random.Shared.Next(features.Count)];
        return feature switch
        {
            FlashcardFeatures.Addition => CreateAddition(numberCount),
            FlashcardFeatures.Subtraction => CreateSubtraction(numberCount),
            _ => throw new InvalidOperationException("Unknown feature selected.")
        };
    }

    private static Flashcard CreateAddition(int numberCount)
    {
        var numbers = new int[numberCount];
        for (var j = 0; j < numberCount; j++)
        {
            numbers[j] = Random.Shared.Next(1, 100); // Numbers between 1 and 99
        }
        var equation = string.Join(" + ", numbers);
        var answer = numbers.Sum();
        return new Flashcard { Equation = equation, Answer = answer };
    }

    private static Flashcard CreateSubtraction(int numberCount)
    {
        Flashcard? result = null;
        while (result == null)
        {
            var numbers = new int[numberCount];
            for (var j = 0; j < numberCount; j++)
            {
                numbers[j] = Random.Shared.Next(1, 100);
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
