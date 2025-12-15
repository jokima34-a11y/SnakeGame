using Raylib_cs;
using SecondCS_Project.dataTypes;
using SecondCS_Project.Preloads;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace SecondCS_Project.StateMachine.States
{
    public class HighScoreState : GameBasteState
    {
        Text highScoreText;
        Text highScoreInt;

        Assets preLoads = new Assets();
        public int highScore = 0;

        public override void EnterState(GameStateManager game)
        {
            loadData();
        }

        public override void UpdateState(GameStateManager game)
        {
            //Check if pressed x button, switch state back to main menu
            //also update data
            loadData();

        }

        public void loadData()
        {

            if (File.Exists(preLoads.filePath))
            {
                string saved = File.ReadAllText(preLoads.filePath).Trim();
                int.TryParse(saved, out highScore);
            }
        }

        public void Draw()
        {
            highScoreText =new Text()
            {
                Content = "Highscore:",
                FontSize = 30,
                Position = new Vector2(Raylib.GetScreenCenter().X - 65, Raylib.GetScreenCenter().Y - 30),
                Color = Color.White
            };

            highScoreInt = new Text()
            {
                Content = highScore.ToString(),
                FontSize = 30,
                Position = new Vector2(Raylib.GetScreenCenter().X - 15, Raylib.GetScreenCenter().Y + 10),
                Color = Color.White
            };

            highScoreInt.Draw();
            highScoreText.Draw();
        }
    }
}
