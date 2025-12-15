using System;
using System.Collections.Generic;
using System.Text;

namespace SecondCS_Project.StateMachine
{
    public abstract class GameBasteState
    {
        public abstract void EnterState(GameStateManager game);
        public abstract void UpdateState(GameStateManager game);
    }
}
