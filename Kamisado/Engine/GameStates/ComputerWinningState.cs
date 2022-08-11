namespace Kamisado.Engine.GameStates
{
    public class ComputerWinningState : IGameState
    {
        private readonly GameController gameController;

        public ComputerWinningState(GameController gameController)
        {
            this.gameController = gameController;
        }

        public void Enter(StateTable.Event ev)
        {
            gameController.MessageQueue.Queue("You lost this round...");
        }

        public void Exit(StateTable.Event ev)
        {

        }

        public void HandleMouseDown(Point position)
        {

        }

        public void HandleMouseUp(Point position)
        {

        }
    }
}
