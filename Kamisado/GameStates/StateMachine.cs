using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Kamisado.GameStates.PlayingStates;

namespace Kamisado.GameStates
{
    public class StateMachine
    {
        private IGameState gameState;

        public StateMachine()
        {
            ChangeGameState(typeof(Initializing));
        }

        public IGameState GameState
        {
            get { return gameState; }
        }

        public void ChangeGameState(Type stateType)
        {
            if (gameState == null || gameState.GetType() != stateType)
            {
                if (gameState != null)
                {
                    gameState.ExitState();
                }
                switch (stateType.Name)
                {
                    case "Initializing":
                        gameState = new Initializing();
                        break;
                    case "Playing":
                        gameState = new Playing(typeof(PlayerTurn));
                        break;
                    default:
                        throw new NotSupportedException("GameState " + stateType.Name + " does not exist");
                }
            }
        }
    }
}
