using System.Linq;

namespace Kamisado.Engine.GameStates
{
    public class StateMachine
    {
        IGameState currentState;
        GameController gameController;
        StateTable stateTable;

        public StateMachine(GameController gameController)
        {
            this.gameController = gameController;

            stateTable = StateTableFactory.Create(gameController);

            currentState = (from s in stateTable.Keys
                            where s.GetType() == typeof(InitialState)
                            select s).First();
        }

        public IGameState CurrentState
        {
            get { return currentState; }
        }

        public void HandleEvent(StateTable.Event ev)
        {
            if (stateTable[currentState].ContainsKey(ev))
            {
                currentState.ExitState(ev);
                currentState = stateTable[currentState][ev];
                currentState.EnterState(ev);
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
