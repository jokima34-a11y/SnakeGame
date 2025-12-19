using Raylib_cs;
using SecondCS_Project.dataTypes;
using SecondCS_Project.Player_Fruit;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Xml.Linq;

namespace SecondCS_Project.StateMachine.States
{
    public class PlayingState : GameBasteState
    {
        private Text scoreText;
        public Snake snake;

        public int Score = 0;

        public override void EnterState(GameStateManager game)
        {
            snake = new Snake(new Vector2(10, 10) * Const.TileSize);
        }

        public override void UpdateState(GameStateManager game, float deltaTime)
        {
            snake.Update(deltaTime, game.fruitHandler, game);
            Score = snake.GetScore;
        }

        public void Draw()
        {
            Text_Draw();
            snake.Draw();
        }

        public void Text_Draw()
        {
            scoreText = new Text(Score.ToString(),
            50,
            (int)Raylib.GetScreenCenter().X / 4,
            (int)Raylib.GetScreenCenter().Y / 4);

            scoreText.Draw();
        }
    }
}
