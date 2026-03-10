using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoTutorialLibrary;
using MonoGameLibrary.Graphics;

namespace MonoSnake;

public class Game1 : Core
{
    // texture region that defines the slime sprite in the atlas.
    private TextureRegion _slime;

    // texture region that defines the bat sprite in the atlas.
    private TextureRegion _bat;

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
        //// Load the atlas texture using the content manager
        //Texture2D atlasTexture = Content.Load<Texture2D>("images/atlas");

        ////  Create a TextureAtlas instance from the atlas
        //TextureAtlas atlas = new TextureAtlas(atlasTexture);

        //// add the slime region to the atlas.
        //atlas.AddRegion("slime", 0, 0, 20, 20);

        //// add the bat region to the atlas.
        //atlas.AddRegion("bat", 20, 0, 20, 20);

        // Create the texture atlas from the XML configuration file
        TextureAtlas atlas = TextureAtlas.FromFile(Content, "images/atlas-definition.xml");

        // retrieve the slime region from the atlas.
        _slime = atlas.GetRegion("slime");

        // retrieve the bat region from the atlas.
        _bat = atlas.GetRegion("bat");

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

        // Begin the sprite batch to prepare for rendering.
        SpriteBatch.Begin(SpriteSortMode.FrontToBack);

        // Draw the texture. https://docs.monogame.net/api/Microsoft.Xna.Framework.Graphics.SpriteBatch.html#Microsoft_Xna_Framework_Graphics_SpriteBatch_Draw_Microsoft_Xna_Framework_Graphics_Texture2D_Microsoft_Xna_Framework_Vector2_Microsoft_Xna_Framework_Color_
        // Draw the slime texture region at a scale of 4.0
        _slime.Draw(SpriteBatch, Vector2.Zero, Color.White, 0.0f, Vector2.One, 4.0f, SpriteEffects.None, 0.0f);

        // Draw the bat texture region 10px to the right of the slime at a scale of 4.0
        _bat.Draw(SpriteBatch, new Vector2(_slime.Width * 4.0f + 10, 0), Color.White, 0.0f, Vector2.One, 4.0f, SpriteEffects.None, 1.0f);

        // Always end the sprite batch when finished.
        SpriteBatch.End();

        base.Draw(gameTime);
    }
}
