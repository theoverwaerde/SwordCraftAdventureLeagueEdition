namespace SwordCraftAdventureLeagueEdition.Core.Sword;

public abstract class Shape : SwordPart
{
    private string IconPath
    {
        get
        {
            var strings = GetType().FullName!.Split('.');
            var categories = strings[^2];
            var name= strings[^1].Replace(GetType().BaseType!.Name,string.Empty);
            return $"Images/{categories}/{name}";
        }
    }
    
    public string BaseIconPath => $"{IconPath}_Base";
    public string BladeIconPath => $"{IconPath}_Blade";
}