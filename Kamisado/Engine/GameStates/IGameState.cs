namespace Kamisado.Engine.GameStates
{
    public interface IGameState
    {
        void EnterState(StateTable.Event ev);

        void ExitState(StateTable.Event ev);

        void HandleMouseDown(Engine.Point position);

        void HandleMouseUp(Engine.Point position);
    }
}
