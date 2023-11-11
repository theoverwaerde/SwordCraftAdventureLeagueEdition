using SwordCraftAdventureLeagueEdition.Core.Sword;
using SwordCraftAdventureLeagueEdition.Core.Sword.Materials;
using SwordCraftAdventureLeagueEdition.Core.Sword.Shapes;
using Xunit;
using Xunit.Abstractions;

namespace SwordCraftAdventureLeagueEdition.UnitTests;

public class SwordTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public SwordTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Constructor_Should()
    {
        Shape shape = new LongswordShape();
        Material material = new WoodenMaterial();
        var sut = new Sword(shape, material);
        
        _testOutputHelper.WriteLine(sut.GetName());
    }
}