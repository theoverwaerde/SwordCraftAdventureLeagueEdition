using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SwordCraftAdventureLeagueEdition;

public class SplashScreen : Screen
{
    private Texture2D _image;
    private string _path;

    private double _waiting;
    private const double NeedWait = 2;

    public override void LoadContent()
    {
        base.LoadContent();

        _path = "josephine";
        _image = ContentManager.Load<Texture2D>(_path);
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        var size = (int)Math.Min(ScreenManager.Instance.Dimensions.X, ScreenManager.Instance.Dimensions.Y);
        var x = (int) (ScreenManager.Instance.Dimensions.X * .5f - size * .5f);
        var y = (int) (ScreenManager.Instance.Dimensions.Y * .5f - size * .5f);
        spriteBatch.Draw(_image,new Rectangle(x,y,size,size), Color.White);
    }

    public override void Update(GameTime gameTime)
    {
        _waiting += gameTime.ElapsedGameTime.TotalSeconds;
        if (_waiting > NeedWait)
        {
            ScreenManager.Instance.ChangeScreen(nameof(GameScreen));
        }
    }
}