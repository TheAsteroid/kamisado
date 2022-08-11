namespace Kamisado.Engine.GameStates
{
    public class ComputerState : StateBase, IGameState
    {
        public ComputerState(GameController gameController)
            : base(gameController)
        {

        }

        public void EnterState(StateTable.Event ev)
        {
            gameController.SetCurrentPlayer(Player.PlayerType.Computer);

            // First move has been done? Set the current tower for the computer
            if (gameController.IsFirstMoveDone)
            {
                gameController.SetCurrentTower(
                    gameController.Board[gameController.CurrentTower.Position].Color);
            }

            gameController.DoComputerMove();

            StateTable.Event eventDone = StateTable.Event.TowerMoved;
            if (gameController.IsWinner())
            {
                eventDone = StateTable.Event.ComputerWon;
            }
            // Go to the next state if the computer has finished calculating
            gameController.StateMachine.HandleEvent(eventDone);
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
