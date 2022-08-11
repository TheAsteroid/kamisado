using Kamisado.Engine.GameStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kamisado.Engine
{
    public class GameController
    {
        public enum GameType
        {
            SingleRound,        // 1 point
            StandardMatch,      // 3 points
            LongMatch,          // 7 points
            MarathonMatch       // 15 points
        }

        public enum Difficulty
        {
            Easy = 3,
            Medium = 4,
            Hard = 5,
            Impossible = 7
        }

        private const int
            WINNING_Y_PLAYER = 0,
            WINNING_Y_COMPUTER = 7,
            WINNING_VALUE = 1000,
            BLOCKED_VALUE = 5,
            ATTACKING_VALUE = 10;

        private const char delim = ';';

        private Player player;

        private Player computer;

        private Player currentPlayer;

        private Tower currentTower;

        private Board board;

        private List<Point> possibleMoves;

        private bool isFirstMoveDone;

        private StateMachine stateMachine;

        private MessageQueue messageQueue;

        private int maxLevel;

        private StringBuilder sb;

        public GameController()
        {
            isFirstMoveDone = false;
            messageQueue = null;
            stateMachine = new StateMachine(this);
            board = new Board();
        }

        public Board Board => board;

        public Tower CurrentTower => currentTower;

        public Player CurrentPlayer => currentPlayer;

        public bool IsFirstMoveDone
        {
            get { return isFirstMoveDone; }
            set { isFirstMoveDone = value; }
        }

        public StateMachine StateMachine => stateMachine;

        public MessageQueue MessageQueue => messageQueue;

        public void CreateMessageQueue(Panel messageBox, Panel moveValuesBox)
        {
            messageQueue = new MessageQueue(messageBox, moveValuesBox);
        }

        public void InitializeGame(bool isPlayerBlack)
        {
            messageQueue.Queue("Starting new game...");
            isFirstMoveDone = false;
            if (isPlayerBlack)
            {
                player = new Player(Player.PlayerType.Player, Player.PlayerColor.Black);
                computer = new Player(Player.PlayerType.Computer, Player.PlayerColor.Gold);
                currentPlayer = player;
            }
            else
            {
                player = new Player(Player.PlayerType.Player, Player.PlayerColor.Gold);
                computer = new Player(Player.PlayerType.Computer, Player.PlayerColor.Black);
                currentPlayer = computer;
            }

            board = new Board(player, computer);
            possibleMoves = new List<Point>();
            currentTower = null;
        }

        public void SetDifficulty(Difficulty difficulty)
        {
            maxLevel = (int)difficulty;
        }

        /// <summary>
        /// Check if the current player wins with the current board
        /// </summary>
        /// <returns></returns>
        public bool IsWinner()
        {
            int winningY = currentPlayer == computer ? WINNING_Y_COMPUTER : WINNING_Y_PLAYER;

            foreach (Tower t in currentPlayer.Towers.Values)
            {
                if (t.Position.Y == winningY)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Initially this is set by the player that starts the game.
        /// Otherwise it is set by the MoveTo method
        /// </summary>
        /// <param name="color"></param>
        public void SetCurrentTower(Board.Color color)
        {
            currentTower = currentPlayer.Towers[color];
            CalculatePossibleMoves();
        }

        public void SetCurrentPlayer(Player.PlayerType playerType)
        {
            switch (playerType)
            {
                case Player.PlayerType.Player:
                    currentPlayer = player;
                    break;
                case Player.PlayerType.Computer:
                    currentPlayer = computer;
                    break;
            }
        }

        /// <summary>
        /// Try to move the current tower to a given position, then set the next tower that should be moved
        /// </summary>
        /// <param name="xTo"></param>
        /// <param name="yTo"></param>
        /// <returns></returns>
        public bool MoveTo(Point position)
        {
            bool canMove = true;
            if (currentPlayer == player)
            {
                canMove = possibleMoves.Contains(position);
            }
            if (canMove)
            {
                currentTower.MoveTo(position);
                isFirstMoveDone = true;
            }
            return canMove;
        }

        public void CalculatePossibleMoves()
        {
            possibleMoves = GetPossibleMoves();
        }

        /// <summary>
        /// Get a list of moves that the current player can do
        /// </summary>
        public List<Point> GetPossibleMoves()
        {
            List<Point> possibleMoves = new List<Point>();
            int yDirection = currentPlayer.PlayDirection;
            int x = 0;
            int y = currentTower.Position.Y + yDirection;
            // Check possible moves to the left
            for (x = currentTower.Position.X - 1; x >= 0; x--, y += yDirection)
            {
                if (y < 0 || y >= Board.HEIGHT)
                {
                    break;
                }
                Point p = new Point(x, y);
                // We can only push straight forward, not to the left
                if (board[p].Tower != null)
                {
                    break;
                }
                possibleMoves.Add(p);
            }

            y = currentTower.Position.Y + yDirection;
            // Check possible moves to the right
            for (x = currentTower.Position.X + 1; x < Board.WIDTH; x++, y += yDirection)
            {
                if (y < 0 || y >= Board.HEIGHT)
                {
                    break;
                }
                Point p = new Point(x, y);
                // We can only push straight forward, not to the right
                if (board[p].Tower != null)
                {
                    break;
                }
                possibleMoves.Add(p);
            }

            x = currentTower.Position.X;
            // Check possible moves straight ahead
            for (y = currentTower.Position.Y + yDirection; y < Board.HEIGHT && y >= 0; y += yDirection)
            {
                Point p = new Point(x, y);
                // TODO: Check for possible Sumo pushes
                if (board[p].Tower != null)
                {
                    break;
                }
                possibleMoves.Add(p);
            }

            return possibleMoves;
        }

        public bool DoComputerMove()
        {
            sb = new StringBuilder();
            sb.AppendFormat("[X, Y] Value\n", delim);
            messageQueue.Queue("Calculating new computer move...");
            Move bestMove = new Move();
            // Pick a random first tower
            if (!isFirstMoveDone)
            {
                SetCurrentTower((Engine.Board.Color)new Random(DateTime.Now.Millisecond).Next(8));
                if (maxLevel == (int)Difficulty.Easy || maxLevel == (int)Difficulty.Medium)
                {
                    bestMove = new Move()
                    {
                        Position = possibleMoves.ElementAt(new Random(DateTime.Now.Second).Next(possibleMoves.Count))
                    };
                }
                else
                {
                    bestMove = ChooseMove(1);
                }
            }
            else
            {
                bestMove = ChooseMove(1);
            }

            if (bestMove.Position.X >= 0 && bestMove.Position.Y >= 0)
            {
                MoveTo(bestMove.Position);
                messageQueue.Queue("Computer moved tower {0} to {1}", currentTower.Color, board[currentTower.Position].Color);
                messageQueue.SetMoveValues(sb.ToString());

                return true;
            }
            else
            {
                messageQueue.Queue("Computer cannot move tower {0}. Skipping turn", currentTower.Color);
                return false;
            }
        }

        /// <summary>
        /// Evaluate the board for the current player after doing a move, take into account the position of the current tower
        /// </summary>
        /// <summary>
        /// Choose a move (recursively)
        /// </summary>
        /// <param name="level"></param>
        /// <param name="shouldWinPlayer"></param>
        /// <returns></returns>
        private Move ChooseMove(int level)
        {
            Move bestMove = new Move()
            {
                // Start with position -1, -1. Make sure player doesn't move if he can't.
                Position = new Point(-1, -1),
                // If max level reached, we start with a low value and maximize up because we analyze moves made by this player
                // If max level not reached, we start with the highest possible value and minimize down because we analyze moves made by the other player
                Value = -WINNING_VALUE
            };

            List<Point> possibleMoves = GetPossibleMoves();
            // No possible moves? That means this tower is blocked
            if (possibleMoves.Count == 0)
            {
                bestMove.Value = -BLOCKED_VALUE;
            }
            for (int i = 0; i < possibleMoves.Count; i++)
            {
                bool breaking = false;

                Point oldCurrentPosition = currentTower.Position;
                currentTower.MoveTo(possibleMoves[i]);

                int value = -WINNING_VALUE;
                // Player wins with this move?
                if (IsWinner())
                {
                    value = WINNING_VALUE;
                }
                // Deepest level reached? Evaluate the board (maximizing this player)
                else if (level >= maxLevel)
                {
                    value = EvaluateBoard();
                    if (value >= bestMove.Value)
                    {
                        bestMove.Value = value;
                        bestMove.Position = possibleMoves[i];
                    }
                }
                // Deepest level not reached? Go deeper (minimizing opponent)
                else
                {
                    Tower oldCurrentTower = currentTower;
                    // Switch player
                    currentPlayer = (currentPlayer == computer ? player : computer);
                    // Set current tower
                    currentTower = currentPlayer.Towers[board[oldCurrentTower.Position].Color];
                    // Get the reply of the other player. For the current player we should pick the lowest
                    Move bestOpponentMove = ChooseMove(level + 1);

                    // Revert the score because it's the score from the opponent
                    value = -bestOpponentMove.Value;

                    // Reset player
                    currentPlayer = (currentPlayer == computer ? player : computer);
                    // Reset tower
                    currentTower = oldCurrentTower;
                }

                if (value >= bestMove.Value)
                {
                    bestMove.Value = value;
                    bestMove.Position = currentTower.Position;
                    // Winning move? Don't even check other moves
                    if (value == WINNING_VALUE)
                    {
                        breaking = true;
                    }
                }

                if (level == 1)
                {
                    sb.AppendFormat("[{1}, {2}] {3} {4}\n",
                        delim,
                        currentTower.Position.X,
                        currentTower.Position.Y,
                        value,
                        (value == WINNING_VALUE ? "(Will win)" : value == -WINNING_VALUE ? "(Would lose)" : string.Empty));
                }

                // Undo the move
                currentTower.MoveTo(oldCurrentPosition);
                if (breaking)
                {
                    break;
                }
            }

            return bestMove;
        }

        private int EvaluateBoard()
        {
            int score = 0;
            // Check towers of current player
            foreach (Tower t in currentPlayer.Towers.Values)
            {
                score += EvaluateTower(t);
            }

            // Towers of other player
            Dictionary<Board.Color, Tower> otherPlayerTowers = (currentPlayer == computer ? player : computer).Towers;
            foreach (Tower t in otherPlayerTowers.Values)
            {
                score -= EvaluateTower(t);
            }

            return score;
        }

        /// <summary>
        /// Check the value of the given tower
        /// </summary>
        /// <returns></returns>
        private int EvaluateTower(Tower tower)
        {
            int possibleMoves = 0;
            Point position = tower.Position;
            Player currentPlayer = tower.Player;
            int playDirection = currentPlayer.PlayDirection;
            Point left = new Point(position.X - 1, position.Y + playDirection);
            Point straight = new Point(position.X, position.Y + playDirection);
            Point right = new Point(position.X + 1, position.Y + playDirection);
            if (left.X >= 0 && board[left].Tower == null)
            {
                possibleMoves++;
            }
            if (board[straight].Tower == null)
            {
                possibleMoves++;
            }
            if (right.X < Board.WIDTH && board[right].Tower == null)
            {
                possibleMoves++;
            }

            int score = 0;
            // Tower cannot move, return a low value
            if (possibleMoves == 0)
            {
                score = -BLOCKED_VALUE;
            }
            else
            {
                // Tower can move, check other things
                // The closer to the end of the field, the better
                if (currentPlayer == player)
                {
                    score += (Board.HEIGHT - 1) - position.Y;
                }
                else
                {
                    score += position.Y;
                }

                // Check if the tower attacks a field
                int tempY = position.Y,
                    y = position.Y + playDirection,
                    x = 0;
                if (player == computer)
                {
                    tempY = Board.HEIGHT - tempY;
                }
                // We can only attack left if we can reach it (even without pieces in the way)
                if (tempY < position.X)
                {
                    // Check left
                    for (x = position.X + 1; x < Board.WIDTH; x++, y += playDirection)
                    {
                        Point p = new Point(x, y);
                        // Tower found? We're not attacking...
                        if (board[p].Tower != null)
                        {
                            break;
                        }
                        // End of board reached, we can still attack!
                        if (y == 0 || y == Board.HEIGHT - 1)
                        {
                            score += ATTACKING_VALUE;
                            break;
                        }
                    }
                }
                // We can only attack right if we can reach it (even without pieces in the way)
                if (tempY <= Board.WIDTH - position.X)
                {
                    // Check right
                    y = position.Y + playDirection;
                    // Check possible moves to the right
                    for (x = position.X + 1; x < Board.WIDTH; x++, y += playDirection)
                    {
                        Point p = new Point(x, y);
                        // Tower found? We're not attacking...
                        if (board[p].Tower != null)
                        {
                            break;
                        }
                        // End of board reached, we can still attack!
                        if (y == 0 || y == Board.HEIGHT - 1)
                        {
                            score += ATTACKING_VALUE;
                            break;
                        }
                    }
                }
                // Always check straight ahead
                x = position.X;
                // Check possible moves straight ahead
                for (y = position.Y + playDirection; y < Board.HEIGHT && y >= 0; y += playDirection)
                {
                    Point p = new Point(x, y);
                    // TODO: Check for possible Sumo pushes
                    if (board[p].Tower != null)
                    {
                        break;
                    }
                    // End of board reached, we can still attack!
                    if (y == 0 || y == Board.HEIGHT - 1)
                    {
                        score += ATTACKING_VALUE;
                        break;
                    }
                }
            }
            return score;
        }
    }

    public struct Move
    {
        public int Value;
        public Point Position;
    }
}
