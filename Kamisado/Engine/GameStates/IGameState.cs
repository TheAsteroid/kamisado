namespace Kamisado.Engine.GameStates
{
    public interface IGameState
    {
        void Enter(StateTable.Event ev);

        void Exit(StateTable.Event ev);

        void HandleMouseDown(Point position);

        void HandleMouseUp(Point position);
    }
}
