namespace Kamisado.Engine.GameStates
{
    public class PlayerWinningState : IGameState
    {
        private readonly GameController gameController;

        public PlayerWinningState(GameController gameController)
        {
            this.gameController = gameController;
        }

        public void Enter(StateTable.Event ev)
        {
            gameController.MessageQueue.Queue("Congratulations, you have won this round!");
        }

        public void Exit(StateTable.Event ev)
        {

        }

        public void HandleMouseDown(Point position)
        {
            // Do nothing
        }

        public void HandleMouseUp(Point position)
        {
            // Do nothing
        }
    }
}
