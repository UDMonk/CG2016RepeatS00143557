using ClientGame.Classes.Menu;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ClientGame
{
    public enum gameStates { Main, Waiting, Pause, Login, Register, InGame };
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        DisplayMenu pauseMenu;
        MainMenu mainMenu;

        KeyboardState kbNew;
        KeyboardState kbOld;

        Texture2D spriteContinueBttn;
        Texture2D spriteLoginBttn;
        Texture2D spriteRegBttn;
        Texture2D spritePlayBttn;
        SpriteFont defaultFont;

        public gameStates currentState = gameStates.Main;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            IsMouseVisible = true;
            kbNew = Keyboard.GetState();
            kbOld = Keyboard.GetState();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            defaultFont = Content.Load<SpriteFont>("SpriteFonts/Default");
            spriteContinueBttn = Content.Load<Texture2D>("Sprites/ContinueBttn");
            spriteLoginBttn = Content.Load<Texture2D>("Sprites/LoginBttn");
            spriteRegBttn = Content.Load<Texture2D>("Sprites/RegBttn");
            spritePlayBttn = Content.Load<Texture2D>("Sprites/PlayBttn");
            pauseMenu = new DisplayMenu(spriteContinueBttn);
            mainMenu = new MainMenu(spritePlayBttn, spriteRegBttn, spriteLoginBttn);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (currentState == gameStates.InGame)
            {
                if (kbNew.IsKeyDown(Keys.Enter) && kbOld != kbNew)
                {
                    currentState = gameStates.Pause;
                }
            }

            if (currentState == gameStates.Pause)
            {
                pauseMenu.Update(gameTime, kbNew, kbOld, this);
            }

            if (currentState == gameStates.Main)
            {
                mainMenu.Update(this);
            }

            base.Update(gameTime);

            kbOld = kbNew;
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            if (currentState == gameStates.InGame)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);
            }


            if (currentState == gameStates.Pause)
            {
                pauseMenu.Draw(spriteBatch, GraphicsDevice);
            }

            if (currentState == gameStates.Main)
            {
                mainMenu.Draw(spriteBatch, GraphicsDevice);
            }

            if (currentState == gameStates.Login)
            {
                spriteBatch.Begin();
                spriteBatch.DrawString(defaultFont, "Alas, you can only lament the login code and it's regrettable 'not finished' attribute.", Vector2.Zero, Color.Red);
                spriteBatch.End();
            }

            if (currentState == gameStates.Register)
            {
                spriteBatch.Begin();
                spriteBatch.DrawString(defaultFont, "Ahaha, you thought the register code had been added? How foolish.", Vector2.Zero, Color.Red);
                spriteBatch.End();
            }

            base.Draw(gameTime);
        }
    }
}
