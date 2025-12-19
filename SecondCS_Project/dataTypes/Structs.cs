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

        public TextCollision(Vector2 position, int fontSize, string textContent) //could use a "text' type instead
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

    struct objectCollision
    {
        Vector2 Target_position;
        Vector2 Object_position;

        Rectangle targetBounds;
        Rectangle objectBounds;

        public objectCollision(Vector2 targetPosition, Vector2 objectPostition, float height=Const.TileSize)
        {
            Target_position = targetPosition;
            Object_position = objectPostition;

            targetBounds = new Rectangle(targetPosition.X,
                targetPosition.Y, Const.TileSize, Const.TileSize);
            objectBounds = new Rectangle(objectPostition.X,
                objectPostition.Y, Const.TileSize, height);
        }

        public bool checkCollision()
        {
            if (Raylib.CheckCollisionRecs(objectBounds, targetBounds))
                return true;
            else
                return false;
        }
    }
}
