namespace FamilyGames.Components;

internal static class PageTitleFactory
{
    internal const string DefaultTitle = "Family Games";

    public static string Create() => DefaultTitle;

    public static string Create(string title)
        => string.IsNullOrWhiteSpace(title)
            ? DefaultTitle
            : $"{title} - {DefaultTitle}";
}
