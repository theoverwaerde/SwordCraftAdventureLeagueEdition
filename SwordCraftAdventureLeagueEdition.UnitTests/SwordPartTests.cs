using FluentAssertions;
using SwordCraftAdventureLeagueEdition.Core.Sword.Shapes;
using Xunit;

namespace SwordCraftAdventureLeagueEdition.UnitTests;

public class SwordPartTests
{
    [Fact]
    public void Constructor_ShouldDefinedElement()
    {
        var sut = new OneHandedShape();
        
        sut.BaseIconPath.Should().Be("Images/Shapes/OneHanded_Base");
        sut.BladeIconPath.Should().Be("Images/Shapes/OneHanded_Blade");
        sut.Rarity.Should().BeDefined();
    }
}