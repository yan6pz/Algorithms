using MinMax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinMax
{
    class TicTacToe
    {

        private const int BOARD_SIZE = 3;
        public static Dictionary<string, int> NextMoves;
    
        public int[][] SearchAlphaBeta(int[][] state)
        {
            NextMoves = new Dictionary<string, int>();
            var successors = GetPossiblePossitions(state, 1);
            for (int i = 0; i < successors.Count; i++)
            {
                var move = successors.ElementAt(i).ToStringBoard();
                //myDictionary.Item[key] = valu
                NextMoves.Add(move, 6);
            }
            int value = MaxPlayerTurn(state, int.MinValue, int.MaxValue);

            //search for the next move with the given value
            foreach (var move in NextMoves)
            {
                if (move.Value==value)
                {
                    return move.Key.ToInt();
                }
            }
                
            
            return null;
        }

        private int MaxPlayerTurn(int[][] state, int alpha, int beta)
        {
            if (CheckCurrentBoardState(state) !=(int)ExitValue.NotFinished)
            {
                return CheckCurrentBoardState(state);
            }
            int v = int.MinValue;

            var positions = GetPossiblePossitions(state, 1);
            //branching
            for (int i = 0; i < positions.Count; i++)
            {

                int min = MinPlayerTurn(positions.ElementAt(i), alpha, beta);
                //if the exit of min is bigger than v we change the current state value with min
                if (min > v)
                {
                    if (NextMoves.ContainsKey(positions.ElementAt(i).ToStringBoard()))
                    {
                        NextMoves.Remove(positions.ElementAt(i).ToStringBoard());
                        NextMoves.Add(positions.ElementAt(i).ToStringBoard(), min);
                    }
                    v = min;
                }
                //beta cut off
                if (v >= beta)
                {
                    return v;
                }
                alpha = Math.Max(alpha, v);
            }
            return v;
        }



        private int MinPlayerTurn(int[][] state, int alpha, int beta)
        {
            if (CheckCurrentBoardState(state) !=(int)ExitValue.NotFinished)
            {
                return (int)CheckCurrentBoardState(state);
            }
            int v = int.MaxValue;

           var positions = GetPossiblePossitions(state, 2);

            for (int i = 0; i < positions.Count; i++)
            {
                v = Math.Min(v, MaxPlayerTurn(positions.ElementAt(i), alpha, beta));
                //alpha cut off
                if (v <= alpha)
                {
                    return v;
                }
                beta = Math.Min(beta, v);
            }
            return v;
        }

       
        
        public int CheckCurrentBoardState(int[][] board)
        {
            int[] result = new int[] { 1, -1 };
            for (int player = 1; player <= 2; player++)
            {
                for (int column = 0; column < BOARD_SIZE; column++)
                {
                    if (board[0][column] == player && board[1][column] == player
                            && board[2][column] == player)
                    {
                        return result[player-1];
                    }
                }

                for (int row = 0; row < BOARD_SIZE; row++)
                {
                    if (board[row][0] == player && board[row][1] == player
                            && board[row][2] == player)
                    {
                        return result[player - 1];
                    }
                }

                if (board[0][0] == player && board[1][1] == player
                        && board[2][2] == player)
                {
                    return result[player - 1];
                }
                if (board[0][2] == player && board[1][1] == player
                        && board[2][0] == player)
                {
                    return result[player - 1];
                }
            }

            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    if (board[i][j] == 0)
                    {
                        return (int)ExitValue.NotFinished;
                    }
                }
            }
            return (int)ExitValue.NobodyWins;
        }

        private List<int[][]> GetPossiblePossitions(int[][] board, int player)
        {
            var successors = new List<int[][]>();
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board.Length; j++)
                {
                    if (board[i][j] == 0)
                    {
                        var newArray = board.CopyArray();
                        newArray[i][j] = player;
                        successors.Add(newArray);
                    }
                }
            }
            return successors;
        } 
    }
}

