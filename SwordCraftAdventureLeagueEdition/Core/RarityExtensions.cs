using System;
using Microsoft.Xna.Framework;

namespace SwordCraftAdventureLeagueEdition.Core;

public static class RarityExtensions
{
    public static Color Color(this Rarity rarity) => rarity switch
    {
        Rarity.Common => Microsoft.Xna.Framework.Color.WhiteSmoke,
        Rarity.Rare => Microsoft.Xna.Framework.Color.CornflowerBlue,
        Rarity.Epic => Microsoft.Xna.Framework.Color.MediumPurple,
        _ => throw new ArgumentOutOfRangeException(nameof(rarity), rarity, null)
    };
}