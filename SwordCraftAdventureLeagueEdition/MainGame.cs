using Apos.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SwordCraftAdventureLeagueEdition;

public class MainGame : Game
{
    private readonly GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    public MainGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _graphics.PreferredBackBufferWidth = (int)ScreenManager.Instance.Dimensions.X;
        _graphics.PreferredBackBufferHeight = (int)ScreenManager.Instance.Dimensions.Y;
        _graphics.ApplyChanges();
        
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        InputHelper.Setup(this);

        ScreenManager.Instance.LoadContent(Content);
    }

    protected override void UnloadContent()
    {
        ScreenManager.Instance.UnloadContent();
    }

    protected override void Update(GameTime gameTime)
    {
        InputHelper.UpdateSetup();
        
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        ScreenManager.Instance.Update(gameTime);

        base.Update(gameTime);
        
        InputHelper.UpdateCleanup();
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        
        _spriteBatch.Begin(sortMode: SpriteSortMode.Immediate,
            samplerState: SamplerState.PointClamp,
            blendState: BlendState.AlphaBlend
        );
        ScreenManager.Instance.Draw(_spriteBatch);
        _spriteBatch.End();
        
        base.Draw(gameTime);
    }
}