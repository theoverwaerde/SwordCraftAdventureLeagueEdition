using Microsoft.Xna.Framework;

namespace SwordCraftAdventureLeagueEdition.Core.Sword.Materials;

public sealed class GoldMaterial : Material
{
    protected override string[] PossibleName { get; } = { "Golden" };
    public override Color Color { get; } = Color.Gold;
}