﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tetris
{
    public class CharacterSelection : GameState
    {
        private Texture2D background;

        //buttons (and button textures)
        private Button nextButton;
        private CharacterProfile kazuma, aqua, megumin, darkness;
        private Texture2D kazumaNormal, kazumaHover, aquaNormal, aquaHover, meguminNormal, meguminHover, darknessNormal, darknessHover, buttonNone, buttonHover;

        //fonts
        private SpriteFont gameFont, menuFont;

        public CharacterSelection(GraphicsDevice graphicsDevice)
        : base(graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;
        }

        public override void Initialize()
        {

        }

        public override void LoadContent(ContentManager content)
        {

            //Load 2D textures
            //background = content.Load<Texture2D>("textures/mainmenubg");

            //Load button textures
            kazumaNormal = content.Load<Texture2D>("textures/character/kazumaButton");
            kazumaHover = content.Load<Texture2D>("textures/character/kazumaHover");
            aquaNormal = content.Load<Texture2D>("textures/character/aquaButton");
            aquaHover = content.Load<Texture2D>("textures/character/aquaHover");
            meguminNormal = content.Load<Texture2D>("textures/character/meguminButton");
            meguminHover = content.Load<Texture2D>("textures/character/meguminHover");
            darknessNormal = content.Load<Texture2D>("textures/character/darknessButton");
            darknessHover = content.Load<Texture2D>("textures/character/darknessHover");

            buttonNone = content.Load<Texture2D>("textures/button_normal");
            buttonHover = content.Load<Texture2D>("textures/button_hover");

            // Load font
            gameFont = content.Load<SpriteFont>("spritefonts/gameFont");
            menuFont = content.Load<SpriteFont>("spritefonts/menuFont");

            //load characters
            kazuma = new CharacterProfile(new Rectangle(120, 150, 260, 470), kazumaNormal, kazumaHover);
            aqua = new CharacterProfile(new Rectangle(380, 150, 260, 470), aquaNormal, aquaHover);
            megumin = new CharacterProfile(new Rectangle(640, 150, 260, 470), meguminNormal, meguminHover);
            darkness = new CharacterProfile(new Rectangle(900, 150, 260, 470), darknessNormal, darknessHover);

            // Load buttons 
            nextButton = new Button(new Rectangle(440, 640, 400, 50), gameFont, "Next", Color.White, buttonNone, buttonHover, buttonNone);
        }

        public override void UnloadContent()
        {
        }

        public override void Update(GameTime gameTime)
        {
            // Gets keyboard input
            KeyboardState keyboardState = Keyboard.GetState();
            MouseState mouseState = Mouse.GetState();
            //if (keyboardState.IsKeyDown(Keys.Escape))  this.Exit();

            //check if character is selected, then deselects other characters
            kazuma.Update(mouseState);
            if (kazuma.Selected)
            {
                aqua.Selected = false;
                megumin.Selected = false;
                darkness.Selected = false;
            }

            aqua.Update(mouseState);
            if (aqua.Selected)
            {
                kazuma.Selected = false;
                megumin.Selected = false;
                darkness.Selected = false;
            }

            megumin.Update(mouseState);
            if (megumin.Selected)
            {
                aqua.Selected = false;
                kazuma.Selected = false;
                darkness.Selected = false;
            }

            darkness.Update(mouseState);
            if (darkness.Selected)
            {
                aqua.Selected = false;
                megumin.Selected = false;
                kazuma.Selected = false;
            }

            nextButton.Update(mouseState);

            if (nextButton.State == Button.GuiButtonState.Released)
            {
                //run game
                if (kazuma.Selected)
                    GameStateManager.Instance.AddScreen(new Engine(_graphicsDevice, Character.Kazuma));
                if (aqua.Selected)
                    GameStateManager.Instance.AddScreen(new Engine(_graphicsDevice, Character.Aqua));
                if (megumin.Selected)
                    GameStateManager.Instance.AddScreen(new Engine(_graphicsDevice, Character.Megumin));
                if (darkness.Selected)
                    GameStateManager.Instance.AddScreen(new Engine(_graphicsDevice, Character.Darkness));
            }

            if (keyboardState.IsKeyDown(Keys.Escape))
            {
                GameStateManager.Instance.RemoveScreen();
            }

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(background, Vector2.Zero, Color.White);
            //spriteBatch.DrawString(menuFont, "Main Menu", new Vector2(200, 100), Color.Black);

            kazuma.Draw(spriteBatch);
            aqua.Draw(spriteBatch);
            megumin.Draw(spriteBatch);
            darkness.Draw(spriteBatch);

            nextButton.Draw(spriteBatch);
        }
    }
}