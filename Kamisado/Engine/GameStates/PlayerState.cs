using System;

namespace Kamisado.Engine.GameStates
{
    public class PlayerState : IGameState
    {
        private readonly GameController gameController;

        public PlayerState(GameController gameController)
        {
            this.gameController = gameController;
        }

        public void Enter(StateTable.Event ev)
        {
            gameController.SetCurrentPlayer(Player.PlayerType.Player);

            // First move has been done? Set the current tower for the player
            if (gameController.IsFirstMoveDone)
            {
                gameController.SetCurrentTower(
                    gameController.Board[gameController.CurrentTower.Position].Color);

                gameController.MessageQueue.Queue("Your turn. Move tower {0}", gameController.CurrentTower.Color);
                // Calculate the possible moves for the player
                gameController.CalculatePossibleMoves();
                // No possible moves? Skip to the next player by emulating a tower move
                if (gameController.GetPossibleMoves().Count == 0)
                {
                    gameController.MessageQueue.Queue("You cannot move tower {0}. Skipping turn", gameController.CurrentTower.Color);
                    gameController.StateMachine.HandleEvent(StateTable.Event.TowerMoved);
                }
            }
            else
            {
                gameController.MessageQueue.Queue("Move a tower straight or diagonally forward");
            }
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
            bool isDroppingTower = true;
            // If first move has not been done yet, player can choose any tower
            if (!gameController.IsFirstMoveDone)
            {
                Field f = null;
                // See if the player selected a tower
                try
                {
                    f = gameController.Board[position];

                    if (f != null && f.Tower != null)
                    {
                        // Set the current tower that will be moved
                        gameController.SetCurrentTower(f.Tower.Color);
                    }
                    // If the player does not select a new tower and a tower is already selected
                    else if (gameController.CurrentTower != null)
                    {
                        isDroppingTower = true;
                    }
                }
                // No tower selected? Return false
                catch (Exception) { }
            }

            if (isDroppingTower)
            {
                isDroppingTower = false;
                try
                {
                    Field f = gameController.Board[position];
                    if (f != null)
                    {
                        // Try to move the tower
                        if (gameController.MoveTo(position))
                        {
                            StateTable.Event eventDone = StateTable.Event.TowerMoved;
                            if (gameController.IsWinner())
                            {
                                eventDone = StateTable.Event.PlayerWon;
                            }
                            gameController.StateMachine.HandleEvent(eventDone);
                        }
                    }
                }
                catch (Exception) { }
            }
        }
    }
}
