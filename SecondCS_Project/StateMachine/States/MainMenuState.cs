using Raylib_cs;
using SecondCS_Project.dataTypes;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace SecondCS_Project.StateMachine.States
{
    public class MainMenuState : GameBasteState
    {
        Text MainMenu;
        Text Play;
        Text Highscores;

        Vector2 drawOffset = new Vector2(65, 30);
        public override void EnterState(GameStateManager game)
        {
            
        }

        public override void UpdateState(GameStateManager game)
        {
            if (isTouchingPlayButton() && Raylib.IsMouseButtonPressed(MouseButton.Left))
                game.switchState(game.Playing_State);

            else if (isTouchingHighscoreButton() && Raylib.IsMouseButtonPressed(MouseButton.Left))
                game.switchState(game.Highscore_State);
        }

        public void Draw()
        {
            MainMenu = new Text()
            {
                Content = "Main Menu",
                FontSize = 30,
                Position = new Vector2(Raylib.GetScreenCenter().X - drawOffset.X, Raylib.GetScreenCenter().Y - drawOffset.Y),
                Color = Color.White
            };

            Play = new Text()
            {
                Content = "Play",
                FontSize = 20,
                Position = new Vector2(Raylib.GetScreenCenter().X - drawOffset.X, Raylib.GetScreenCenter().Y + 40),
                Color = Color.White
            };

            Highscores = new Text()
            {
                Content = "Highscores",
                FontSize = 20,
                Position = new Vector2(Raylib.GetScreenCenter().X - drawOffset.X, Raylib.GetScreenCenter().Y + 80),
                Color = Color.White
            };

            MainMenu.Draw();
            Play.Draw();
            Highscores.Draw();
        }

        private bool isTouchingPlayButton()
        {
            TextCollision playCollision = new TextCollision(Play.Position, Play.FontSize, Play.Content);
            if (playCollision.checkCollision())
                return true;
            else 
                return false;
        }

        private bool isTouchingHighscoreButton()
        {
            TextCollision highscoreCollision = new TextCollision(Highscores.Position, Highscores.FontSize, Highscores.Content);
            if (highscoreCollision.checkCollision())
                return true;
            else
                return false;
        }

    }
}
