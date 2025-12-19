using Raylib_cs;
using SecondCS_Project.dataTypes;
using SecondCS_Project.StateMachine;
using System.Collections.Generic;
using System.Numerics;

namespace SecondCS_Project.Player_Fruit
{
    public class Snake
    {
        public List<Vector2> Segments { get; private set; } = new List<Vector2>();
        Input inputHandler = new Input();

        public Vector2 Direction { get; private set; }
        private Vector2 pendingDirection;
        public int Score { get; private set; }

        objectCollision collision;
        objectCollision collision2;

        public int Length => Segments.Count;
        public int GetScore => Score;
        public Vector2 Head => Segments[0];

        public float GracePeriod = 0;
        public float updateCD = 0;

        public Snake(Vector2 spawnPosition)
        {
            Direction = new Vector2(1, 0);
            pendingDirection = Direction;
            

            Segments.Add(spawnPosition); //head
            Segments.Add(spawnPosition - new Vector2(Const.TileSize, 0)); //1st tail
            Segments.Add(spawnPosition - new Vector2(Const.TileSize * 2, 0)); //2nd tail
           
        }

        public void HandleInput()
        {
            if (Direction.X == 0) 
            {
                pendingDirection = new Vector2(inputHandler.GetHorizontal("Horizontal"), 0);
            }
            else if (Direction.Y == 0)
            {
                pendingDirection = new Vector2(0, inputHandler.GetVertical("Vertical"));
            }
        }

        public void Update(float deltatime, Fruit fruitManager, GameStateManager stateMachine)
        {
            HandleInput();

            updateCD += deltatime;
            if (updateCD >= 0.15)
            {
                if (pendingDirection != Vector2.Zero &&
                    pendingDirection != -Direction)
                {
                    Direction = pendingDirection;
                }

                Vector2 newHead = Head + (Direction * Const.TileSize); 
                //same thing as
                //head.x = spawnpoint + (Direction.x * TileSize)
                //head.y = spawnpoint + (Direction.y * Tilesize)
                Segments.Insert(0, newHead); //index 0

                if (checkFruitCollision(fruitManager.position))
                {
                    // Do nothing → snake grows naturally
                    Score++;
                    fruitManager.regeneratePosition();
                }
                else
                {
                    Segments.RemoveAt(Segments.Count - 1);
                }

                if (GracePeriod > 1.5)
                {
                    if (checkForSelfCollision())
                    {
                        endGame(stateMachine);
                    }
                }
                else
                {
                    GracePeriod += deltatime;
                }

                updateCD = 0;
            }
        }

        public bool checkFruitCollision(Vector2 fruitPosition)
        {
            collision = new objectCollision(fruitPosition, Head);
            if (collision.checkCollision())
                return true;
            else
                return false;
        }

        public bool checkForSelfCollision()
        {
            for (int i = 1; i < Length; ++i)
            {
                Vector2 segmentPosition = Segments[i];
                collision2 = new objectCollision(segmentPosition, Head);
                if (collision2.checkCollision())
                {
                    return true;
                }
            }
            return false;
        }

        public void endGame(GameStateManager stateMachine)
        {
            stateMachine.switchState(stateMachine.GameEnd_State);
        }
        public void Draw()
        {
            for (int i = 0; i < Segments.Count; i++)
            {
                Vector2 pos = Segments[i];
                var rect = new Rectangle(pos.X, pos.Y, Const.TileSize, Const.TileSize);

                Color color = i == 0 ? Color.Green : Color.DarkGreen;

                Raylib.DrawRectangleRounded(rect, 0.2f, 10, color);
                Raylib.DrawRectangleLinesEx(rect, 2, Color.Black);
            }
        }
    }
}