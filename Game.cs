using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Main;

public class Game : Microsoft.Xna.Framework.Game
{
    private Texture2D _grassTexture;
    private Texture2D _orcTexture;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    
    public Game()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // 16 x 9 tiles
        // 16 x 16 pixels
        
        _graphics.PreferredBackBufferWidth = 1920;
        _graphics.PreferredBackBufferHeight = 1080;
        _graphics.ApplyChanges();
        
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        
        _grassTexture = Content.Load<Texture2D>("grass");
        _orcTexture = Content.Load<Texture2D>("orc");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(new Color(86, 50, 38));

        // TODO: Add your drawing code here

        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        
        _spriteBatch.Draw(_orcTexture, new Vector2(160, 160), null, Color.White, 0f, Vector2.Zero, 10f, 0, 0);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}