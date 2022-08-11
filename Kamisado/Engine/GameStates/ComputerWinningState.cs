namespace Kamisado.Engine.GameStates
{
    public class ComputerWinningState : StateBase, IGameState
    {
        public ComputerWinningState(GameController gameController)
            : base(gameController)
        {

        }

        public void EnterState(StateTable.Event ev)
        {
            gameController.MessageQueue.Queue("You lost this round...");
        }

        public void ExitState(StateTable.Event ev)
        {

        }

        public void HandleMouseDown(Engine.Point position)
        {

        }

        public void HandleMouseUp(Engine.Point position)
        {

        }
    }
}
