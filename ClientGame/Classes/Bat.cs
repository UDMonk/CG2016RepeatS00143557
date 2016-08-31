using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientGame.Classes
{
    public class Bat
    {
        string batid;
        public string BatID { get { return batid; } }

        public Point position;
        private Texture2D sprite;
        public Texture2D Sprite { get { return sprite; } }
        public int score = 0;

        public Rectangle ReturnRectangle()
        {
            return new Rectangle(position.X, position.Y, 12, 128);
        }

        public Bat(Texture2D spr, Point pos, string bid)
        {
            sprite = spr;
            position = pos;
            batid = bid;
        }
    }
}
