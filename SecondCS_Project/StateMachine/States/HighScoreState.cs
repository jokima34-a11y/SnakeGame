using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace SecondCS_Project.StateMachine.States
{
    public class HighScoreState : GameBasteState
    {
        Vector2 drawOffset = new Vector2(65, 30);

        public override void EnterState(GameStateManager game)
        {
            
        }

        public override void UpdateState(GameStateManager game)
        {

        }

        public void Draw()
        {
            Raylib.DrawText("Highscores",
                (int)Raylib.GetScreenCenter().X - (int)drawOffset.X,
                (int)Raylib.GetScreenCenter().Y - (int)drawOffset.Y,
                30,
                Color.White);
        }
    }
}
