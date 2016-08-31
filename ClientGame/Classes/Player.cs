using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientGame.Classes
{
    class Player
    {
        Bat bat;
        public Bat Bat { get { return bat; } }

        public Player(Bat selected)
        {
            bat = selected;
        }

        public void Move()
        {
            if(Keyboard.GetState().IsKeyDown(Keys.W))
                bat.position.Y -= 5;
            if (Keyboard.GetState().IsKeyDown(Keys.S))
                bat.position.Y += 5;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Begin();
            sb.Draw(bat.Sprite, new Rectangle(bat.position.X, bat.position.Y, 12, 128), Color.White);
            sb.End();
        }
    }
}
