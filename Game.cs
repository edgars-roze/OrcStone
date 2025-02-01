using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Main;

public class Game : Microsoft.Xna.Framework.Game
{
    private Texture2D _grassTexture;
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
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here

        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

        Vector2 position = new Vector2(0, 0);

        for (position.Y = 0; position.Y < 1440; position.Y += 160) {
            for (position.X = 0; position.X < 2560; position.X += 160)
            {
                _spriteBatch.Draw(_grassTexture, position, null, Color.White, (((int)(position.X / 160) ^ (int)(position.Y / 80)) * 90 * Single.Pi/180), new Vector2(_grassTexture.Width * 0.5f, _grassTexture.Height * 0.5f), 10f, 0, 0f);
            }
        }

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}