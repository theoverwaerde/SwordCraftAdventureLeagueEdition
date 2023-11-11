using System;

namespace SwordCraftAdventureLeagueEdition.Core.Sword;

public abstract class SwordPart
{
    protected abstract string[] PossibleName { get; }
    public string GetRandomName() => PossibleName[Random.Shared.Next(0, PossibleName.Length)];
    
    public readonly Rarity Rarity = Random.Shared.Next(0, 10) switch
    {
        < 6 => Rarity.Common,
        < 9 => Rarity.Rare,
        _ => Rarity.Epic
    };
}