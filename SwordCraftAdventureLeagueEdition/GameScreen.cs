using System;
using System.Collections.Generic;
using Apos.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SwordCraftAdventureLeagueEdition.Core;
using SwordCraftAdventureLeagueEdition.Core.Sword;
using SwordCraftAdventureLeagueEdition.Core.Sword.Materials;
using SwordCraftAdventureLeagueEdition.Core.Sword.Shapes;

namespace SwordCraftAdventureLeagueEdition;

public class GameScreen : Screen
{
    private readonly Dictionary<string, SwordTextures> _swordTextures = new();
    private Sword _sword;
    private Rectangle _rectangle;
    private Texture2D _starTexture;
    private readonly Texture2D[] _arrowTextures = new Texture2D[2];
    
    private Button button1;
    private Button button2;
    private Button button3;
    private Button button4;

    private int currentMatIndex;
    private int currentShapeIndex;
    
    Shape shape;
    Material material;

    public record SwordTextures(Texture2D Base, Texture2D Blade);
    
    public override void LoadContent()
    {
        base.LoadContent();

        LoadSwordTextures();
        _starTexture = ContentManager.Load<Texture2D>("Images/Star");
        
        _arrowTextures[0] = ContentManager.Load<Texture2D>("Images/arrow1");
        _arrowTextures[1] = ContentManager.Load<Texture2D>("Images/arrow2");
    }

    private void LoadSwordTextures()
    {
        foreach (Type type in typeof(Shape).Assembly.GetTypes())
        {
            if (type.BaseType != typeof(Shape))
            {
                continue;
            }
            
            var strings = type.FullName!.Split('.');
            var categories = strings[^2];
            var name= strings[^1].Replace(type.BaseType!.Name,string.Empty);
            
            Texture2D? swordBase = ContentManager.Load<Texture2D>($"Images/{categories}/{name}_Base");
            Texture2D? swordBlade = ContentManager.Load<Texture2D>($"Images/{categories}/{name}_Blade");

            var textures = new SwordTextures(swordBase, swordBlade);
            _swordTextures.Add(type.Name,textures);
        }
        
        UpdateMat();
        UpdateShape();
        
        UpdateSword();
        
        _rectangle = new Rectangle(0, 0, 64, 64);

        button1 = new Button(_arrowTextures, new Rectangle(100, 0, 32, 32));
        button1.OnClick += NextMat;

        button2 = new Button(_arrowTextures, new Rectangle(60, 0, 32, 32),SpriteEffects.FlipHorizontally);
        button2.OnClick += PrevMat;
        

        button3 = new Button(_arrowTextures, new Rectangle(220, 0, 32, 32));
        button3.OnClick += NextShape;

        button4 = new Button(_arrowTextures, new Rectangle(180, 0, 32, 32),SpriteEffects.FlipHorizontally);
        button4.OnClick += PrevShape;
        return;

        void NextMat()
        {
            currentMatIndex = (currentMatIndex + 1) % 3;
            UpdateMat();
            UpdateSword();
        }
        
        void PrevMat()
        {
            currentMatIndex--;
            if (currentMatIndex == -1)
            {
                currentMatIndex = 2;
            }

            UpdateMat();
            UpdateSword();
        }

        void UpdateMat()
        {
            material = currentMatIndex switch
            {
                0 => new WoodenMaterial(),
                1 => new IronMaterial(),
                2 => new GoldMaterial(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        void NextShape()
        {
            currentShapeIndex = (currentShapeIndex + 1) % 2;
            UpdateShape();
            UpdateSword();
        }
        
        void PrevShape()
        {
            currentShapeIndex--;
            if (currentShapeIndex == -1)
            {
                currentShapeIndex = 1;
            }

            UpdateShape();
            UpdateSword();
        }

        void UpdateShape()
        {
            shape = currentShapeIndex switch
            {
                0 => new OneHandedShape(),
                1 => new LongswordShape(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        void UpdateSword()
        {
            _sword = new Sword(shape, material);
        }
    }
    
    public override void Update(GameTime gameTime)
    {
        button1.Update(gameTime);
        button2.Update(gameTime);
        button3.Update(gameTime);
        button4.Update(gameTime);
        
        if (KeyboardCondition.Held(Keys.Z))
        {
            _rectangle.Y -= 1;
        }
        if (KeyboardCondition.Held(Keys.S))
        {
            _rectangle.Y += 1;
        }
        if (KeyboardCondition.Held(Keys.Q))
        {
            _rectangle.X -= 1;
        }
        if (KeyboardCondition.Held(Keys.D))
        {
            _rectangle.X += 1;
        }
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        DrawSword(spriteBatch, _sword, _rectangle);
        
        spriteBatch.Draw(_starTexture,new Vector2(0),_sword.Shape.Rarity.Color());
        spriteBatch.Draw(_starTexture,new Vector2(16),_sword.Material.Rarity.Color());
        
        button1.Draw(spriteBatch);
        button2.Draw(spriteBatch);
        button3.Draw(spriteBatch);
        button4.Draw(spriteBatch);
    }

    private void DrawSword(SpriteBatch spriteBatch, Sword sword, Rectangle rectangle)
    {
        var textures = _swordTextures[sword.BladeName];
        
        spriteBatch.Draw(textures.Base, rectangle, Color.White);
        spriteBatch.Draw(textures.Blade, rectangle, sword.Color);
    }
}