using System.Collections.Generic;

namespace Kamisado.Engine.GameStates
{
    public class StateTable : Dictionary<IGameState, Dictionary<StateTable.Event, IGameState>>
    {
        public enum Event
        {
            NewGameBlack,
            NewGameGold,
            NewGameStarted,
            TowerMoved,
            PlayerWon,
            ComputerWon
        }
    }
}
