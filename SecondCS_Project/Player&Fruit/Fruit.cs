using Raylib_cs;
using SecondCS_Project.dataTypes;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace SecondCS_Project.Player_Fruit
{
    
    public class Fruit
    {
        public bool isEaten = false;
        public bool isSpawned = false;

        Const constants = new Const();
        private Random random = new Random();
        public Vector2 position;

        public Fruit()
        {
            position = new Vector2(0,0);
        }

        public void Start()
        {
            if (isSpawned != true)
            {
                position = generatePosition();
                isSpawned = true;
            }
        }
        public void Update(float dt)
        {
            if (isEaten)
            {
                position = generatePosition();
                isEaten = false;
            }
        }

        public void Draw()
        {
            Raylib.DrawRectangle((int)position.X, (int)position.Y, Const.TileSize, Const.TileSize, Color.Red);
        }

        public Vector2 generatePosition()
        {
            return new Vector2(random.Next(1, Const.cellCount) * Const.TileSize, random.Next(1, Const.cellCount) * Const.TileSize);
        }

        public void regeneratePosition()
        {
            position = generatePosition();
        }
    }
}
