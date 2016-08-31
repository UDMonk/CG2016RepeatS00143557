﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientGame.Classes.Menu
{
    class Button
    {
        Texture2D bSprite;
        Rectangle clickBox = new Rectangle();
        Point bttnLocation;

        public Button(Texture2D buttonSprite, Point location)
        {
            bSprite = buttonSprite;
            bttnLocation = location;
            clickBox.Height = bSprite.Height;
            clickBox.Width = bSprite.Width;
            clickBox.X = bttnLocation.X;
            clickBox.Y = bttnLocation.Y;
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(bSprite, clickBox, Color.White);
            spriteBatch.End();
        }

        public bool CheckMouseClick()
        {
            MouseState m = Mouse.GetState();
            if (m.LeftButton == ButtonState.Pressed)
                if (this.clickBox.Contains(new Point(m.X, m.Y)))
                    return true;
                else return false;
            else return false;
        }
    }
}
