namespace Kamisado.Engine.GameStates
{
    public class NewGameState : IGameState
    {
        private readonly GameController gameController;

        public NewGameState(GameController gameController)
        {
            this.gameController = gameController;
        }

        public void Enter(StateTable.Event ev)
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
