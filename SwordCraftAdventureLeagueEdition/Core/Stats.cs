namespace SwordCraftAdventureLeagueEdition.Core;

public class Stats
{
    private readonly int _damage;
    private readonly int _speed;
    private readonly int _range;
    private readonly int _weight;

    public Stats(int damage = 0, int speed = 0,int range = 1,int weight = 1)
    {
        _damage = damage;
        _speed = speed;
        _range = range;
        _weight = weight;
    }
}