namespace Kamisado.Engine.GameStates
{
    public class PlayerWinningState : StateBase, IGameState
    {
        public PlayerWinningState(GameController gameController)
            : base(gameController)
        {

        }

        public void EnterState(StateTable.Event ev)
        {
            gameController.MessageQueue.Queue("Congratulations, you have won this round!");
        }

        public void ExitState(StateTable.Event ev)
        {

        }

        public void HandleMouseDown(Engine.Point position)
        {
            // Do nothing
        }

        public void HandleMouseUp(Engine.Point position)
        {
            // Do nothing
        }
    }
}
