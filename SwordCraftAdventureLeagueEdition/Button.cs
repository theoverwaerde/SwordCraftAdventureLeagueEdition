using System;
using Apos.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SwordCraftAdventureLeagueEdition;

public class Button
{
    private readonly Texture2D[] _texture2D;
    private Rectangle _rectangle;
    private readonly SpriteEffects _effects;
    private readonly float _animationDelay;
    private int _currentTextureIndex;
    private float _currentDelay;

    public Button(Texture2D[] texture2D, Rectangle rectangle,SpriteEffects effects = SpriteEffects.None,float animationDelay = .5f)
    {
        if (texture2D.Length == 0)
        {
            throw new Exception("Textures can't be empty!");
        }
        
        _texture2D = texture2D;
        _rectangle = rectangle;
        _effects = effects;
        _animationDelay = animationDelay;
    }

    public Action? OnClick { get; set; } = null;

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture2D[_currentTextureIndex], _rectangle, null, Color.White,0,Vector2.Zero,_effects,0);
    }

    public void Update(GameTime gameTime)
    {
        _currentDelay += (float) gameTime.ElapsedGameTime.TotalSeconds;
        if (_currentDelay >= _animationDelay)
        {
            _currentTextureIndex = (_currentTextureIndex + 1) % _texture2D.Length;
            _currentDelay = 0;
        }
        
        if (MouseCondition.IsMouseValid && 
            MouseCondition.Pressed(MouseButton.LeftButton) && 
            _rectangle.Contains(Mouse.GetState().Position))
        {
            OnClick?.Invoke();
        }
    }
}