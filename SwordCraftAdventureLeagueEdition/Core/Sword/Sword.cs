using System;
using System.Text;
using Microsoft.Xna.Framework;

namespace SwordCraftAdventureLeagueEdition.Core.Sword;

public class Sword
{
    public Shape Shape { get; }
    public Material Material { get; }
    public Enchantment? Enchantment { get; }
    private readonly string _defaultName;
    private string? _name;
    private Move[] _moves;
    public string BladeName { get; }
    public Color Color => Material.Color;

    public Sword(Shape shape, Material material, Enchantment? enchantment = null)
    {
        Shape = shape;
        Material = material;
        Enchantment = enchantment;
        BladeName = Shape.GetType().Name;

        _defaultName = GetDefaultName();
        
        _moves = SetMoves();
    }

    private Move[] SetMoves()
    {
        return Array.Empty<Move>();
    }

    public void Rename(string name)
    {
        _name = name;
    }

    public string GetName() => _name ?? _defaultName;
    
    private Rarity SwordRarity
    {
        get
        {
            var rarity = Math.Min((short)Shape.Rarity, (short)Material.Rarity);
            if (Enchantment is null)
            {
                return (Rarity)rarity;
            }
            return (Rarity)Math.Min(rarity, (short)Enchantment.Rarity);
        }
    }

    private string GetDefaultName()
    {
        var stringBuilder = new StringBuilder();
        
        // ReSharper disable once SwitchStatementMissingSomeEnumCasesNoDefault
        switch (SwordRarity)
        {
            case Rarity.Rare:
                stringBuilder.Append("Rare ");
                break;
            case Rarity.Epic:
                stringBuilder.Append("Epic ");
                break;
        }
        
        stringBuilder.Append(Material.GetRandomName());
        stringBuilder.Append(' ');
        stringBuilder.Append(Shape.GetRandomName());

        if (Enchantment is null)
        {
            return stringBuilder.ToString();
        }
        
        stringBuilder.Append(' ');
        stringBuilder.Append(Enchantment.GetRandomName());

        return stringBuilder.ToString();
    }
}