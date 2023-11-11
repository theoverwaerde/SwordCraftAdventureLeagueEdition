using Microsoft.Xna.Framework;

namespace SwordCraftAdventureLeagueEdition.Core.Sword.Materials;

public sealed class IronMaterial : Material
{
    protected override string[] PossibleName { get; } = { "Iron" };
    public override Color Color { get; } = Color.WhiteSmoke;
}