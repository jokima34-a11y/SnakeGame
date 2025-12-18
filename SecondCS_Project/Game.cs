using Raylib_cs;
using SecondCS_Project;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;

using SecondCS_Project.dataTypes;
using static Raylib_cs.Raylib;
using SecondCS_Project.StateMachine;
using SecondCS_Project.StateMachine.States;
using SecondCS_Project.Player_Fruit;

namespace SecondCS_Project
{
    class Program
    {
        static void Main()
        {
            new Game().Run();
        }
    }

    class Game
    {
        GameStateManager StateManager;
        public void Run()
        {
            StateManager = new GameStateManager();
            StateManager.fruitHandler = new Fruit();

            StateManager.fruitHandler.Start();
            StateManager.Start();

            Raylib.InitWindow(Const.SCREEN_WIDTH, Const.SCREEN_HEIGHT, "Cool window");
            SetTargetFPS(60);

            while (!Raylib.WindowShouldClose())
            {
                float deltaTime = Raylib.GetFrameTime();
                Update(deltaTime);
                Draw();
            }
            Raylib.CloseWindow();
        }

        private void Update(float DT)
        {
            StateManager.Update(DT);
            StateManager.fruitHandler.Update(DT);
        }

        private void Draw()
        {
            BeginDrawing();
            ClearBackground(Color.Black);

            switch (StateManager.currentState)
            {
                case PlayingState:
                    StateManager.Playing_State.Draw();
                    StateManager.fruitHandler.Draw();
                    break;

                case MainMenuState:
                    StateManager.MainMenu_State.Draw();
                    break;

                case HighScoreState:
                    StateManager.Highscore_State.Draw();
                    break;

                case GameBasteState:
                    StateManager.GameEnd_State.Draw();
                    break;
            }

            EndDrawing();
        }
    }


}
