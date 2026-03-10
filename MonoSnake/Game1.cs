using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoTutorialLibrary;

namespace MonoSnake;

public class Game1 : Core
{
    private Texture2D _logo;

    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    public Game1()                         // script order #1
        : base("Dungeon Slime", 1280, 720, false)
    {
    }

    protected override void Initialize()   // script order #2
    {
        base.Initialize();
    }

    protected override void LoadContent()  // script order #3-ish, called via base.Initialize();
    {
        _logo = Content.Load<Texture2D>("images/mgLogo");
        //base.LoadContent();
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // Begin the sprite batch to prepare for rendering.
        SpriteBatch.Begin();

        // Draw the logo texture
        SpriteBatch.Draw(_logo, Vector2.Zero, Color.White);

        // Always end the sprite batch when finished.
        SpriteBatch.End();

        base.Draw(gameTime);
    }
}
