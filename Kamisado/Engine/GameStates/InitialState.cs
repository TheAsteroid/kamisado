namespace Kamisado.Engine.GameStates
{
    public class InitialState : StateBase, IGameState
    {
        GameController gameController;

        public InitialState(GameController gameController)
            : base(gameController)
        {
            this.gameController = gameController;
        }

        public void EnterState(StateTable.Event ev)
        {
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
