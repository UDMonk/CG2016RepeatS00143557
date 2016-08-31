using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientGame.Classes.Menu
{
    class MainMenu
    {
        Button bttnLogin;
        Button bttnRegister;
        Button bttnPlay;

        public MainMenu(Texture2D sprBtnPlay, Texture2D sprBtnReg, Texture2D sprBtnLogin)
        {
            bttnLogin = new Button(sprBtnLogin, new Point(250, 50));
            bttnRegister = new Button(sprBtnReg, new Point(250, 250));
            bttnPlay = new Button(sprBtnPlay, new Point(250, 450));
        }

        public void Update(Game1 game)
        {
            if (bttnLogin.CheckMouseClick() == true)
            {
                game.currentState = gameStates.Login;
            }

            if (bttnRegister.CheckMouseClick() == true)
            {
                game.currentState = gameStates.Register;
            }

            if (bttnPlay.CheckMouseClick() == true)
            {
                //Check if player is logged in here before allowing game start
                game.currentState = gameStates.InGame;  //  might be changed to WaitingRoom enum
            }
        }

        public void Draw(SpriteBatch sb, GraphicsDevice gd)
        {
            gd.Clear(Color.MidnightBlue);
            bttnLogin.Draw(sb);
            bttnRegister.Draw(sb);
            bttnPlay.Draw(sb);
        }
    }
}
