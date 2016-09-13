namespace _03.Portal
{
    using System;

    public static class Portal
    {
        private static char[][] maze;

        private static int currentRow;
        private static int currentCol;

        public static void Main()
        {
            var mazeHeight = int.Parse(Console.ReadLine());
            maze = new char[mazeHeight][];
            for (int row = 0; row < mazeHeight; row++)
            {
                var rowContent = Console.ReadLine()
                    .Replace(" ", "")
                    .ToCharArray();

                maze[row] = rowContent;
            }

            GetInitialPosition();
            var directions = Console.ReadLine().ToCharArray();
            for (int i = 0; i < directions.Length; i++)
            {
                switch (directions[i])
                {
                    case 'U':
                        currentRow--; 
                        MoveUp();
                        break;
                    case 'R':
                        currentCol++;
                        MoveRight();
                        break;
                    case 'D':
                        currentRow++;
                        MoveDown();
                        break;
                    default:
                        currentCol--;
                        MoveLeft();
                        break;
                }

                IsExit(i + 1);
            }

            Console.WriteLine($"Robot stuck at {currentRow} {currentCol}. Experiment failed.");
        }

        private static void GetInitialPosition()
        {
            for (int row = 0; row < maze.Length; row++)
            {
                for (int col = 0; col < maze[row].Length; col++)
                {
                    if (maze[row][col] == 'S')
                    {
                        currentRow = row;
                        currentCol = col;
                        return;
                    }
                }
            }
        }

        private static void IsExit(int turns)
        {
            if (maze[currentRow][currentCol] == 'E')
            {
                Console.WriteLine($"Experiment successful. {turns} turns required.");
                Environment.Exit(0);
            }
        }

        private static bool CellExists()
        {
            return maze.Length > currentRow && currentRow >= 0 && maze[currentRow].Length > currentCol && currentCol >= 0;
        }

        private static void MoveUp()
        {
            while (!CellExists())
            {
                currentRow--;
                if (currentRow < 0)
                {
                    currentRow = maze.Length - 1;
                }
            }
        }

        private static void MoveRight()
        {
            while (!CellExists())
            {
                currentCol++;
                if (currentCol >= maze[currentRow].Length)
                {
                    currentCol = 0;
                }
            }
        }

        private static void MoveDown()
        {
            while (!CellExists())
            {
                currentRow++;
                if (currentRow >= maze.Length)
                {
                    currentRow = 0;
                }
            }
        }

        private static void MoveLeft()
        {
            while (!CellExists())
            {
                currentCol--;
                if (currentCol < 0)
                {
                    currentCol = maze[currentRow].Length - 1;
                }
            }
        }
    }
}
