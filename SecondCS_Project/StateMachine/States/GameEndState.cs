using Raylib_cs;
using SecondCS_Project.dataTypes;
using SecondCS_Project.Preloads;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace SecondCS_Project.StateMachine.States
{
    public class GameEndState : GameBasteState
    {
        Assets preLoads = new Assets();

        Text gameOver;
        Text return_menu;
        Text endGame;

        int currentScore;
        int highScore;
        public override void EnterState(GameStateManager game)
        {
            currentScore = game.Playing_State.Score;
            highScore = loadHighScore();

            if (currentScore > highScore)
            {
                highScore = currentScore;
                SaveHighScore(highScore);
            }
        }

        public override void UpdateState(GameStateManager game)
        {
            if (Raylib.IsKeyDown(KeyboardKey.Enter))
            {
                game.switchState(game.MainMenu_State);
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.Escape))
            {
                Raylib.CloseWindow();
            }
        }

        public int loadHighScore()
        {
            if (File.Exists(preLoads.filePath))
            {
                string savedText = File.ReadAllText(preLoads.filePath).Trim();
                if (int.TryParse(savedText, out int savedScore))
                {
                    return savedScore;
                }
            }
            return 0;
        }

        private void SaveHighScore(int score)
        {
            try
            {
                File.WriteAllText(preLoads.filePath, score.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error saving high score: {e.Message}");
            }
        }

        public void Draw()
        {
            gameOver = new Text()
            {
                Content = "Game Over",
                FontSize = 40,
                Position = new Vector2(Raylib.GetScreenCenter().X - 100, Raylib.GetScreenCenter().Y - 80),
                Color = Color.Red
            };

            return_menu = new Text()
            {
                Content = "Press ENTER to return to Menu\nPress ESC to leave",
                FontSize = 20,
                Position = new Vector2(Raylib.GetScreenCenter().X - 130, Raylib.GetScreenCenter().Y + 80),
                Color = Color.White
            };

            endGame = new Text()
            {
                Content = $"Your Score: {currentScore}\nHigh Score: {highScore}",
                FontSize = 25,
                Position = new Vector2(Raylib.GetScreenCenter().X - 100, Raylib.GetScreenCenter().Y - 20),
                Color = Color.Yellow
            };

            gameOver.Draw();
            return_menu.Draw();
            endGame.Draw();
        }
    }
}
