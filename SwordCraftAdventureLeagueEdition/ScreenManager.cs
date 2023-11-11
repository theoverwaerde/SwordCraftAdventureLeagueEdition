using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SwordCraftAdventureLeagueEdition;

public class ScreenManager
{
    private static ScreenManager? _instance;
    public static ScreenManager Instance => _instance ??= new ScreenManager();
    public Vector2 Dimensions { get; private set; } = new(640, 480);
    public ContentManager Content { get; private set; }

    private Screen _currentScreen = new GameScreen();


    public void ChangeScreen(string screenName)
    {
        Screen newScreen =
            (Screen)Activator.CreateInstance(Type.GetType(GetType().Namespace! + '.' + screenName, true, true)!)!;
        
        _currentScreen.UnloadContent();
        _currentScreen = newScreen;
        _currentScreen.LoadContent();
    }

    public void LoadContent(ContentManager content)
    {
        Content = new ContentManager(content.ServiceProvider, "Content");
        _currentScreen.LoadContent();
    }

    public void UnloadContent()
    {
        _currentScreen.UnloadContent();
    }

    public void Update(GameTime gameTime)
    {
        _currentScreen.Update(gameTime);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        _currentScreen.Draw(spriteBatch);
    }
}