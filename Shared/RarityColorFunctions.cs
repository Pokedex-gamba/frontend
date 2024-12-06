namespace PokedexGambaApp.Shared;

public static class RarityColorFunctions
{
    public static string GetBackgroundGradient(int rarity)
    {
        double hue = GetRarityHue(rarity);
        return "linear-gradient(to top, hsla(" + hue + ", 100%, 70%) 0%, hsla(" + hue + ", 100%, 100%) 12%)";
    }

    public static double GetRarityHue(int rarity)
    {
        double hue = ((double)rarity - 500) / 500 * 270 + 90.0;
        return hue;
    }

    public static string GetRarityHSLA(int rarity)
    {
        double hue = GetRarityHue(rarity);
        return "hsla(" + hue + ", 100%, 70%)";
    }
}