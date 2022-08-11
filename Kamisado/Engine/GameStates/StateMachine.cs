using System.Linq;

namespace Kamisado.Engine.GameStates
{
    public class StateMachine
    {
        IGameState currentState;
        StateTable stateTable;

        public StateMachine(GameController gameController)
        {
            stateTable = StateTableFactory.Create(gameController);

            currentState = (from s in stateTable.Keys
                            where s.GetType() == typeof(InitialState)
                            select s).First();
        }

        public IGameState CurrentState => currentState;

        public void HandleEvent(StateTable.Event ev)
        {
            if (stateTable[currentState].ContainsKey(ev))
            {
                currentState.Exit(ev);
                currentState = stateTable[currentState][ev];
                currentState.Enter(ev);
            }
        }

        public void HandleMouseDown(Point cursorPosition)
        {
            currentState.HandleMouseDown(cursorPosition);
        }

        public void HandleMouseUp(Point cursorPosition)
        {
            currentState.HandleMouseUp(cursorPosition);
        }
    }
}
