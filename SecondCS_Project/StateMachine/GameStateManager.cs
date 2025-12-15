using SecondCS_Project.StateMachine.States;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecondCS_Project.StateMachine
{
    public class GameStateManager
    {
        public GameBasteState currentState;
        public HighScoreState Highscore_State = new HighScoreState();
        public MainMenuState MainMenu_State = new MainMenuState();
        public PlayingState Playing_State = new PlayingState();
        
        public void Start()
        {
            currentState = MainMenu_State;
            currentState.EnterState(this);
        }

        public void Update(float DeltaTime)
        {
            currentState.UpdateState(this);
        }

        public void switchState(GameBasteState newState)
        {
            currentState = newState;
            currentState.EnterState(this);
        }
    }
}
