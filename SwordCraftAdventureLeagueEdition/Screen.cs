using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SwordCraftAdventureLeagueEdition;

public abstract class Screen
{
    protected ContentManager ContentManager;
    public virtual void LoadContent()
    {
        ContentManager = new ContentManager(ScreenManager.Instance.Content.ServiceProvider, "Content");

    }
    
    public virtual void UnloadContent()
    {
        ContentManager.Unload();
    }

    public virtual void Update(GameTime gameTime)
    {
        
    }

    public virtual void Draw(SpriteBatch spriteBatch)
    {
        
    }
}