namespace Kamisado.Engine.GameStates
{
    public class StateBase
    {
        protected GameController gameController;

        public StateBase(GameController gameController)
        {
            this.gameController = gameController;
        }
    }
}
