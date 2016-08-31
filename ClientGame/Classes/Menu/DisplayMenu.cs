using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientGame.Classes.Menu
{
    class DisplayMenu
    {
        Button bttnContinue;

        //Data should be brought down from the SERVER, more specifically from the PLAYERLIST. Four slots, one for each of the four players.
        //If no data available, say N/A (Not Applicable)
        //If possible, display in order of score/health, so that pausing the game shows who's 'winning' or 'losing' at that time.

        public DisplayMenu(Texture2D bttnContinueSprite)
        {
            //code to interperate display goes here, feed in playerStates and display
            bttnContinue = new Button(bttnContinueSprite, new Point(100, 200));
        }


        public void Update(GameTime gameTime, KeyboardState kbNew, KeyboardState kbOld, Game1 game)
        {
            if (bttnContinue.CheckMouseClick())
            {
                game.currentState = gameStates.InGame;
            }
        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDevice gd)//GraphicsDevice will not be passed to this draw in the finished version, purely for test purposes
        {
            gd.Clear(Color.Firebrick);
            bttnContinue.Draw(spriteBatch);

            //spriteBatch.Begin();

            //spriteBatch.End();

        }
    }
}
