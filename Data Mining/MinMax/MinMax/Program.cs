using System;

namespace MinMax
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] state = new int[][] { new int[] { 0, 0, 0 }, new int[] { 0, 0, 0 }, new int[] { 0, 0, 0 } };

            var tiptoe =new TicTacToe();

            Print(state);
            while (tiptoe.CheckCurrentBoardState(state) == (int)ExitValue.NotFinished)
            {
                Console.WriteLine("your turn : ");
                Console.Write("row: ");
                int x = int.Parse(Console.ReadLine());
                Console.Write("col: ");
                int y = int.Parse(Console.ReadLine());
                //TODO: Validation of input
                state[x][y] = 2;
                Print(state);

                var next = tiptoe.SearchAlphaBeta(state);
                if (next != null)
                {
                    state = next;
                    Print(state);
                }

            }

                var end = tiptoe.CheckCurrentBoardState(state);
                switch (end)
                {
                    case (int)ExitValue.ComputerWins:
                        Console.WriteLine("You loose!");
                        break;
                    case  (int)ExitValue.PlayerWins:
                        Console.WriteLine("You win!");
                        break;
                    case (int)ExitValue.NobodyWins:
                        Console.WriteLine("Equal!");
                        break;
                }
            
        }

        private static void Print(int[][] state)
        {
            for (int i = 0; i < state.Length; i++)
            {
                for (int j = 0; j < state.Length; j++)
                {
                    Console.Write(state[i][j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
