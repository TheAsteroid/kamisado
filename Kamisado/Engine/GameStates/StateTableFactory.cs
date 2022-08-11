using System.Collections.Generic;

namespace Kamisado.Engine.GameStates
{
    public class StateTableFactory
    {
        public static StateTable Create(GameController gameController)
        {
            InitialState initialState = new InitialState(gameController);
            NewGameState newGameState = new NewGameState(gameController);
            ComputerState computerState = new ComputerState(gameController);
            PlayerState playerState = new PlayerState(gameController);
            ComputerWinningState computerWinningState = new ComputerWinningState(gameController);
            PlayerWinningState playerWinningState = new PlayerWinningState(gameController);

            return new StateTable()
            {
                {initialState, new Dictionary<StateTable.Event, IGameState>()
                {
                    {StateTable.Event.NewGameBlack, newGameState},
                    {StateTable.Event.NewGameGold, newGameState},
                }},
                {newGameState, new Dictionary<StateTable.Event, IGameState>()
                {
                    {StateTable.Event.NewGameBlack, playerState},
                    {StateTable.Event.NewGameGold, computerState}
                }},
                {computerState, new Dictionary<StateTable.Event, IGameState>()
                {
                    {StateTable.Event.TowerMoved, playerState},
                    {StateTable.Event.ComputerWon, computerWinningState},
                    {StateTable.Event.NewGameBlack, newGameState},
                    {StateTable.Event.NewGameGold, newGameState}
                }},
                {playerState, new Dictionary<StateTable.Event, IGameState>()
                {
                    {StateTable.Event.TowerMoved, computerState},
                    {StateTable.Event.PlayerWon, playerWinningState},
                    {StateTable.Event.NewGameBlack, newGameState},
                    {StateTable.Event.NewGameGold, newGameState},
                }},
                {computerWinningState, new Dictionary<StateTable.Event, IGameState>()
                {
                    {StateTable.Event.NewGameBlack, newGameState},
                    {StateTable.Event.NewGameGold, newGameState}
                }},
                {playerWinningState, new Dictionary<StateTable.Event, IGameState>()
                {
                    {StateTable.Event.NewGameBlack, newGameState},
                    {StateTable.Event.NewGameGold, newGameState}
                }}
            };
        }
    }
}
