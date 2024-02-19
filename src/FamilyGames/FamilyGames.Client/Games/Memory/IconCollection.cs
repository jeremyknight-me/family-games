using System.Collections.Immutable;

namespace FamilyGames.Client.Games.Memory;

public sealed class IconCollection
{
    private readonly List<Icon> icons;

    public IconCollection()
    {
        this.icons = [
            Icon.Create(IconNames.Airplane, IconCssClasses.Airplane),
            Icon.Create(IconNames.Alarm, IconCssClasses.Alarm),
            Icon.Create(IconNames.Bag, IconCssClasses.Bag),
            Icon.Create(IconNames.Balloon, IconCssClasses.Balloon),
            Icon.Create(IconNames.Bandaid, IconCssClasses.Bandaid),
            Icon.Create(IconNames.Basketball, IconCssClasses.Basketball),
            Icon.Create(IconNames.Bell, IconCssClasses.Bell),
            Icon.Create(IconNames.Bicycle, IconCssClasses.Bicycle),
            Icon.Create(IconNames.Binoculars, IconCssClasses.Binoculars),
            Icon.Create(IconNames.Brush, IconCssClasses.Brush),
            Icon.Create(IconNames.Bug, IconCssClasses.Bug),
            Icon.Create(IconNames.Bus, IconCssClasses.Bus),
            Icon.Create(IconNames.Calculator, IconCssClasses.Calculator),
            Icon.Create(IconNames.Camera, IconCssClasses.Camera),
            Icon.Create(IconNames.Car, IconCssClasses.Car),
            Icon.Create(IconNames.Circle, IconCssClasses.Circle),
            Icon.Create(IconNames.Clock, IconCssClasses.Clock),
            Icon.Create(IconNames.Cloud, IconCssClasses.Cloud),
            Icon.Create(IconNames.CoffeeCup, IconCssClasses.CoffeeCup),
            Icon.Create(IconNames.Controller, IconCssClasses.Controller),
            Icon.Create(IconNames.Cup, IconCssClasses.Cup),
            Icon.Create(IconNames.CupidsArrow, IconCssClasses.CupidsArrow),
            Icon.Create(IconNames.Dice1, IconCssClasses.Dice1),
            Icon.Create(IconNames.Dice2, IconCssClasses.Dice2),
            Icon.Create(IconNames.Dice3, IconCssClasses.Dice3),
            Icon.Create(IconNames.Dice4, IconCssClasses.Dice4),
            Icon.Create(IconNames.Dice5, IconCssClasses.Dice5),
            Icon.Create(IconNames.Dice6, IconCssClasses.Dice6),
            Icon.Create(IconNames.Earbuds, IconCssClasses.Earbuds),
            Icon.Create(IconNames.EmojiFrown, IconCssClasses.EmojiFrown),
            Icon.Create(IconNames.EmojiSmile, IconCssClasses.EmojiSmile),
            Icon.Create(IconNames.EmojiSunglasses, IconCssClasses.EmojiSunglasses),
            Icon.Create(IconNames.Envelope, IconCssClasses.Envelope),
            Icon.Create(IconNames.Eyeglasses, IconCssClasses.Eyeglasses),
            Icon.Create(IconNames.Flower, IconCssClasses.Flower),
            Icon.Create(IconNames.GasPump, IconCssClasses.GasPump),
            Icon.Create(IconNames.Gift, IconCssClasses.Gift),
            Icon.Create(IconNames.Globe, IconCssClasses.Globe),
            Icon.Create(IconNames.Hammer, IconCssClasses.Hammer),
            Icon.Create(IconNames.House, IconCssClasses.House),
            Icon.Create(IconNames.Joystick, IconCssClasses.Joystick),
            Icon.Create(IconNames.Key, IconCssClasses.Key),
            Icon.Create(IconNames.Lamp, IconCssClasses.Lamp),
            Icon.Create(IconNames.LightBulb, IconCssClasses.LightBulb),
            Icon.Create(IconNames.MagicWand, IconCssClasses.MagicWand),
            Icon.Create(IconNames.Magnet, IconCssClasses.Magnet),
            Icon.Create(IconNames.Mailbox, IconCssClasses.Mailbox),
            Icon.Create(IconNames.Megaphone, IconCssClasses.Megaphone),
            Icon.Create(IconNames.Moon, IconCssClasses.Moon),
            Icon.Create(IconNames.Pen, IconCssClasses.Pen),
            Icon.Create(IconNames.Pencil, IconCssClasses.Pencil),
            Icon.Create(IconNames.Pentagon, IconCssClasses.Pentagon),
            Icon.Create(IconNames.PiggyBank, IconCssClasses.PiggyBank),
            Icon.Create(IconNames.PuzzlePiece, IconCssClasses.PuzzlePiece),
            Icon.Create(IconNames.Rocket, IconCssClasses.Rocket),
            Icon.Create(IconNames.Scooter, IconCssClasses.Scooter),
            Icon.Create(IconNames.Screwdriver, IconCssClasses.Screwdriver),
            Icon.Create(IconNames.Shield, IconCssClasses.Shield),
            Icon.Create(IconNames.ShoppingCart, IconCssClasses.ShoppingCart),
            Icon.Create(IconNames.Snow, IconCssClasses.Snow),
            Icon.Create(IconNames.Square, IconCssClasses.Square),
            Icon.Create(IconNames.SuitClub, IconCssClasses.SuitClub),
            Icon.Create(IconNames.SuitDiamond, IconCssClasses.SuitDiamond),
            Icon.Create(IconNames.SuitHeart, IconCssClasses.SuitHeart),
            Icon.Create(IconNames.SuitSpade, IconCssClasses.SuitSpade),
            Icon.Create(IconNames.Sun, IconCssClasses.Sun),
            Icon.Create(IconNames.Sunglasses, IconCssClasses.Sunglasses),
            Icon.Create(IconNames.Tornado, IconCssClasses.Tornado),
            Icon.Create(IconNames.Truck, IconCssClasses.Truck),
            Icon.Create(IconNames.Umbrella, IconCssClasses.Umbrella),
            Icon.Create(IconNames.VideoCamera, IconCssClasses.VideoCamera),
            Icon.Create(IconNames.Watch, IconCssClasses.Watch),
            Icon.Create(IconNames.Wrench, IconCssClasses.Wrench),
            Icon.Create(IconNames.YinYang, IconCssClasses.YinYang)
        ];
    }

    public IReadOnlyList<Icon> Icons => this.icons.AsReadOnly();

    public IReadOnlyList<Icon> GetIcons(int number)
        => this.icons
            .OrderBy(x => Random.Shared.Next())
            .Take(number)
            .ToImmutableList();
}
