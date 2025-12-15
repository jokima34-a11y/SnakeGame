using Raylib_cs;
using SecondCS_Project;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Text.Json;

namespace SecondCS_Project.dataTypes
{
    class Sprite
    {
        private static List<Sprite> Sprites = new List<Sprite>();

        private Vector2 Position;
        private Rectangle Rect;
        private Texture2D? texture;
        
        public Sprite(Rectangle rect, Vector2 playerOffset, Texture2D? texture=null)
        {
            Rect = rect;
            Position = new Vector2(playerOffset.X + rect.X,
                                   playerOffset.Y + rect.Y);
            Sprites.Add(this);
        }

        public void removeSprite()
        {
            Sprites.Remove(this);
            if (texture != null)
                Raylib.UnloadTexture((Texture2D) texture);
        }

        public void Draw(bool isText=false)
        {
            if (texture != null)
            {
                Raylib.DrawTexture((Texture2D)texture, (int)Position.X, (int)Position.Y, Color.White);
            }
            else
            {
                Raylib.DrawRectangle((int)Position.X, (int)Position.Y, (int)Rect.Width, (int)Rect.Height, Color.White);
            }
        }
        public Rectangle getRect() => Rect;
        public Vector2 getPosition() => Position;
        public List<Sprite> GetSprites() => Sprites;
    }
}
