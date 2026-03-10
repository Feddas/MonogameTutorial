using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoTutorialLibrary;

namespace MonoSnake;

public class Game1 : Core
{
    private Vector2 _screenCenter;
    private Vector2 _logoCenter;
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
        _screenCenter = new Vector2(Window.ClientBounds.Width * 0.5f, Window.ClientBounds.Height * 0.5f);

        _logo = Content.Load<Texture2D>("images/mgLogo");
        _logoCenter = new Vector2(_logo.Width * 0.5f, _logo.Height * 0.5f);
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

        //// The bounds of the icon within the texture.
        //Rectangle iconSourceRect = new Rectangle(0, 0, 128, 128);

        //// The bounds of the word mark within the texture.
        //Rectangle wordmarkSourceRect = new Rectangle(150, 34, 458, 58);

        // Begin the sprite batch to prepare for rendering.
        SpriteBatch.Begin(SpriteSortMode.FrontToBack);

        // Draw the texture. https://docs.monogame.net/api/Microsoft.Xna.Framework.Graphics.SpriteBatch.html#Microsoft_Xna_Framework_Graphics_SpriteBatch_Draw_Microsoft_Xna_Framework_Graphics_Texture2D_Microsoft_Xna_Framework_Vector2_Microsoft_Xna_Framework_Color_
        SpriteBatch.Draw(
            _logo,              // texture
            _screenCenter,      // position
            null,               // sourceRectangle
            Color.White,        // color
            MathHelper.ToRadians(gameTime.TotalGameTime.Milliseconds * .1f),               // rotation
            _logoCenter,        // origin / pivot for rotation and scale
            1.0f,               // scale
            SpriteEffects.None, // effects
            0.0f                // layerDepth
        );


        // Always end the sprite batch when finished.
        SpriteBatch.End();

        base.Draw(gameTime);
    }
}
