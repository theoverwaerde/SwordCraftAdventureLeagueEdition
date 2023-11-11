using Microsoft.Xna.Framework;

namespace SwordCraftAdventureLeagueEdition.Core.Sword.Materials;

public sealed class WoodenMaterial : Material
{
    protected override string[] PossibleName { get; } = { "Wooden" };
    public override Color Color { get; } = Color.SaddleBrown; //new Color(153, 102, 0);
}