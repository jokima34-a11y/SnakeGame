using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace SecondCS_Project.dataTypes
{
   struct Text
    {
        public string Content;
        public int FontSize;
        public Vector2 Position;
        public Color Color;

        public Text(string content, int fontSize, int posX, int posY, Color? color = null)
        {
            Content = content;
            FontSize = fontSize;
            Position = new Vector2(posX, posY);

            // Use provided color or default to WHITE
            Color = color ?? Raylib_cs.Color.White;
        }

        public void Draw()
        {
            Raylib_cs.Raylib.DrawText(
                Content,
                (int)Position.X,
                (int)Position.Y,
                FontSize,
                Color
            );
        }
        Vector2 GetPosition() => this.Position;
    }

    struct TextCollision
    {
        Vector2 Position;
        Rectangle playBounds;

        public TextCollision(Vector2 position, int fontSize, string textContent)
        {
            Position = position;

            playBounds = new Rectangle(
                Position.X,
                Position.Y,
                Raylib.MeasureText(textContent, fontSize),
                fontSize
            );
        }

        public bool checkCollision()
        {
            if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), playBounds))
                return true;
            else
                return false;
        }
    }
}
