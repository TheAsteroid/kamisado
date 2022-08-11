namespace Kamisado.Engine.GameStates
{
    public class NewGameState : StateBase, IGameState
    {
        public NewGameState(GameController gameController)
            : base(gameController)
        {

        }

        public void EnterState(StateTable.Event ev)
        {
            gameController.MessageQueue.Clear();
            if (ev == StateTable.Event.NewGameGold)
            {
                gameController.InitializeGame(false);
            }
            else if (ev == StateTable.Event.NewGameBlack)
            {
                gameController.InitializeGame(true);
            }
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
